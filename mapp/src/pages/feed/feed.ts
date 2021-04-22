import { Component } from '@angular/core';
import { NavController,LoadingController, Events, Refresher,ModalController, Platform, AlertController, NavParams, ActionSheetController } from 'ionic-angular';
import { Response } from '@angular/http';
import { UiHelper } from '../../services/uihelper';
import { AppServer } from '../../services/appserver';
import { AppGlobals } from '../../services/appglobals';
import { ReservationPage } from '../reservation/reservation';
import { ReservationDetailPage } from '../reservation-detail/reservation-detail';

@Component({
    selector: 'page-feed',
    templateUrl: 'feed.html'
})
export class FeedPage {

    private loader:any = null;
    private refresher: Refresher = null;
    
    private allItems:any[] = [];
    private items: any[] = [];
    private feedType: string = 'upcoming';

    private myself: any = null;

    private savedEvent:any=null;

    constructor(public alertCtrl: AlertController, public modalCtrl: ModalController, public navCtrl: NavController,public events: Events,public loadingCtrl: LoadingController,public uiHelper: UiHelper,public server: AppServer,public globals: AppGlobals,public navParams: NavParams, public platform: Platform,public actionSheetCtrl: ActionSheetController) {
        this.myself=this;
        this.savedEvent=()=>{
            console.log("reservation_saved");
            this.getStores();
        };
        this.events.subscribe('reservation_saved',this.savedEvent);
    }

    ionViewDidLoad(){
        this.getStores();
    }

    ionViewWillUnload(){
        console.log("willunload");
        this.events.unsubscribe('reservation_saved',this.savedEvent);
        this.savedEvent=null;
    }

    doRefresh(evt){
        console.log("doRefresh");
        this.refresher=evt;
        this.getStores(false);
    }

    feedTypeChanged(evt){
        console.log("feedTypeChanged: "+this.feedType);
        this.filterItems();
    }

    processIndividualItem(st,allFavs=[]){
        st.is_favorited=false;
        for (let b=0;b<allFavs.length;b++){
            if (allFavs[b].id==st.id){
                st.is_favorited=true;
                break;
            }
        }
        return st;
    }

    filterItems(){
        console.log("filterItems");
        this.items=[];
        let allFavs=this.globals.getFavorites();
        for (let a=0;a<this.allItems.length;a++){
            let st=JSON.parse(JSON.stringify(this.allItems[a]));
            if (this.feedType=="upcoming" && !st.is_upcoming){
                continue;
            }else if (this.feedType=="previous" && st.is_upcoming){
                continue;
            }
            st=this.processIndividualItem(st,allFavs);
            this.items.push(st);
        }
    }

    storesSuccess(res: Response){
        console.log("storesSuccess");
        if (this.loader!=null){
            this.loader.dismiss();
        }
        if (this.refresher!=null){
            this.refresher.complete();
        }
        let jsonRes=res.json();
        if (jsonRes.status!=200){
            this.uiHelper.showMessageBox('Error',jsonRes.msg);
        }else{
            this.items=[];
            this.allItems=[];
            let items=jsonRes.data.upcoming;
            for (let a=0;a<items.length;a++){
                let st=items[a];
                st.is_upcoming=true;
                st.date_display_text=this.uiHelper.getMealDisplayDate(st.start_ts*1000,new Date().getTime());
                st.time_display_text=this.uiHelper.getMinutesRemainingStr(st.start_ts*1000).text;
                if (!st.image_url || st.image_url==''){
                    st.image_url="https://www.gstatic.com/webp/gallery/1.jpg";
                    if (a==1){
                        st.image_url="https://www.gstatic.com/webp/gallery/2.jpg";
                    }
                }else{
                    st.image_url=this.server.BASE_URL+"../"+st.image_url;
                }
                this.allItems.push(st);
            }
            items=jsonRes.data.previous;
            for (let a=0;a<items.length;a++){
                let st=items[a];
                st.is_upcoming=false;
                st.date_display_text=this.uiHelper.getMealDisplayDate(st.start_ts*1000,new Date().getTime());
                st.time_display_text=this.uiHelper.getMinutesAgoStr(st.start_ts*1000).text;
                if (!st.image_url || st.image_url==''){
                    st.image_url="https://www.gstatic.com/webp/gallery/1.jpg";
                    if (a==1){
                        st.image_url="https://www.gstatic.com/webp/gallery/2.jpg";
                    }
                }else{
                    st.image_url=this.server.BASE_URL+"../"+st.image_url;
                }
                this.allItems.push(st);
            }
            /*for (let x=0;x<10;x++){
                this.allItems.push(this.allItems[0]);
            }*/
            this.filterItems();
        }
    }

