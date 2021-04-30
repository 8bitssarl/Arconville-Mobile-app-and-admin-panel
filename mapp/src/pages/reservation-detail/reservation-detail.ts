import { Component } from '@angular/core';
import { NavController,LoadingController, Events, Refresher,ModalController, Platform, AlertController, NavParams } from 'ionic-angular';
import { Response } from '@angular/http';
import { UiHelper } from '../../services/uihelper';
import { AppServer } from '../../services/appserver';
import { AppGlobals } from '../../services/appglobals';

@Component({
    selector: 'page-reservation-detail',
    templateUrl: 'reservation-detail.html'
})
export class ReservationDetailPage {

    private loader:any = null;
    private reservation:any=null;
    
    constructor(public alertCtrl: AlertController, public modalCtrl: ModalController, public navCtrl: NavController,public events: Events,public loadingCtrl: LoadingController,public uiHelper: UiHelper,public server: AppServer,public globals: AppGlobals,public navParams: NavParams, public platform: Platform) {
        this.reservation=this.navParams.get('reservation');
    }

    ionViewDidLoad(){
    }

    onCancelReservation(st){
        console.log("onCancelReservation: "+st.id);
        this.loader = this.loadingCtrl.create({
            content: this.globals.getTranslatedText("please_wait")+"...",
        });
        this.loader.present();
        let data={user_id: this.globals.currentUser.id,reservation_id: st.id};
        this.server.cancelReservation(data).subscribe((res)=>{
            this.loader.dismiss();
            let json=res.json();
            if (json.status==200){
                this.uiHelper.showMessageBox("","Reservation canceled");
                this.events.publish('reservation_saved');
                this.navCtrl.pop();
            }else{
                this.uiHelper.showMessageBox("Error",json.msg);
            }
        },(err)=>{
            this.loader.dismiss();
            console.error("Error: "+JSON.stringify(err));
            this.uiHelper.showMessageBox('Error',JSON.stringify(err));
        })
    }

    cancelClick(st){
        console.log("cancelClick: "+st.service_name);
        this.uiHelper.showConfirmBox(this.globals.getTranslatedText("cancel"),this.globals.getTranslatedText("sure_want_to_cancel"),()=>{
            this.onCancelReservation(st);
        },()=>{});
    }
}
