import { Component } from '@angular/core';
import { NavController,LoadingController,ActionSheetController,ModalController } from 'ionic-angular';
import { Response } from '@angular/http';
import { UiHelper } from '../../services/uihelper';
import { AppServer } from '../../services/appserver';
import { AppGlobals } from '../../services/appglobals';
import { DomSanitizer } from '@angular/platform-browser';
import { FileTransfer, FileUploadOptions, FileTransferObject } from '@ionic-native/file-transfer';
import { File } from '@ionic-native/file';
import { FilePath } from '@ionic-native/file-path';
import { Camera, CameraOptions } from '@ionic-native/camera';
import { HomePage } from '../home/home';
import { VerifyPhonePage } from '../verify-phone/verify-phone';

@Component({
    selector: 'page-signup',
    templateUrl: 'signup.html'
})
export class SignupPage {

    private loginData:any={name:'',email:'',password:'',age:'',dob_month:'1',dob_day:'1',dob_year:'2002',gender:'m',image_url:'',facebook_profile_id:'',is_toc_agree: true};
    private loader: any = null;

    private fileTransfer: FileTransferObject = null;
    private attachedImages:any[]=[];
    private currentUploadIndex: number = 0;
    private profileImageUrl:string='';

    private dobMonths:any[]=[];
    private dobDays:any[]=[];
    private dobYears:any[]=[];
    private genders:any[]=[];
    private monthNames:any[]=["Jan","Feb","Mar","Apr","May","Jun","Jul","Aug","Sep","Oct","Nov","Dec"];

    constructor(public modalCtrl: ModalController, public navCtrl: NavController,public loadingCtrl: LoadingController,public actionSheetCtrl: ActionSheetController,private camera: Camera, private transfer: FileTransfer, private file: File, private filePath: FilePath, private sanitizer:DomSanitizer,public uiHelper: UiHelper,public server: AppServer,public globals: AppGlobals) {
        this.attachedImages=[];
        this.fileTransfer=this.transfer.create();

        for (let a=0;a<12;a++){
            this.dobMonths.push({name: this.monthNames[a],value: (a+1).toString()});
        }

        for (let a=0;a<31;a++){
            this.dobDays.push({name: (a+1).toString(),value: (a+1).toString()});
        }

        let currYear=new Date().getFullYear();

        for (let a=currYear-100;a<=currYear-12;a++){
            this.dobYears.push({name: (a).toString(),value: (a).toString()});
        }
        this.loginData.dob_year=(currYear-18).toString();

        this.genders.push({name: 'Male',value: 'm'});
        this.genders.push({name: 'Female',value: 'f'});
    }

    ionViewDidLoad(){
    }

    sanitize(url:string){
        return this.sanitizer.bypassSecurityTrustUrl(url);
    }

    tocAgreeChanged(){
        if (this.loginData.is_toc_agree){
            //let mdl=this.modalCtrl.create(TocPage,{});
            //mdl.present();
        }
    }

    signupClick(){
        console.log("signupClick");
        if(this.loginData.name.trim()==""){
            this.uiHelper.showMessageBox("Error","Please enter name");
            return;
        }
        if(this.loginData.email.trim()=="" || !this.globals.isValidEmail(this.loginData.email)){
            this.uiHelper.showMessageBox("Error","Please enter valid email address");
            return;
        }
        if(this.loginData.password.trim()==""){
            this.uiHelper.showMessageBox("Error","Please enter password");
            return;
        }
        if (!this.loginData.is_toc_agree){
            this.uiHelper.showMessageBox("Error","You must accept our Privacy Statement");
            return;
        }
        let selYear=parseInt(this.loginData.dob_year);
        let currYear=new Date().getFullYear();
        this.loginData.age=(currYear-selYear).toString();
        if (this.attachedImages.length>0){
            this.currentUploadIndex=0;
            this.uploadAttachedImage();
        }else{
            this.doSignup();
        }
    }

