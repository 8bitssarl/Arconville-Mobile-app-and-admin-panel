import { Component } from '@angular/core';
import { NavController,LoadingController, Events, Refresher,ModalController, Platform, AlertController, NavParams } from 'ionic-angular';
import { Response } from '@angular/http';
import { UiHelper } from '../../services/uihelper';
import { AppServer } from '../../services/appserver';
import { AppGlobals } from '../../services/appglobals';

@Component({
    selector: 'page-reservation',
    templateUrl: 'reservation.html'
})
export class ReservationPage {

    private loader:any = null;
    
    private items: any[] = [];
    private services: any[] = [];
    private hours:any[]=[];
    private seats:any[]=[];

    private minDate: string = '';
    private maxDate: string = '';

    private isEditing:boolean = false;

    private days:any[]=[];
    private times:any[]=[];

    constructor(public alertCtrl: AlertController, public modalCtrl: ModalController, public navCtrl: NavController,public events: Events,public loadingCtrl: LoadingController,public uiHelper: UiHelper,public server: AppServer,public globals: AppGlobals,public navParams: NavParams, public platform: Platform) {
        if (this.navParams.get('item')){
            this.isEditing=true;
            let it=this.navParams.get('item');
            let dt=new Date((it.start_ts)*1000);
            let xt={id: it.id,seats:1,service_id: it.service_id,num_hours:it.num_hours,start_ts:it.start_ts,date:this.uiHelper.getDateInIonic(dt),can_cancel: true};
            this.items.push(xt);
        }else{
            this.items.push({id:'0',seats:1,service_id:'0',date:this.uiHelper.getCurrentDateInIonic(),num_hours:'1',start_ts:'',can_cancel: false});
        }

        let dt=new Date();
        this.minDate=this.uiHelper.getDateInIonic(dt);
        let ts=dt.getTime();
        let day=dt.getDay(); //0 =sunday ....
        //if today is sunday
        if (day>0){
            let addDays=(6-day)+1;
            ts+=(1000*60*60*24*addDays);
            dt.setTime(ts);
        }
        dt.setHours(19);
        dt.setMinutes(0);
        this.maxDate=this.uiHelper.getDateInIonic(dt);

        for (let a=1;a<=2;a+=0.5){
            let txt=a.toString();
            this.hours.push({id: a,name: txt+' hr(s)'});
        }

        dt=new Date();
        dt.setHours(0,0,0);
        let currDate=dt.getDate();
        let currTs=dt.getTime();
        while(true){
            this.days.push({value: currDate,selected: false});
            //0=sunday
            if (dt.getDay()==0){
                break;
            }
            currTs+=(1000*60*60*24);
            dt.setTime(currTs);
            currDate=dt.getDate();
        }
        /*for (let a=currDate;;){
            this.days.push({value: a,selected: false});
        }*/

        for (let a=1;a<=10;a++){
            this.seats.push({value: a});
        }

        this.times.push({start:'08:00',end:'10:00',num_hours:2,reserved:false,selected:false});
        this.times.push({start:'10:00',end:'12:00',num_hours:2,reserved:false,selected:false});
        this.times.push({start:'12:00',end:'14:00',num_hours:2,reserved:false,selected:false});
        this.times.push({start:'14:00',end:'16:00',num_hours:2,reserved:false,selected:false});
        this.times.push({start:'16:00',end:'18:00',num_hours:2,reserved:false,selected:false});
        this.times.push({start:'18:00',end:'20:00',num_hours:2,reserved:false,selected:false});
    }

    ionViewDidLoad(){
        this.getServices();
    }

    servicesSuccess(res: Response){
        console.log("servicesSuccess");
        if (this.loader!=null){
            this.loader.dismiss();
        }
        let jsonRes=res.json();
        if (jsonRes.status!=200){
            this.uiHelper.showMessageBox('Error',jsonRes.msg);
        }else{
            let services=jsonRes.data;
            this.services=[];
            for (let a=0;a<services.length;a++){
                let srv=services[a];
                srv.selected=false;
                if (srv.can_book_online!=1)
                    continue;
                if (!srv.image_url || srv.image_url==''){
                    srv.image_url="https://www.gstatic.com/webp/gallery/1.jpg";
                    if (a==1){
                        srv.image_url="https://www.gstatic.com/webp/gallery/2.jpg";
                    }
                }else{
                    srv.image_url=this.server.BASE_URL+"../"+srv.image_url;
                }
                srv.background_image="url('"+srv.image_url+"')";
                this.services.push(srv);
            }
            if (this.services.length>0 && !this.isEditing){
                this.items[0].service_id=this.services[0].id;
            }
        }
    }

