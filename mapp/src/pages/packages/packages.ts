import { Component } from '@angular/core';
import { NavController,LoadingController, Events, Refresher,ModalController, Platform, AlertController, NavParams, ActionSheetController } from 'ionic-angular';
import { Response } from '@angular/http';
import { UiHelper } from '../../services/uihelper';
import { AppServer } from '../../services/appserver';
import { AppGlobals } from '../../services/appglobals';
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
        //this.getStores();
        this.processGlobalPackages();
        this.filterItems();
    }

    doRefresh(evt){
        console.log("doRefresh");
        this.refresher=evt;
    }

    feedTypeChanged(evt){
        console.log("feedTypeChanged: "+this.feedType);
        this.filterItems();
    }

    processGlobalPackages(){
        this.items=[];
        this.allItems=[];
        this.featuredPackages=[];
        let items=this.globals.packages;
        for (let a=0;a<items.length;a++){
            let st=items[a];
            this.allItems.push(st);
            if (st.featured=="1"){
                //console.log("Yes featured");
                this.featuredPackages.push(st);
            }
        }
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
        let allFavs=[];//this.globals.getFavorites();
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

    itemClick(st){
        console.log("itemClick");
        if (this.feedType=='upcoming'){
            console.log(st.id);
            //this.navCtrl.push(PackageDetailPage,{package: st});
        }
    }
urlClick(st){
    location.href="https://www.google.com/maps/search/?api=1&query="+st.latitude+"%2C"+st.longitude
}
    subClick(st){
        console.log("subClick");
        this.saveClick(st);
    }

    unsubClick(st){
        console.log("unsubClick");
        this.saveClick(st);
    }

    saveClick(st){
        console.log("saveClick");
        this.loader = this.loadingCtrl.create({
            content: this.globals.getTranslatedText("please_wait")+"...",
        });
        this.loader.present();
        let uid=this.globals.currentUser.id;
        this.server.subscribePackage({user_id: uid,package_id: st.id}).subscribe(
            (res)=>{
                this.loader.dismiss();
                console.log(res.text());
                let jsonRes=res.json();
                if (jsonRes.status!=200){
                    this.uiHelper.showMessageBox("Error",jsonRes.msg);
                    return;
                }
                st.has_sub_request=jsonRes.data.has_sub_request;
                if (st.has_sub_request){
                    this.uiHelper.showMessageBox("","Please pass by our offices to complete the subscription process");
                }
            },(err)=>{
                this.loader.dismiss();
                console.error(JSON.stringify(err));
                this.uiHelper.showMessageBox("Error",JSON.stringify(err));
            }
        );
    }
}
