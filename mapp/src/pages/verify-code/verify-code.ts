import { Component } from '@angular/core';
import { NavController, LoadingController } from 'ionic-angular';
import { Response } from '@angular/http';
import { UiHelper } from '../../services/uihelper';
import { AppServer } from '../../services/appserver';
import { AppGlobals } from '../../services/appglobals';
import { HomePage } from '../home/home';

@Component({
    selector: 'page-verify-code',
    templateUrl: 'verify-code.html'
})
export class VerifyCodePage {

    private loginData:any={code:''};
    private loader: any = null;

    constructor(public navCtrl: NavController,public loadingCtrl: LoadingController,public uiHelper: UiHelper,public server: AppServer,public globals: AppGlobals) {

    }

    loginClick(){
        console.log("loginClick");
        if(this.loginData.code.trim()==""){
            this.uiHelper.showMessageBox("Error","Please enter verification code");
            return;
        }
        this.doLogin();
    }

    loginSuccess(res: Response){
        console.log("loginSuccess");
        if (this.loader!=null){
            this.loader.dismiss();
        }
        console.log(res.text());
        let jsonRes=res.json();
        if (jsonRes.status!=200){
            this.uiHelper.showMessageBox('Error',jsonRes.msg);
        }else{
            this.globals.currentUser.phone_verified="1";
            this.globals.setUser(this.globals.currentUser);
            this.navCtrl.setRoot(HomePage);
        }
    }

    loginFailure(error: any){
        console.log("loginFailure");
        if (this.loader!=null){
            this.loader.dismiss();
        }
        this.uiHelper.showMessageBox('Error',JSON.stringify(error));
    }

    doLogin(){
        let that=this;
        this.loader = this.loadingCtrl.create({
            content: "Please wait...",
        });
        this.loader.present();
        that.server.verifyCode({user_id: this.globals.currentUser.id,code: this.loginData.code}).subscribe(
            res=>that.loginSuccess(res),err=>that.loginFailure(err)
        );
    }
}