    signupSuccess(res: Response){
        console.log("signupSuccess");
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
            if (this.globals.currentUser.phone_verified==null){
                this.navCtrl.setRoot(VerifyPhonePage);
            }else{
                this.navCtrl.setRoot(HomePage);
            }
        }
    }

    signupFailure(error: any){
        console.log("loginFailure");
        if (this.loader!=null){
            this.loader.dismiss();
        }
        this.uiHelper.showMessageBox('Error',JSON.stringify(error));
    }

    doSignup(){
        console.log("doSignup");
        let that=this;
        this.loader = this.loadingCtrl.create({
            content: this.globals.getTranslatedText("please_wait")+"...",
        });
        this.loader.present();
        that.server.register(this.loginData).subscribe(
            res=>that.signupSuccess(res),err=>that.signupFailure(err)
        );
    }

    closeMe(){
        this.navCtrl.pop();
    }

    profilePicClick(){
        let that=this;
        let actionSheet = this.actionSheetCtrl.create({
            title: 'Select image from',
            buttons: [
                {
                    text: 'Camera',
                    handler: () => {
                        console.log('Camera clicked');
                        that.attachImage(2);
                    }
                },
                {
                    text: 'Gallery',
                    handler: () => {
                        console.log('Gallery clicked');
                        that.attachImage(3);
                    }
                },
                {
                    text: this.globals.getTranslatedText("cancel"),
                    role: 'cancel',
                    handler: () => {
                        console.log('Cancel clicked');
                    }
                }
            ]
        });

        actionSheet.present();
    }

    //picture attach

    setPhotoFilePath(filePath){
        this.attachedImages.push(filePath);
        this.profileImageUrl=filePath;
    }

    onPhotoURISuccess(imageURI) {
        console.log("onPhotoURISuccess: "+imageURI);
        try{
            if (this.attachedImages.length>0){
                this.attachedImages.splice(0,this.attachedImages.length);
            }
            let that=this;
            this.filePath.resolveNativePath(imageURI)
                .then(filePath => that.setPhotoFilePath(filePath))
                .catch(err => alert("Error: "+JSON.stringify(err)));
        }catch(e){
            this.uiHelper.showMessageBox("Exception",e.message);
        }
    }

    onPhotoURIFail(message) {
        this.uiHelper.showMessageBox("onPhotoURIFail",message);
    }
    
    attachImage(val){
        let that=this;
        if (val===2 || val===3){
	        let camOptions={
                quality: 80,
                sourceType:0,
                destinationType: this.camera.DestinationType.FILE_URI,
                encodingType: this.camera.EncodingType.JPEG,
                saveToPhotoAlbum: false,
                correctOrientation: true,
                targetWidth: 320,
                targetHeight: 320
            };

            try{
                if (val===2){
                    //camera capture
                    camOptions.sourceType=this.camera.PictureSourceType.CAMERA;
                }else if (val===3){
                    //photo library
                    camOptions.sourceType=this.camera.PictureSourceType.PHOTOLIBRARY;
                    camOptions.correctOrientation=false;
                }
                this.camera.getPicture(camOptions).then((imageData) => {
                        that.onPhotoURISuccess(imageData);
                    }, (err) => {
                        that.onPhotoURIFail(err);
                    }
                );
            }catch(e){
                this.uiHelper.showMessageBox("Exception",e.message);
            }
        }
    }

    //picture attach end

    //picture upload

    uploadSuccess(resp){
        if (this.loader!=null){
            this.loader.dismiss();
        }
        this.currentUploadIndex++;
        let response=JSON.parse(resp.response);
        this.profileImageUrl=response.url;
        this.loginData.image_url=this.profileImageUrl;
        this.doSignup();
    }

    uploadError(error){
        if (this.loader!=null){
            this.loader.dismiss();
        }
        this.uiHelper.showMessageBox("Upload Error","An error has occurred in image: Code = " + error.code);
    }

    uploadAttachedImage(){

        console.log("uploadAttachedImage");

        let that=this;

        let currFileName=that.attachedImages[that.currentUploadIndex];
        
        let options = {fileKey:'',fileName:'',mimeType:'',chunkedMode:false,headers:{},params:{},httpMethod:'POST'};
        options.fileKey = "media_file";
        if(currFileName.toLowerCase().endsWith('.png')){
            options.fileName="test.png";
            options.mimeType = "image/png";
        }else{
            options.fileName = "test.jpg";
            options.mimeType = "image/jpeg";
        }
        options.chunkedMode = false;
        options.headers = {
            Connection: "close"
        };

        let params = {};
        options.params = params;

        this.loader = this.loadingCtrl.create({
            content: "Uploading profile picture...",
        });
        this.loader.present();

        try{
        that.fileTransfer.upload(that.attachedImages[that.currentUploadIndex], that.server.getImageSaveUrl(),options)
            .then((data) => {
                that.uploadSuccess(data);
            }, (err) => {
                that.uploadError(err);
            }).catch(e => {
                that.loader.dismiss();
                that.uiHelper.showMessageBox("Exception","Error in upload: "+e.message);
            })
        }catch(e){
            that.loader.dismiss();
            that.uiHelper.showMessageBox("Exception",e.message);
        }
    }

    //picture upload end
}
