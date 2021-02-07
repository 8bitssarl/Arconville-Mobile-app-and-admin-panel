import { Component,NgZone } from '@angular/core';
import { NavController, Events, Platform } from 'ionic-angular';
import { LoginPage } from '../login/login';
import { AppGlobals } from '../../services/appglobals';
import { Geolocation } from '@ionic-native/geolocation';
import { AppServer } from '../../services/appserver';
import { UiHelper } from '../../services/uihelper';
import { HomePage } from '../home/home';
import { VerifyPhonePage } from '../verify-phone/verify-phone';

@Component({
    selector: 'page-splash',
    templateUrl: 'splash.html'
})
export class SplashPage {

    private showGetStartedButton:boolean = false;

    constructor(public zone: NgZone, public platform: Platform, public navCtrl: NavController,public events: Events,public globals: AppGlobals,public geolocation: Geolocation,public server: AppServer,public uiHelper: UiHelper) {
        //this.globals.setUser(null);
        this.globals.currentUser=this.globals.getUser();
        this.showGetStartedButton=this.globals.currentUser==null;
    }

    ionViewDidLoad(){
        let that=this;
        that.doLocationThing();
        that.hasCalendarReadWritePermissions();
        if (!this.showGetStartedButton){
            setTimeout(function(){
                that.moveForward();
            },2000);
        }
    }

    moveForward(){
        let that=this;
        if (that.globals.currentUser!=null){
            console.log(JSON.stringify(that.globals.currentUser));
            if (that.globals.currentUser.phoneVerified==null){
                that.navCtrl.setRoot(VerifyPhonePage);
            }else{
                that.navCtrl.setRoot(HomePage);
            }
        }else{
            that.navCtrl.setRoot(LoginPage);
        }
    }

    locationChanged(data){
        console.log("locationChanged: "+JSON.stringify(data));
        let that=this;
        that.globals.currentLocation=data.coords;
        that.events.publish('location_changed');
    }

    doLocationThing(){
        let that=this;
        setTimeout(function(){
            try{
                (<any>window).navigator.geolocation.getCurrentPosition(function(data){
                    console.log("Location: "+data.coords.latitude+","+data.coords.longitude);
                    that.locationChanged(data);
                },function(error){
                    console.error("Error getting location: "+JSON.stringify(error));
                    //permission denied
                    if (error.code==1){
                        if (that.platform.is('android')){
                            let ddl=that.uiHelper.showConfirmBox3("",that.globals.appName+" is unable to work without location services","Ok",()=>{
                            });
                            ddl.onDidDismiss(()=>{
                                that.globals.cannotDetectLocation=true;
                                that.events.publish('location_permission_denied');
                            });
                        }else{
                            let ddl=that.uiHelper.showConfirmBox3("",that.globals.appName+" requires location access to function","Ok",()=>{
                            });
                            ddl.onDidDismiss(()=>{
                                that.globals.cannotDetectLocation=true;
                                that.events.publish('location_permission_denied');
                            });
                        }
                        
                    }else{
                        that.doLocationThing();
                    }
                },{ timeout: 10000, enableHighAccuracy: true });
            }catch(e){
                console.log("Error: "+e.message);
                that.uiHelper.showMessageBox("","Exception doLocationThing: "+e.message);
            }
        },1500);
    }

    //again, this is no longer needed with plugin version 4.5.0 and up
    private hasCalendarReadWritePermissions() {
        console.log("hasCalendarReadWritePermissions");
        let that=this;
        try{
            (<any>window).plugins.calendar.hasReadWritePermission(
                function(result) {
                    if (!result){
                        console.error("No permission");
                        that.requestCalendarReadWritePermission();
                    }else{
                        console.log("has permission");
                    }
                }
            )
        }catch(e){
            console.error(e.message);
        }
    }

    private requestCalendarReadWritePermission() {
        console.log("requestCalendarReadWritePermission")
        try{
            (<any>window).plugins.calendar.requestReadWritePermission();
        }catch(e){
            console.error(e.message);
        }
    }
}
