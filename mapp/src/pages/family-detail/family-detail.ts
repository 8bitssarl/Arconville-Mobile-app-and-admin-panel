import { Component } from '@angular/core';
import { NavController,LoadingController,ActionSheetController,ModalController, NavParams } from 'ionic-angular';
import { Response } from '@angular/http';
import { UiHelper } from '../../services/uihelper';
import { AppServer } from '../../services/appserver';
import { AppGlobals } from '../../services/appglobals';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
    selector: 'page-family-detail',
    templateUrl: 'family-detail.html'
})
export class FamilyDetailPage {

    private loginData:any={name:'',phone_number:'',relation:'',profile_pic_url:''};
    
    constructor(public modalCtrl: ModalController,public navParams: NavParams, public navCtrl: NavController,public loadingCtrl: LoadingController,public actionSheetCtrl: ActionSheetController,private sanitizer:DomSanitizer,public uiHelper: UiHelper,public server: AppServer,public globals: AppGlobals) {
        let usr=this.navParams.get('family');
        this.loginData.name=usr.name;
        this.loginData.phone_number=usr.phone_number;
        this.loginData.relation=usr.relation.toUpperCase();
        this.loginData.profile_pic_url=usr.profile_pic_url;
    }

    ionViewDidLoad(){
    }

    sanitize(url:string){
        return this.sanitizer.bypassSecurityTrustUrl(url);
    }
}
