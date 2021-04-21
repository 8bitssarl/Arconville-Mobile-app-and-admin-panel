import {Injectable} from "@angular/core";
import { AppServer } from './appserver';
import { Platform } from "ionic-angular";
import { UiHelper } from "./uihelper";

@Injectable() export class AppGlobals {

    public appName:string="ziad booking";
    public isTestMode:boolean = false;

    public cannotDetectLocation:boolean=false;
    public currentLocation:any = null;
    public currentUser:any=null;

    public packages:any[]=[];
    //public ongoingPackages:any[]=[];
    public packageServices:any[]=[];

    public userLanguage:string='en';
    
    constructor(public server: AppServer,public uiHelper: UiHelper,public platform: Platform){
    }

    tryRegisterDevice(){
        console.log("tryRegisterDevice");
        /*if (this.currentUser==null){
            console.error("Current user is null");
            return;
        }
        let token=this.getFirebaseToken();
        if (token==null){
            console.error("No firebase token");
            return;
        }
        let latitude=this.currentLocation==null?0:this.currentLocation.latitude;
        let longitude=this.currentLocation==null?0:this.currentLocation.longitude;
        //let latitude=53.402563800000000;
        //let longitude=-2.983376900000000;
        this.server.registerUser({token: token,latitude: latitude,longitude: longitude,user_type: this.currentUser.type,user_id: this.currentUser.id}).subscribe((res)=>{
            console.log(res.text());
            let json=res.json();
            if (json.status==200){
                this.setDeviceRegistered("1");
                if (this.currentUser.type=="customer"){
                    this.currentUser.id=json.user.id;
                }
                this.setUser(this.currentUser);
            }else{
                console.error(json.msg);
            }
        },(err)=>{
            console.error(JSON.stringify(err));
        })*/
    }

    public isValidEmail(email) {
        var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        return re.test(String(email).toLowerCase());
    }

    public getPasswordValidation(pwd){
        let vals={six_chars_long:false,has_letter:false,has_number:false};
        if (pwd.length>=6){
            vals.six_chars_long=true;
        }
        for (let a=0;a<pwd.length;a++){
            if ((pwd[a]>='a' && pwd[a]<='z') || (pwd[a]>='A' && pwd[a]<='Z')){
                vals.has_letter=true;
            }
            if ((pwd[a]>='0' && pwd[a]<='9')){
                vals.has_number=true;
            }
        }

        return vals;
    }

    public setUser(usr){
        (<any>window).localStorage.ziadBookingUser=JSON.stringify(usr);
    }

    public getUser(){
        let usr=(<any>window).localStorage.ziadBookingUser;
        if (usr){
            if (usr=="null"){
                return null;
            }
            return JSON.parse(usr);
        }
        return null;
    }

    public getFavorites(){
        let usr=(<any>window).localStorage.ziadBookingFavorites;
        if (usr){
            if (usr=="null"){
                usr=[];
            }else{
                usr=JSON.parse(usr);
            }
        }else{
            usr=[];
        }
        return usr;
    }

    public setFavorites(usr){
        (<any>window).localStorage.ziadBookingFavorites=JSON.stringify(usr);
    }

    public addToFavorite(ns){
        let favs=this.getFavorites();
        for (let a=0;a<favs.length;a++){
            if (favs[a].id==ns.id){
                favs.splice(a,1);
                break;
            }
        }
        favs.push(ns);
        this.setFavorites(favs);
    }
}