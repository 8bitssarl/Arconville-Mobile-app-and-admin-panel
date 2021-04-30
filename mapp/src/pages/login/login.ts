import { Component } from '@angular/core';
import { NavController, LoadingController } from 'ionic-angular';
import { Response } from '@angular/http';
import { SignupPage } from '../signup/signup';
import { UiHelper } from '../../services/uihelper';
import { AppServer } from '../../services/appserver';
import { AppGlobals } from '../../services/appglobals';
import { ForgotPasswordPage } from '../forgot-password/forgot-password';
import { HomePage } from '../home/home';
import { VerifyPhonePage } from '../verify-phone/verify-phone';

@Component({
    selector: 'page-login',
    templateUrl: 'login.html'
})
export class LoginPage {

    private loginData:any={email:'',password:''};
    private loader: any = null;

    constructor(public navCtrl: NavController,public loadingCtrl: LoadingController,public uiHelper: UiHelper,public server: AppServer,public globals: AppGlobals) {

    }

    signupClick(){
        console.log("signupClick");
        this.navCtrl.push(SignupPage);
    }

    forgotPasswordClick(){
        console.log("forgotPasswordClick");
        this.navCtrl.push(ForgotPasswordPage);
    }

    loginClick(){
        if(this.loginData.email.trim()=="" || !this.globals.isValidEmail(this.loginData.email)){
            this.uiHelper.showMessageBox("Error","Please enter valid email address");
            return;
        }
        if (this.loginData.password.trim()==""){
            this.uiHelper.showMessageBox("Error","Please enter password");
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
            let user=jsonRes.data;
            this.globals.setUser(user);
            this.globals.currentUser=user;
            if (this.globals.currentUser.phoneVerified==null){
                this.navCtrl.setRoot(VerifyPhonePage);
            }else{
                this.navCtrl.setRoot(HomePage);
            }
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
        console.log("loginClick");
        let that=this;
        this.loader = this.loadingCtrl.create({
            content: this.globals.getTranslatedText("please_wait")+"...",
        });
        this.loader.present();
        that.server.login(this.loginData).subscribe(
            res=>that.loginSuccess(res),err=>that.loginFailure(err)
        );
    }

    closeMe(){
        this.navCtrl.pop();
    }

    //----------google+ login start -------------//

    googleLoginClick(){
        console.log("googleLoginClick");
        let that=this;
        try{
            (<any>window).plugins.googleplus.login(
                    {
                        'scopes': 'https://www.googleapis.com/auth/userinfo.profile https://www.googleapis.com/auth/userinfo.email',
                        'webClientId': '403854025194-od43ad2a8ekal6ngjpdvnvbrd78avj41.apps.googleusercontent.com',
                        'offline': false,
                    },
                    function (obj) {
                        try{
                            //alert(JSON.stringify(obj)); // do something useful instead of alerting
                            that.doLoginToGoogle(obj);
                        }catch(ex){
                            that.uiHelper.showMessageBox("Exception",'in google success: ' + ex.message);
                        }
                    },
                    function (msg) {
                        if (msg=='12501'){
                            return;
                        }
                        that.uiHelper.showMessageBox("Error",'Error in googleplus.login: ' + msg);
                    }
            );
        }catch(e){
            that.uiHelper.showMessageBox("Exception",e.message);
        }
    }

    createGoogleLoginData(fbUser){
        let imageUrl=fbUser.imageUrl;
        let name=fbUser.givenName+" "+fbUser.familyName;
        let registerData={facebook_profile_id:fbUser.userId,name:name,email: fbUser.email,username: fbUser.email,password:'',image_url: imageUrl};
        return registerData;
    }

    doLoginToGoogle(gUser:any){
        try{
            let that=this;
            let registerData=that.createGoogleLoginData(gUser);
            that.loader = that.loadingCtrl.create({
                content: this.globals.getTranslatedText("please_wait")+"...",
            });
            that.loader.present();
            that.server.register(registerData).subscribe(
                res=>that.loginSuccess(res),err=>that.loginFailure(err)
            );
        }catch(e){
            alert("Exception doLoginToGoogle: "+e.message);
        }
    }

    //----------google login end -------------//
}
