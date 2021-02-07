import { Component,NgZone } from '@angular/core';
import { NavController, Events, Platform } from 'ionic-angular';
import { AppGlobals } from '../../services/appglobals';
import { Geolocation } from '@ionic-native/geolocation';
import { AppServer } from '../../services/appserver';
import { UiHelper } from '../../services/uihelper';
import { EditProfilePage } from '../edit-profile/edit-profile';

@Component({
    selector: 'page-settings',
    templateUrl: 'settings.html'
})
export class SettingsPage {

    constructor(public zone: NgZone, public platform: Platform, public navCtrl: NavController,public events: Events,public globals: AppGlobals,public geolocation: Geolocation,public server: AppServer,public uiHelper: UiHelper) {
    }

    ionViewDidLoad(){
    }

    settingClick(it){
        console.log("settingClick: "+it);
        if (it=='logout'){
            this.logoutClick();
        }else if (it=='profile'){
            this.navCtrl.push(EditProfilePage);
        }
    }

    logoutClick(){
        console.log("logoutClick");
        let that=this;
        this.uiHelper.showConfirmBox("Logout","Are you sure you want to logout?",()=>{
            that.globals.setUser(null);
            (<any>window).location.reload();
        },()=>{

        });
    }
}