    servicesFailure(error: any){
        console.log("servicesFailure");
        if (this.loader!=null){
            this.loader.dismiss();
        }
        this.uiHelper.showMessageBox('Error',JSON.stringify(error));
    }

    getServices(){
        console.log("getServices");
        let that=this;
        this.loader = this.loadingCtrl.create({
            content: "Please wait...",
        });
        this.loader.present();
        let uid=this.globals.currentUser.id;
        that.server.getServices({user_id: uid}).subscribe(
            res=>that.servicesSuccess(res),err=>that.servicesFailure(err)
        );
    }

    addMoreClick(){
        console.log("addMoreClick");
        let it={id:'0',service_id:'0',date:this.uiHelper.getCurrentDateInIonic(),num_hours:'1',start_ts:'',can_cancel: false};
        if (this.services.length>0){
            it.service_id=this.services[0].id;
        }
        this.items.push(it);
    }

    saveClick(){
        console.log("saveClick");

        let rDay=-1;
        for (let a=0;a<this.days.length;a++){
            if (this.days[a].selected){
                rDay=this.days[a].value;
                break;
            }
        }
        if (rDay==-1){
            this.uiHelper.showMessageBox("Error","Please select date");
            return;
        }

        let rDate="";
        let numHours=0;
        for (let a=0;a<this.times.length;a++){
            if (this.times[a].selected){
                let dt=new Date();
                rDate=dt.getFullYear().toString();
                rDate+="-"+(dt.getMonth()+1).toString();
                rDate+="-"+rDay;
                rDate+="T"+this.times[a].start;
                numHours=this.times[a].num_hours;
                break;
            }
        }

        if (rDate==""){
            this.uiHelper.showMessageBox("Error","Please select time");
            return;
        }

        console.log(rDate);

        for (let a=0;a<this.items.length;a++){
            let it=this.items[a];
            //it.start_ts=this.uiHelper.getDbTimestampFromIonicDate(it.date);
            it.start_ts=this.uiHelper.getDbTimestampFromIonicDate(rDate);
            it.num_hours=numHours;
            this.items[a]=it;
        }
        console.log(this.items);
        this.loader = this.loadingCtrl.create({
            content: "Please wait...",
        });
        this.loader.present();
        let uid=this.globals.currentUser.id;
        let reservation_id='0';
        let latitude=0;
        let longitude=0;
        if (this.globals.currentLocation!=null){
            latitude=this.globals.currentLocation.latitude;
            longitude=this.globals.currentLocation.longitude;
        }
        this.server.saveReservation({reservation_id:reservation_id,user_id: uid,latitude:latitude,longitude: longitude,reservations: this.items}).subscribe(
            (res)=>{
                this.loader.dismiss();
                console.log(res.text());
                let jsonRes=res.json();
                if (jsonRes.status!=200){
                    this.uiHelper.showMessageBox("Error",jsonRes.msg);
                    return;
                }
                let alert=this.uiHelper.showMessageBox("","Reservation saved");
                let that=this;
                alert.onDidDismiss(()=>{
                    that.events.publish('reservation_saved');
                    that.navCtrl.pop();
                });
            },(err)=>{
                this.loader.dismiss();
                console.error(JSON.stringify(err));
                this.uiHelper.showMessageBox("Error",JSON.stringify(err));
            }
        );
    }

    dayClick(d){
        console.log("dayClick: "+d.value);
        d.selected=!d.selected;
        for (let x=0;x<this.days.length;x++){
            if (this.days[x].value!=d.value){
                this.days[x].selected=false;
            }
        }
    }

    timeClick(d){
        console.log("timeClick: "+d.start+":"+d.end);
        d.selected=!d.selected;
        for (let x=0;x<this.times.length;x++){
            if (this.times[x].start!=d.start || this.times[x].end!=d.end){
                this.times[x].selected=false;
            }
        }
    }

    serviceClick(s){
        console.log("serviceClick");
        for (let x=0;x<this.services.length;x++){
            this.services[x].selected=false;
        }
        s.selected=true;
        this.items[0].service_id=s.id;
    }
}
