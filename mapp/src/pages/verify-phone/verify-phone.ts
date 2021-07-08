import { Component } from '@angular/core';
import { NavController, LoadingController } from 'ionic-angular';
import { Response } from '@angular/http';
import { UiHelper } from '../../services/uihelper';
import { AppServer } from '../../services/appserver';
import { AppGlobals } from '../../services/appglobals';
import { VerifyCodePage } from '../verify-code/verify-code';

@Component({
    selector: 'page-verify-phone',
    templateUrl: 'verify-phone.html'
})
export class VerifyPhonePage {

    private loginData:any={phone:''};
    private loader: any = null;

    constructor(public navCtrl: NavController,public loadingCtrl: LoadingController,public uiHelper: UiHelper,public server: AppServer,public globals: AppGlobals) {

    }

    loginClick(){
        console.log("loginClick");
        if(this.loginData.phone.trim()==""){
            let titleText=this.globals.getTranslatedText("Error");
            let messageText=this.globals.getTranslatedText("Please enter valid phone number");
            this.uiHelper.showMessageBox(titleText,messageText);
            return;
        }
        if(!this.loginData.phone.includes("+")){
            let titleText=this.globals.getTranslatedText("Error");
            let messageText=this.globals.getTranslatedText("Please Country Code before your number with plus sign");
            this.uiHelper.showMessageBox(titleText,messageText);
            return;
        }else{
            this.globals.phoneNumber=this.loginData.phone;
            this.server.sendCode(this.loginData.phone).subscribe(
                res=>this.getUser(res),err=>this.userFailure(err)
            );
        }
      
        // this.doLogin();
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
            alert("Your verification code is: "+jsonRes.data.code);
            this.globals.currentUser.phone_number=this.loginData.phone;
            this.globals.setUser(this.globals.currentUser);
            this.navCtrl.setRoot(VerifyCodePage);
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
        that.server.verifyPhone({user_id: this.globals.currentUser.id,phone: this.loginData.phone}).subscribe(
            res=>that.loginSuccess(res),err=>that.loginFailure(err)
        );
    }
    getUser(res: Response){
        console.log("Get User Data");
        if (this.loader!=null){
            this.loader.dismiss();
        }
        console.log(res.text());
        let jsonRes=res.json();
        if (jsonRes.status!=200){
            this.uiHelper.showMessageBox('Error',jsonRes.msg);
        }else{
            
          this.globals.path_sid=jsonRes.data;
          
this.navCtrl.push(VerifyCodePage);
        }
    }
  
    userFailure(error: any){
        console.log("loginFailure");
        if (this.loader!=null){
            this.loader.dismiss();
        }
        this.uiHelper.showMessageBox('Error',JSON.stringify(error));
    }
}
