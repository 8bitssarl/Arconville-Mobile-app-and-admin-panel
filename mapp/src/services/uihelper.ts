import {Injectable} from "@angular/core";
import { AlertController,ToastController,LoadingController } from 'ionic-angular';
import { DomSanitizer } from '@angular/platform-browser';

@Injectable() export class UiHelper {

    private months:any[]=["Jan","Feb","Mar","Apr","May","Jun","Jul","Aug","Sep","Oct","Nov","Dec"];

    constructor(public sanitizer: DomSanitizer,public loadingCtrl: LoadingController, public alertCtrl: AlertController,public toastCtrl: ToastController){
    }

    public sanitizeHTML(html: string){
        return this.sanitizer.bypassSecurityTrustHtml(html);
    }

    public roundToDecimal(val:string,decs:number){
        let commVals=val.split(".");
        let commStr=commVals[0];
        let decStr="";
        let decCount=0;
        if (commVals.length>1){
            if (commVals[1].length>decs){
                decStr=commVals[1].substring(0,decs);
            }else if (commVals[1].length<decs){
                decStr=commVals[1];
                decCount=decs-commVals[1].length;
            }else{
                decStr=commVals[1];
            }
        }else{
            decCount=decs;
        }
        if (decCount>0){
            for (var a=1;a<=decCount;a++){
                decStr+="0";
            }
        }
        if (decStr!=""){
            commStr+="."+decStr;
        }
        return commStr;
    }

    public showMessageBox(titleText,messageText){
        let alert = this.alertCtrl.create({
            title: titleText,
            message: messageText,
            buttons: ['OK']
        });
        alert.present();
        return alert;
    }

    public showConfirmBox(titleText,messageText,yesHandler,noHandler){
        let alert = this.alertCtrl.create({
            title: titleText,
            message: messageText,
            buttons: [
                {
                    text: 'Yes',
                    handler: yesHandler
                },
                {
                    text: 'No',
                    handler: noHandler
                }
            ]
        });
        alert.present();
        return alert;
    }

    public showConfirmBox3(titleText,messageText,yesText,yesHandler){
        let alert = this.alertCtrl.create({
            title: titleText,
            message: messageText,
            buttons: [
                {
                    text: yesText,
                    handler: yesHandler
                }
            ]
        });
        alert.present();
        return alert;
    }

    public getDateInIonic(dt){
        let year=dt.getFullYear();
        let month=dt.getMonth()+1;
        let str=year+"-";
        if (month<10){
            str+="0";
        }
        str+=month+"-";
        let date=dt.getDate();
        if (date<10){
            str+="0";
        }
        str+=date+"T";
        let hour=dt.getHours();
        let mins=dt.getMinutes();
        if (hour<10){
            str+="0";
        }
        str+=hour+":";
        if (mins<10){
            str+="0";
        }
        str+=mins+"Z";
        return str;
    }

    public getCurrentDateInIonic(){
        let dt=new Date();
        return this.getDateInIonic(dt);
    }

    public getMealDisplayDate(mealTime,currentTime){
        let dateStr="";
        let minuteStr="";
        let hourStr="";
        let currentDate=new Date();
        currentDate.setTime(currentTime);
        let mealDate=new Date();
        mealDate.setTime(mealTime);
        let hours=mealDate.getHours();
        let minutes=mealDate.getMinutes();
        let amPmStr="am";
        if (hours>12){
            hours=hours-12;
            amPmStr="pm";
        }else if (hours==0){
            hours=12;
            amPmStr="am";
        }
        if (minutes<10){
            minuteStr="0"+minutes;
        }else{
            minuteStr=""+minutes;
        }
        if (hours<10){
            hourStr="0"+hours;
        }else{
            hourStr=""+hours;
        }
        let hoursStr=hourStr+":"+minuteStr+" "+amPmStr;
        if (mealDate.getFullYear()==currentDate.getFullYear()
            && mealDate.getMonth()==currentDate.getMonth()
            && mealDate.getDate()==currentDate.getDate()){

            //it is today .. now check for day or night
            if (mealDate.getHours()<5 || mealDate.getHours()>=19){
                dateStr=hoursStr+" - Tonight";
            }else{
                dateStr=hoursStr+" - Today";
            }
        }else if (mealDate.getFullYear()==currentDate.getFullYear()
            && mealDate.getMonth()==currentDate.getMonth()
            && mealDate.getDate()==(currentDate.getDate()+1)){

            //it is tomorrow .. now check for day or night
            if (mealDate.getHours()<5 || mealDate.getHours()>=19){
                dateStr=hoursStr+" Tomorrow";
            }else{
                dateStr=hoursStr+ "Tomorrow";
            }
        }else{
            let dtStr:any=mealDate.getDate();
            if (dtStr<10){
                dtStr="0"+dtStr;
            }
            dateStr=hoursStr+" - "+dtStr+" "+this.months[mealDate.getMonth()];
        }
        return dateStr;
    }

