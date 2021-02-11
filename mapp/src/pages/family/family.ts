import { Component } from '@angular/core';
import { NavController,LoadingController, Events, Refresher,ModalController, Platform, AlertController, NavParams } from 'ionic-angular';
import { Response } from '@angular/http';
import { UiHelper } from '../../services/uihelper';
import { AppServer } from '../../services/appserver';
import { AppGlobals } from '../../services/appglobals';
import { AddFamilyPage } from '../add-family/add-family';

@Component({
    selector: 'page-family',
    templateUrl: 'family.html'
})
export class FamilyPage {

    private loader:any = null;
    private refresher: Refresher = null;
    
    private feedType: string = 'family';
    private family: any[] = [];
    private pending: any[] = [];

    private myself: any = null;

    private phoneNumber:string = '';
    private name: string = '';
    private relation: string = 'father';

    private relations:any[]=[];

    constructor(public alertCtrl: AlertController, public modalCtrl: ModalController, public navCtrl: NavController,public events: Events,public loadingCtrl: LoadingController,public uiHelper: UiHelper,public server: AppServer,public globals: AppGlobals,public navParams: NavParams, public platform: Platform) {
        this.myself=this;
        this.events.subscribe('request_sent',()=>{
            console.log("request_sent");
            this.myself.getStores();
        });
        this.relations.push({value:'father',title:'Father'});
        this.relations.push({value:'mother',title:'Mother'});
        this.relations.push({value:'daughter',title:'Daughter'});
        this.relations.push({value:'son',title:'Son'});
        this.relations.push({value:'brother',title:'Brother'});
        this.relations.push({value:'sister',title:'Sister'});
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
    }

    processIndividualItem(st){
        return st;
    }

    storesSuccess(res: Response){
        console.log("storesSuccess");
        if (this.loader!=null){
            this.loader.dismiss();
        }
        if (this.refresher!=null){
            this.refresher.complete();
        }
        console.log(res.text());
        let jsonRes=res.json();
        if (jsonRes.status!=200){
            this.uiHelper.showMessageBox('Error',jsonRes.msg);
        }else{
            this.family=[];
            this.pending=[];
            let pending=jsonRes.data.pending;
            for (let a=0;a<pending.length;a++){
                let st=pending[a];
                st.date_display_text=this.uiHelper.getMealDisplayDate(st.request_ts*1000,new Date().getTime());
                this.pending.push(st);
            }
            let family=jsonRes.data.family;
            for (let a=0;a<family.length;a++){
                let st=family[a];
                this.family.push(st);
            }
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
        that.server.getFamily({user_id: uid}).subscribe(
            res=>that.storesSuccess(res),err=>that.storesFailure(err)
        );
    }

    addFamilyClick(){
        console.log("addFamilyClick");
        this.navCtrl.push(AddFamilyPage,{});
    }

    actionClick(st,action){
        console.log("actionClick: "+st.name+","+action);
        this.loader = this.loadingCtrl.create({
            content: "Please wait...",
        });
        this.loader.present();
        let uid=this.globals.currentUser.id;
        this.server.actionToFamily({user_id: uid,user_id2: st.parent_id,action: action}).subscribe(
            (res)=>{
                this.loader.dismiss();
                let jsonRes=res.json();
                if (jsonRes.status!=200){
                    this.uiHelper.showMessageBox("Error",jsonRes.msg);
                    return;
                }
                this.getStores(true);
            },(err)=>{
                this.storesFailure(err);
            }
        );
    }

    saveClick(){
        console.log("saveClick");
        this.loader = this.loadingCtrl.create({
            content: "Please wait...",
        });
        this.loader.present();
        let uid=this.globals.currentUser.id;
        this.server.addToFamily({user_id: uid,phone: this.phoneNumber,name: this.name}).subscribe(
            (res)=>{
                this.loader.dismiss();
                console.log(res.text());
                let jsonRes=res.json();
                if (jsonRes.status!=200){
                    this.uiHelper.showMessageBox("Error",jsonRes.msg);
                    return;
                }
                let alert=this.uiHelper.showMessageBox("","Request sent");
                alert.onDidDismiss(()=>{
                    this.events.publish('request_sent');
                });
                this.phoneNumber='';
                this.name='';
            },(err)=>{
                this.loader.dismiss();
                console.error(JSON.stringify(err));
                this.uiHelper.showMessageBox("Error",JSON.stringify(err));
            }
        );
    }
    
}
