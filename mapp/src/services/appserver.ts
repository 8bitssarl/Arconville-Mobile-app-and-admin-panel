/* * * ./app/comments/services/comment.service.ts * * */
// Imports
import { Injectable,ReflectiveInjector } from '@angular/core';
import { Http, Response, Headers, RequestOptions,BaseRequestOptions} from '@angular/http';
import { XHRBackend,BrowserXhr } from '@angular/http';
import { ResponseOptions,BaseResponseOptions,ConnectionBackend } from '@angular/http';
import { XSRFStrategy,CookieXSRFStrategy } from '@angular/http';

//import {Observable} from 'rxjs/Rx';
//Import RxJs required methods
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Injectable()
export class AppServer {
    
    public BASE_URL="https://localhost:44322/api/";
    //public BASE_URL="http://eightbitssarl-001-site1.atempurl.com/api/";
    //public BASE_URL="http://ziadabboud-001-site1.itempurl.com/api/";
    
    constructor (private http: Http) {}

    getImageSaveUrl(){
        return this.BASE_URL+"user/profileimage";
    }

    register(registerData) {
    	console.log("register");
        let bodyString = "name="+encodeURIComponent(registerData.name)
        bodyString+="&email="+encodeURI(registerData.email);
        bodyString+="&image_url="+encodeURI(registerData.image_url);
        bodyString+="&password="+encodeURI(registerData.password);
        bodyString+="&age="+encodeURI(registerData.age);
        bodyString+="&dob_month="+encodeURI(registerData.dob_month);
        bodyString+="&dob_day="+encodeURI(registerData.dob_day);
        bodyString+="&dob_year="+encodeURI(registerData.dob_year);
        bodyString+="&gender="+encodeURI(registerData.gender);
        bodyString+="&facebook_profile_id="+encodeURI(registerData.facebook_profile_id);
        console.log(bodyString);
        let headers = new Headers({ 'Content-Type': 'application/x-www-form-urlencoded' });
        let options = new RequestOptions({ headers: headers });
        let url=this.BASE_URL+"user";
        return this.http.put(url, bodyString, options);
    }

    login(loginData) {
    	console.log("login");
        let bodyString = "username="+encodeURI(loginData.email);
        bodyString+="&password="+encodeURI(loginData.password);
        console.log(bodyString);
        let headers = new Headers({ 'Content-Type': 'application/x-www-form-urlencoded' });
        let options = new RequestOptions({ headers: headers });
        let url=this.BASE_URL+"user/login";
        return this.http.post(url, bodyString, options);
    }

    verifyPhone(loginData) {
    	console.log("verifyPhone");
        let bodyString = "user_id="+encodeURI(loginData.user_id);
        bodyString+="&phone="+encodeURI(loginData.phone);
        console.log(bodyString);
        let headers = new Headers({ 'Content-Type': 'application/x-www-form-urlencoded' });
        let options = new RequestOptions({ headers: headers });
        let url=this.BASE_URL+"user/verifyphone";
        return this.http.post(url, bodyString, options);
    }

    verifyCode(loginData) {
    	console.log("verifyCode");
        let bodyString = "user_id="+encodeURI(loginData.user_id);
        bodyString+="&code="+encodeURI(loginData.code);
        console.log(bodyString);
        let headers = new Headers({ 'Content-Type': 'application/x-www-form-urlencoded' });
        let options = new RequestOptions({ headers: headers });
        let url=this.BASE_URL+"user/verifycode";
        return this.http.post(url, bodyString, options);
    }

    forgotPassword(loginData) {
    	console.log("forgotPassword");
        let bodyString = "email="+encodeURI(loginData.email);
        console.log(bodyString);
        let headers = new Headers({ 'Content-Type': 'application/x-www-form-urlencoded' });
        let options = new RequestOptions({ headers: headers });
        let url=this.BASE_URL+"forgot_password.php";
        return this.http.post(url, bodyString, options);
    }

    getHomeFeed(data){
        console.log("getHomeFeed");
        let url=this.BASE_URL+"user/home";
        url+="?user_id="+encodeURI(data.user_id);
        console.log(url);
        let headers = new Headers({ });
        let options = new RequestOptions({ headers: headers });
        return this.http.get(url,options);
    }

    getServices(data){
        console.log("getServices");
        let url=this.BASE_URL+"reservation/";
        console.log(url);
        let headers = new Headers({ });
        let options = new RequestOptions({ headers: headers });
        return this.http.get(url,options);
    }

