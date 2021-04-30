import { Component } from '@angular/core';
import { NavController,LoadingController, Events, Refresher,ModalController, Platform, AlertController, NavParams } from 'ionic-angular';
import { Response } from '@angular/http';
import { UiHelper } from '../../services/uihelper';
import { AppServer } from '../../services/appserver';
import { AppGlobals } from '../../services/appglobals';

@Component({
    selector: 'page-package-detail',
    templateUrl: 'package-detail.html'
})
export class PackageDetailPage {

    private loader:any = null;
    private package:any=null;
    private services:any[]=[];
    
    constructor(public alertCtrl: AlertController, public modalCtrl: ModalController, public navCtrl: NavController,public events: Events,public loadingCtrl: LoadingController,public uiHelper: UiHelper,public server: AppServer,public globals: AppGlobals,public navParams: NavParams, public platform: Platform) {
        this.package=this.navParams.get('package');
        console.log("Location: "+this.package.location_text);
        for (let x=0;x<this.globals.packageServices.length;x++){
            if (this.globals.packageServices[x].package_id==this.package.id){
                this.services.push(this.globals.packageServices[x]);
            }
        }
    }

    ionViewDidLoad(){
    }

    saveClick(){
        console.log("saveClick");
        this.loader = this.loadingCtrl.create({
            content: this.globals.getTranslatedText("please_wait")+"...",
        });
        this.loader.present();
        let uid=this.globals.currentUser.id;
        this.server.subscribePackage({user_id: uid,package_id: this.package.id}).subscribe(
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
                    that.events.publish('subscribe_request_sent');
                    that.navCtrl.pop();
                });
            },(err)=>{
                this.loader.dismiss();
                console.error(JSON.stringify(err));
                this.uiHelper.showMessageBox("Error",JSON.stringify(err));
            }
        );
    }

    locationClick(st){
        console.log("locationClick: "+st.location_text);
        let mapsUrl="https://www.google.com/maps/search/?api=1&query="+st.latitude+","+st.longitude;
        window.open(mapsUrl,"_blank");
    }
}