    public getMealDisplayOnlyDate(mealTime,currentTime){
        let dateStr="";
        let currentDate=new Date();
        currentDate.setTime(currentTime);
        let mealDate=new Date();
        mealDate.setTime(mealTime);
        let dtStr:any=mealDate.getDate();
        if (dtStr<10){
            dtStr="0"+dtStr;
        }
        dateStr=dtStr+" "+this.months[mealDate.getMonth()]+" "+mealDate.getFullYear().toString();
        return dateStr;
    }

    public getMinutesRemainingStr(mealTime){
        let currentDate=new Date();
        let currentTime=currentDate.getTime();
        let remainingMs=mealTime-currentTime;
        let dtStr="";
        let mins=Math.round((remainingMs/1000/60));
        let hours=Math.round(mins/60);
        let days=Math.round(hours/24);

        let retVal={type:'',text:'',value:0};

        if (mins<60){
            dtStr="in "+mins+" minutes";
            retVal.type="mins";
            retVal.text=dtStr;
            retVal.value=mins;
        }else if (hours<=48){
            dtStr="in "+hours+" hours";
            retVal.type="hours";
            retVal.text=dtStr;
            retVal.value=hours;
        }else{
            dtStr="in "+days+" days";
            retVal.type="days";
            retVal.text=dtStr;
            retVal.value=days;
        }

        return retVal;
    }

    public getMinutesAgoStr(mealTime){
        let currentDate=new Date();
        let currentTime=currentDate.getTime();
        let remainingMs=currentTime-mealTime;
        let dtStr="";
        let mins=Math.round((remainingMs/1000/60));
        let hours=Math.round(mins/60);
        let days=Math.round(hours/24);

        let retVal={type:'',text:'',value:0};

        if (mins<60){
            dtStr=mins+" mins ago";
            retVal.type="mins";
            retVal.text=dtStr;
            retVal.value=mins;
        }else if (hours<=48){
            dtStr=hours+" hrs ago";
            retVal.type="hours";
            retVal.text=dtStr;
            retVal.value=hours;
        }else{
            dtStr=days+" days ago";
            retVal.type="days";
            retVal.text=dtStr;
            retVal.value=days;
        }

        return retVal;
    }

    public getTimestampFromIonicDate(mealDt){
        let vals=mealDt.split("T");
        let dVals=vals[0].split("-");
        let tVals=vals[1].split(":");
        let mealDate=new Date();
        mealDate.setFullYear(parseInt(dVals[0]));
        mealDate.setMonth(parseInt(dVals[1])-1);
        mealDate.setDate(parseInt(dVals[2]));
        mealDate.setHours(parseInt(tVals[0]));
        mealDate.setMinutes(parseInt(tVals[1]));
        mealDate.setSeconds(0);
        let mealTime=mealDate.getTime();
        return mealTime;
    }

    public getDbTimestampFromIonicDate(mealDt){
        let ts=this.getTimestampFromIonicDate(mealDt);
        return Math.ceil(ts/1000);
    }

    public getDbTimeFromIonicDate(mealDt){
        let mealDate=new Date();
        mealDate.setTime(this.getTimestampFromIonicDate(mealDt));
        let mealTime=mealDate.getFullYear()+"-"+(mealDate.getMonth()+1)+"-"+mealDate.getDate();
        mealTime+=" "+mealDate.getHours()+":"+mealDate.getMinutes()+":"+mealDate.getSeconds();
        return mealTime;
    }

    getDurationText(seconds: number){
        if (seconds<60){
            return seconds+" s";
        }
        let minutes=seconds/60;
        if (minutes<60){
            return minutes+" m";
        }
        let hours=minutes/60;
        if (hours<24){
            return hours+" h";
        }
        return hours+" d";
    }

    getDistanceText(km: number){
        let mi=((km*0.62)/1000).toString();
        let vals=mi.split(".");
        let miText=vals[0];
        if (vals.length>1){
            miText+="."+vals[1].substring(0,1);
        }
        miText+=" mi";
        return miText;
    }
}