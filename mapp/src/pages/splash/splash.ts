import { Component,NgZone } from '@angular/core';
import { NavController, Events, Platform } from 'ionic-angular';
import { Response } from '@angular/http';
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
            /*setTimeout(function(){
                that.moveForward();
            },2000);*/
            //load packages
            this.getStores();
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

    storesSuccess(res: Response){
        console.log("storesSuccess");
        let jsonRes=res.json();
        if (jsonRes.status!=200){
            this.uiHelper.showMessageBox('Error',jsonRes.msg);
        }else{
            this.globals.packages=[];
            this.globals.packageServices=[];
            let items=jsonRes.data.upcoming;
            for (let a=0;a<items.length;a++){
                let st=items[a];
                st.is_upcoming=true;
                st.date_display_text="";
                st.exp_display_text="";
                if (!st.image_url || st.image_url==''){
                    st.image_url="https://www.gstatic.com/webp/gallery/1.jpg";
                    if (a==1){
                        st.image_url="https://www.gstatic.com/webp/gallery/2.jpg";
                    }
                }
                st.background_image="url('"+st.image_url+"')";
                this.globals.packages.push(st);
            }
            items=jsonRes.data.previous;
            for (let a=0;a<items.length;a++){
                let st=items[a];
                st.is_upcoming=false;
                st.date_display_text=this.uiHelper.getMealDisplayOnlyDate(st.start_ts*1000,new Date().getTime());
                st.exp_display_text=this.uiHelper.getMealDisplayOnlyDate(st.exp_ts*1000,new Date().getTime());
                if (!st.image_url || st.image_url==''){
                    st.image_url="https://www.gstatic.com/webp/gallery/1.jpg";
                    if (a==1){
                        st.image_url="https://www.gstatic.com/webp/gallery/2.jpg";
                    }
                }
                st.background_image="url('"+st.image_url+"')";
                this.globals.packages.push(st);
            }
            items=jsonRes.data.services;
            for (let a=0;a<items.length;a++){
                let st=items[a];
                this.globals.packageServices.push(st);
            }
            this.moveForward();
        }
    }

    storesFailure(error: any){
        console.log("storesFailure");
        this.uiHelper.showMessageBox('Error',JSON.stringify(error));
    }

    getStores(){
        console.log("getStores");
        let that=this;
        let uid=this.globals.currentUser.id;
        that.server.getPackages({user_id: uid}).subscribe(
            res=>that.storesSuccess(res),err=>that.storesFailure(err)
        );
    }
}