    storesFailure(error: any){
        console.log("storesFailure");
        if (this.loader!=null){
            this.loader.dismiss();
        }
        if (this.refresher!=null){
            this.refresher.complete();
        }
        this.uiHelper.showMessageBox('Error',JSON.stringify(error));
    }

    getStores(showLoader: boolean = true){
        console.log("getStores");
        let that=this;
        this.loader = this.loadingCtrl.create({
            content: "Please wait...",
        });
        if (showLoader){
            this.loader.present();
        }
        let uid=this.globals.currentUser.id;
        that.server.getHomeFeed({user_id: uid}).subscribe(
            res=>that.storesSuccess(res),err=>that.storesFailure(err)
        );
    }

    itemClick(st){
        console.log("itemClick: "+st.service_name);
        //if (this.feedType=='upcoming'){
            //this.navCtrl.push(ReservationPage,{item: st});
        //}
        this.navCtrl.push(ReservationDetailPage,{reservation: st});
    }

    onCancelReservation(st){
        console.log("onCancelReservation: "+st.id);
        this.loader = this.loadingCtrl.create({
            content: "Please wait...",
        });
        this.loader.present();
        let data={user_id: this.globals.currentUser.id,reservation_id: st.id};
        this.server.cancelReservation(data).subscribe((res)=>{
            this.loader.dismiss();
            let json=res.json();
            if (json.status==200){
                this.uiHelper.showMessageBox("Cancel","Reservation canceled");
                let rId=json.data.id;
                for (let x=0;x<this.items.length;x++){
                    if (this.items[x].id==rId){
                        this.items.splice(x,1);
                        break;
                    }
                }
            }else{
                this.uiHelper.showMessageBox("Error",json.msg);
            }
        },(err)=>{
            this.loader.dismiss();
            console.error("Error: "+JSON.stringify(err));
            this.uiHelper.showMessageBox('Error',JSON.stringify(err));
        })
    }

    cancelClick(st){
        console.log("cancelClick: "+st.service_name);
        this.uiHelper.showConfirmBox(this.globals.getTranslatedText("cancel"),this.globals.getTranslatedText("sure_want_to_cancel"),()=>{
            this.onCancelReservation(st);
        },()=>{});
    }

    itemPress(st){
        console.log("itemPress: "+st.service_name);
        if (this.feedType!="upcoming"){
            return;
        }
        let tle=st.service_name+" (for "+st.num_hours+" hours)";
        let actionSheet = this.actionSheetCtrl.create({
            title: tle,
            buttons: [
                {
                    text: this.globals.getTranslatedText("share"),
                    role: 'destructive',
                    handler: () => {
                        console.log('Share clicked');
                        this.shareReservation(st);
                    }
                },
                {
                    text: this.globals.getTranslatedText("add_to_calendar"),
                    role: 'destructive',
                    handler: () => {
                        console.log('Add to calendar clicked');
                        this.addToCalendar(st);
                    }
                },
            ]
        });
        actionSheet.present();
    }

    addReservationClick(){
        console.log("addReservationClick");
        this.navCtrl.push(ReservationPage,{reservation: null});
    }

    public shareReservation(rs){
        console.log("shareReservation: "+rs.service_name+"::"+rs.date_display_text);
        try{
            let shareText=rs.service_name+"\n"+rs.date_display_text;
            shareText+="\nfor "+rs.num_hours+" hour(s)";
            shareText+="\n"+rs.time_display_text;
            let lnk=null;
            console.log(lnk);
            console.log(shareText);
            (<any>window).plugins.socialsharing.share(shareText, null, null,lnk);
        }catch(e){
            console.error(e.message);
            this.uiHelper.showMessageBox("Exception",e.message);
        }
    }

    public addToCalendar(rs){
        console.log("addToCalendar: "+rs.service_name+"::"+rs.date_display_text);
        try{
            let title=rs.service_name+" (for "+rs.num_hours+" hour(s))";
            let eventLocation=rs.service_name;
            let notes=rs.date_display_text+" "+rs.time_display_text;
            let startDate=new Date(Number(rs.start_ts)*1000);
            let endDate=new Date((Number(rs.start_ts)+(Number(rs.num_hours)*60*60))*1000);
            console.log(startDate.toString()+"::"+endDate.toString());
            (<any>window).plugins.calendar.createEvent(title,eventLocation,notes,startDate,endDate,(succ)=>{
                this.uiHelper.showMessageBox("Calendar","Event created in your calendar");
            },(err)=>{
                this.uiHelper.showMessageBox("Error","Error: "+JSON.stringify(err));
            });
        }catch(e){
            console.error(e.message);
            this.uiHelper.showMessageBox("Exception",e.message);
        }
    }
}