    saveReservation(registerData) {
    	console.log("saveReservation");
        let bodyString = "reservation_id="+encodeURIComponent(registerData.reservation_id)
        bodyString+="&user_id="+encodeURIComponent(registerData.user_id);
        bodyString+="&latitude="+encodeURIComponent(registerData.latitude);
        bodyString+="&longitude="+encodeURIComponent(registerData.longitude);
        let items=registerData.reservations;
        bodyString+="&reservation_count="+encodeURIComponent(items.length);
        for (let x=0;x<items.length;x++){
            bodyString+="&reservation["+x.toString()+"][id]="+encodeURIComponent(items[x].id);
            bodyString+="&reservation["+x.toString()+"][service_id]="+encodeURIComponent(items[x].service_id);
            bodyString+="&reservation["+x.toString()+"][start_ts]="+encodeURIComponent(items[x].start_ts);
            bodyString+="&reservation["+x.toString()+"][num_hours]="+encodeURIComponent(items[x].num_hours);
        }
        console.log(bodyString);
        let headers = new Headers({ 'Content-Type': 'application/x-www-form-urlencoded' });
        let options = new RequestOptions({ headers: headers });
        let url=this.BASE_URL+"reservation";
        return this.http.put(url, bodyString, options);
    }

    getFamily(data){
        console.log("getFamily");
        let url=this.BASE_URL+"user/family";
        url+="?user_id="+encodeURI(data.user_id);
        console.log(url);
        let headers = new Headers({ });
        let options = new RequestOptions({ headers: headers });
        return this.http.get(url,options);
    }

    addToFamily(registerData) {
    	console.log("addToFamily");
        let bodyString = "phone="+encodeURIComponent(registerData.phone)
        bodyString+="&name="+encodeURIComponent(registerData.name);
        bodyString+="&user_id="+encodeURIComponent(registerData.user_id);
        console.log(bodyString);
        let headers = new Headers({ 'Content-Type': 'application/x-www-form-urlencoded' });
        let options = new RequestOptions({ headers: headers });
        let url=this.BASE_URL+"user/addtofamily";
        return this.http.post(url, bodyString, options);
    }

    actionToFamily(registerData) {
    	console.log("actionToFamily");
        let bodyString = "user_id2="+encodeURIComponent(registerData.user_id2)
        bodyString+="&user_id="+encodeURIComponent(registerData.user_id);
        bodyString+="&action="+encodeURIComponent(registerData.action);
        console.log(bodyString);
        let headers = new Headers({ 'Content-Type': 'application/x-www-form-urlencoded' });
        let options = new RequestOptions({ headers: headers });
        let url=this.BASE_URL+"user/actiontofamily";
        return this.http.post(url, bodyString, options);
    }

    updateProfile(registerData) {
    	console.log("updateProfile");
        let bodyString = "name="+encodeURIComponent(registerData.name)
        bodyString+="&email="+encodeURI(registerData.email);
        bodyString+="&image_url="+encodeURI(registerData.image_url);
        bodyString+="&password="+encodeURI(registerData.password);
        bodyString+="&age="+encodeURI(registerData.age);
        bodyString+="&dob_month="+encodeURI(registerData.dob_month);
        bodyString+="&dob_day="+encodeURI(registerData.dob_day);
        bodyString+="&dob_year="+encodeURI(registerData.dob_year);
        bodyString+="&gender="+encodeURI(registerData.gender);
        bodyString+="&is_family="+encodeURI(registerData.is_family);
        bodyString+="&id="+encodeURI(registerData.id);
        console.log(bodyString);
        let headers = new Headers({ 'Content-Type': 'application/x-www-form-urlencoded' });
        let options = new RequestOptions({ headers: headers });
        let url=this.BASE_URL+"user";
        return this.http.post(url, bodyString, options);
    }

    cancelReservation(registerData) {
    	console.log("cancelReservation");
        let bodyString = "user_id="+encodeURIComponent(registerData.user_id)
        bodyString+="&reservation_id="+encodeURI(registerData.reservation_id);
        console.log(bodyString);
        let headers = new Headers({ 'Content-Type': 'application/x-www-form-urlencoded' });
        let options = new RequestOptions({ headers: headers });
        let url=this.BASE_URL+"reservation/cancel";
        return this.http.post(url, bodyString, options);
    }

    getPackages(data){
        console.log("getPackages");
        let url=this.BASE_URL+"reservation/packages?user_id="+data.user_id;
        console.log(url);
        let headers = new Headers({ });
        let options = new RequestOptions({ headers: headers });
        return this.http.get(url,options);
    }

    subscribePackage(registerData) {
    	console.log("subscribePackage");
        let bodyString = "package_id="+encodeURIComponent(registerData.package_id)
        bodyString+="&user_id="+encodeURIComponent(registerData.user_id);
        console.log(bodyString);
        let headers = new Headers({ 'Content-Type': 'application/x-www-form-urlencoded' });
        let options = new RequestOptions({ headers: headers });
        let url=this.BASE_URL+"reservation/subscribepackage";
        return this.http.post(url, bodyString, options);
    }
}