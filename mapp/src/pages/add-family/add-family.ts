import { Component } from '@angular/core';
import { NavController,LoadingController, Events, Refresher,ModalController, Platform, AlertController, NavParams } from 'ionic-angular';
import { Response } from '@angular/http';
import { UiHelper } from '../../services/uihelper';
import { AppServer } from '../../services/appserver';
import { AppGlobals } from '../../services/appglobals';

@Component({
    selector: 'page-add-family',
    templateUrl: 'add-family.html'
})
export class AddFamilyPage {

    private loader:any = null;
    private phoneNumber:string = '';

    constructor(public alertCtrl: AlertController, public modalCtrl: ModalController, public navCtrl: NavController,public events: Events,public loadingCtrl: LoadingController,public uiHelper: UiHelper,public server: AppServer,public globals: AppGlobals,public navParams: NavParams, public platform: Platform) {
    }

    ionViewDidLoad(){
    }

    saveClick(){
        console.log("saveClick");
        this.loader = this.loadingCtrl.create({
            content: "Please wait...",
        });
        this.loader.present();
        let uid=this.globals.currentUser.id;
        this.server.addToFamily({user_id: uid,phone: this.phoneNumber}).subscribe(
            (res)=>{
                this.loader.dismiss();
                console.log(res.text());
                let jsonRes=res.json();
                if (jsonRes.status!=200){
                    this.uiHelper.showMessageBox("Error",jsonRes.msg);
                    return;
                }
                let alert=this.uiHelper.showMessageBox("","Request sent");
                let that=this;
                alert.onDidDismiss(()=>{
                    that.events.publish('request_sent');
                    that.navCtrl.pop();
                });
            },(err)=>{
                this.loader.dismiss();
                console.error(JSON.stringify(err));
                this.uiHelper.showMessageBox("Error",JSON.stringify(err));
            }
        );
    }
}
