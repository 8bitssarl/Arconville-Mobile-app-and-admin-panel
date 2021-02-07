import { Component } from '@angular/core';
import { NavController,LoadingController, Events, ModalController, Platform, AlertController, MenuController } from 'ionic-angular';
import { UiHelper } from '../../services/uihelper';
import { AppServer } from '../../services/appserver';
import { AppGlobals } from '../../services/appglobals';
import { FeedPage } from '../feed/feed';
import { FamilyPage } from '../family/family';
import { PackagesPage } from '../packages/packages';
import { SettingsPage } from '../settings/settings';
import { EditProfilePage } from '../edit-profile/edit-profile';

@Component({
    selector: 'page-home',
    templateUrl: 'home.html'
})
export class HomePage {

    public tabPackages=PackagesPage;
    public tabFeed=FeedPage;
    public tabFamily=FamilyPage;
    //public tabProfile=SettingsPage;
    public tabProfile=EditProfilePage;

    public rootPage=PackagesPage;

    constructor(public menuCtrl: MenuController, public alertCtrl: AlertController, public modalCtrl: ModalController, public navCtrl: NavController,public events: Events,public loadingCtrl: LoadingController,public uiHelper: UiHelper,public server: AppServer,public globals: AppGlobals,public platform: Platform) {
    }

    private openPage(cmp){
        this.menuCtrl.close();
        this.navCtrl.push(cmp);
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
