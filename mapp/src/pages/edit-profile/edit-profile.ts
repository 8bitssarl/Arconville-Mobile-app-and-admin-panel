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

@Component({
    selector: 'page-edit-profile',
    templateUrl: 'edit-profile.html'
})
export class EditProfilePage {

    private loginData:any={id:0,name:'',email:'',password:'',age:'',dob_month:'',dob_day:'',dob_year:'',gender:'m',profile_pic_url:'',image_url:'',is_family_bool:false,is_family:0};
    private loader: any = null;

    private fileTransfer: FileTransferObject = null;
    private attachedImages:any[]=[];
    private currentUploadIndex: number = 0;

    private dobMonths:any[]=[];
    private dobDays:any[]=[];
    private dobYears:any[]=[];
    private genders:any[]=[];
    private monthNames:any[]=["Jan","Feb","Mar","Apr","May","Jun","Jul","Aug","Sep","Oct","Nov","Dec"];
    private userData:any={email:'',password:''};
    constructor(public modalCtrl: ModalController, public navCtrl: NavController,public loadingCtrl: LoadingController,public actionSheetCtrl: ActionSheetController,private camera: Camera, private transfer: FileTransfer, private file: File, private filePath: FilePath, private sanitizer:DomSanitizer,public uiHelper: UiHelper,public server: AppServer,public globals: AppGlobals) {

      let that=this;
      let usr=this.globals.currentUser;
      this.loader = this.loadingCtrl.create({
        content: this.globals.getTranslatedText("please_wait")+"...",
    });
    that.server.getUserDetails(usr).subscribe(
      res=>that.getUser(res),err=>that.userFailure(err)
  );
      this.attachedImages=[];
        this.fileTransfer=this.transfer.create();




        this.loginData.is_family=usr.canAddMember;
        this.loginData.age=usr.age;
        if (this.loginData.is_family==1){
            this.loginData.is_family_bool=true;
        }

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
        let selYear=parseInt(this.loginData.dob_year);
        let currYear=new Date().getFullYear();
        this.loginData.age=(currYear-selYear).toString();
        this.loginData.is_family=0;
        this.loginData.is_family_bool=(currYear-selYear)>=18;
        if (this.loginData.is_family_bool){
            this.loginData.is_family=1;
        }
        if (this.attachedImages.length>0){
            this.currentUploadIndex=0;
            this.uploadAttachedImage();
        }else{
            this.doSignup();
        }
    }

    profileSuccess(res: Response){
        console.log("profileSuccess");
        if (this.loader!=null){
            this.loader.dismiss();
        }
        console.log(res.text());
        let jsonRes=res.json();
        if (jsonRes.status!=200){
            this.uiHelper.showMessageBox('Error',jsonRes.msg);
        }else{

            let user=jsonRes.data;
            this.globals.currentUser=user;
            this.globals.setUser(user);
            this.uiHelper.showMessageBox("","Profile updated successfully.");
        }
    }

    profileFailure(error: any){
        console.log("profileFailure");
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
        that.server.updateProfile(this.loginData).subscribe(
            res=>that.profileSuccess(res),err=>that.profileFailure(err)
        );
    }

    closeMe(){
        this.navCtrl.pop();
    }

    profilePicClick(){
        let that=this;
        let actionSheet = this.actionSheetCtrl.create({
            title: '',
            buttons: [
                {
                    text: this.globals.getTranslatedText("camera"),
                    handler: () => {
                        console.log('Camera clicked');
                        that.attachImage(2);
                    }
                },
                {
                    text: this.globals.getTranslatedText("gallery"),
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
        this.loginData.profile_pic_url=filePath;
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
        if (response.status==200){
            this.loginData.profile_pic_url=this.server.BASE_URL+"../"+response.data.url;
            this.loginData.image_url=response.data.url;
            this.doSignup();
        }else{
            this.uiHelper.showMessageBox("Error",response.msg);
        }
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
          let user=jsonRes.data;

          this.globals.setUser(user);
          this.globals.currentUser=user;
          let usr=this.globals.currentUser;
          this.loginData.id=usr.id;
          this.loginData.name=usr.name;
          this.loginData.email=usr.email;
          this.loginData.image_url=usr.profilePicUrl;
          this.loginData.age=usr.age;

          var dt = new Date(usr.dateOfBirth);
          this.loginData.dob_month=dt.getMonth();
          this.loginData.dob_day=dt.getDay();
          this.loginData.dob_year=dt.getFullYear();
          // :'',dob_day:'',dob_year:''
          // dt.getMonth();
          if (usr.profilePicUrl!=''){
            this.loginData.profile_pic_url=this.server.BASE_URL+"../"+usr.profilePicUrl;
        }
      }
  }

  userFailure(error: any){
      console.log("loginFailure");
      if (this.loader!=null){
          this.loader.dismiss();
      }
      this.uiHelper.showMessageBox('Error',JSON.stringify(error));
  }

    //picture upload end
}
