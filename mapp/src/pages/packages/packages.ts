import { Component } from '@angular/core';
import { NavController,LoadingController, Events, Refresher,ModalController, Platform, AlertController, NavParams, ActionSheetController } from 'ionic-angular';
import { Response } from '@angular/http';
import { UiHelper } from '../../services/uihelper';
import { AppServer } from '../../services/appserver';
import { AppGlobals } from '../../services/appglobals';
import { ReservationPage } from '../reservation/reservation';
import { PackageDetailPage } from '../package-detail/package-detail';

@Component({
    selector: 'page-packages',
    templateUrl: 'packages.html'
})
export class PackagesPage {

    private loader:any = null;
    private refresher: Refresher = null;
    
    private allItems:any[] = [];
    private items: any[] = [];
    private featuredPackages:any[]=[];
    private feedType: string = 'upcoming';

    private myself: any = null;

    constructor(public alertCtrl: AlertController, public modalCtrl: ModalController, public navCtrl: NavController,public events: Events,public loadingCtrl: LoadingController,public uiHelper: UiHelper,public server: AppServer,public globals: AppGlobals,public navParams: NavParams, public platform: Platform,public actionSheetCtrl: ActionSheetController) {
        this.myself=this;
    }

    ionViewDidLoad(){
        this.getStores();
    }

    doRefresh(evt){
        console.log("doRefresh");
        this.refresher=evt;
        this.getStores(false);
    }

    feedTypeChanged(evt){
        console.log("feedTypeChanged: "+this.feedType);
        this.filterItems();
    }

    processIndividualItem(st,allFavs=[]){
        st.is_favorited=false;
        for (let b=0;b<allFavs.length;b++){
            if (allFavs[b].id==st.id){
                st.is_favorited=true;
                break;
            }
        }
        return st;
    }

    filterItems(){
        console.log("filterItems");
        this.items=[];
        let allFavs=this.globals.getFavorites();
        for (let a=0;a<this.allItems.length;a++){
            let st=JSON.parse(JSON.stringify(this.allItems[a]));
            if (this.feedType=="upcoming" && !st.is_upcoming){
                continue;
            }else if (this.feedType=="previous" && st.is_upcoming){
                continue;
            }
            st=this.processIndividualItem(st,allFavs);
            this.items.push(st);
        }
    }

    storesSuccess(res: Response){
        console.log("storesSuccess");
        if (this.loader!=null){
            this.loader.dismiss();
        }
        if (this.refresher!=null){
            this.refresher.complete();
        }
        let jsonRes=res.json();
        if (jsonRes.status!=200){
            this.uiHelper.showMessageBox('Error',jsonRes.msg);
        }else{
            this.items=[];
            this.allItems=[];
            this.featuredPackages=[];
            this.globals.packageServices=[];
            let items=jsonRes.data.upcoming;
            for (let a=0;a<items.length;a++){
                let st=items[a];
                st.is_upcoming=true;
                st.date_display_text="";
                st.exp_display_text="";
                st.image_url="https://www.gstatic.com/webp/gallery/1.jpg";
                if (a==1){
                    st.image_url="https://www.gstatic.com/webp/gallery/2.jpg";
                }
                st.background_image="url('"+st.image_url+"')";
                this.allItems.push(st);
                if (st.featured=="1"){
                    console.log("Yes featured");
                    this.featuredPackages.push(st);
                }
            }
            items=jsonRes.data.previous;
            for (let a=0;a<items.length;a++){
                let st=items[a];
                st.is_upcoming=false;
                st.date_display_text=this.uiHelper.getMealDisplayOnlyDate(st.start_ts*1000,new Date().getTime());
                st.exp_display_text=this.uiHelper.getMealDisplayOnlyDate(st.exp_ts*1000,new Date().getTime());
                st.image_url="https://www.gstatic.com/webp/gallery/1.jpg";
                if (a==1){
                    st.image_url="https://www.gstatic.com/webp/gallery/2.jpg";
                }
                this.allItems.push(st);
            }
            this.filterItems();

            items=jsonRes.data.services;
            for (let a=0;a<items.length;a++){
                let st=items[a];
                this.globals.packageServices.push(st);
            }

            /*setTimeout(()=>{
                let elem=document.getElementById("allFeaturedContainer");
                elem.className='all-featured-container';
            },300);*/
        }
    }

    storesFailure(error: any){
        console.log("storesFailure");
        if (this.loader!=null){
            this.loader.dismiss();
        }
        if (this.refresher!=null){
            this.refresher.complete();
        }
        this.uiHelper.showMessageBox('Error',JSON.stringify(error));
    }

    getStores(showLoader: boolean = true){
        console.log("getStores");
        let that=this;
        this.loader = this.loadingCtrl.create({
            content: "Please wait...",
        });
        if (showLoader){
            this.loader.present();
        }
        let uid=this.globals.currentUser.id;
        that.server.getPackages({user_id: uid}).subscribe(
            res=>that.storesSuccess(res),err=>that.storesFailure(err)
        );
    }

    itemClick(st){
        console.log("itemClick");
        if (this.feedType=='upcoming'){
            console.log(st.id);
            this.navCtrl.push(PackageDetailPage,{package: st});
        }
    }
}
