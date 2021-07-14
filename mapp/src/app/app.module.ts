import { BrowserModule } from '@angular/platform-browser';
import { ErrorHandler, NgModule } from '@angular/core';
import { IonicApp, IonicErrorHandler, IonicModule } from 'ionic-angular';
import { HttpModule } from '@angular/http';
import { SplashScreen } from '@ionic-native/splash-screen';
import { StatusBar } from '@ionic-native/status-bar';

import { MyApp } from './app.component';
import { HomePage } from '../pages/home/home';
import { LoginPage } from '../pages/login/login';
import { SplashPage } from '../pages/splash/splash';
import { SignupPage } from '../pages/signup/signup';
import { UiHelper } from '../services/uihelper';
import { AppServer } from '../services/appserver';
import { AppGlobals } from '../services/appglobals';
import { ForgotPasswordPage } from '../pages/forgot-password/forgot-password';

import { FileTransfer } from '@ionic-native/file-transfer';
import { Camera } from '@ionic-native/camera';
import { File } from '@ionic-native/file';
import { FilePath } from '@ionic-native/file-path';
import { Geolocation } from '@ionic-native/geolocation';
import { FeedPage } from '../pages/feed/feed';
import { ReservationPage } from '../pages/reservation/reservation';
import { VerifyPhonePage } from '../pages/verify-phone/verify-phone';
import { VerifyCodePage } from '../pages/verify-code/verify-code';
import { FamilyPage } from '../pages/family/family';
import { EditProfilePage } from '../pages/edit-profile/edit-profile';
import { PackagesPage } from '../pages/packages/packages';
import { SettingsPage } from '../pages/settings/settings';
import { PackageDetailPage } from '../pages/package-detail/package-detail';
import { ReservationDetailPage } from '../pages/reservation-detail/reservation-detail';
import { FamilyDetailPage } from '../pages/family-detail/family-detail';

import {ContactUSPage} from '../pages/contact-us/contact-us';


// importing @ngx-translate/core (13.9k)
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';

import { HttpClient, HttpClientModule } from '@angular/common/http';

export function createTranslateLoader(http: HttpClient) {
  return new TranslateHttpLoader(http, './assets/i18n/', '.json');
}


@NgModule({
    declarations: [
        MyApp,
        SplashPage,
        LoginPage,
        VerifyPhonePage,
        VerifyCodePage,
        ForgotPasswordPage,
        SignupPage,
        HomePage,
        PackagesPage,
        PackageDetailPage,
        FeedPage,
        ReservationDetailPage,
        ReservationPage,
        FamilyPage,
        ContactUSPage,
        FamilyDetailPage,
        SettingsPage,
        EditProfilePage,
    ],
    imports: [
        BrowserModule,
        HttpModule,
        IonicModule.forRoot(MyApp),
        HttpClientModule,
      TranslateModule.forRoot({
        loader: {
          provide: TranslateLoader,
          useFactory: (createTranslateLoader),
          deps: [HttpClient]
        }
      }) // adding it to the imports, this is neccesary for loading in every component and pages of the app.
    ],
    bootstrap: [IonicApp],
    entryComponents: [
        MyApp,
        SplashPage,
        LoginPage,
        VerifyPhonePage,
        VerifyCodePage,
        ForgotPasswordPage,
        SignupPage,
        HomePage,
        PackagesPage,
        PackageDetailPage,
        FeedPage,
        ReservationDetailPage,
        ReservationPage,
        FamilyPage,
        ContactUSPage,
        FamilyDetailPage,
        SettingsPage,
        EditProfilePage,
    ],
    providers: [
        StatusBar,
        SplashScreen,
        UiHelper,AppServer,AppGlobals,
        File,FileTransfer,FilePath,Camera,Geolocation,
        {provide: ErrorHandler, useClass: IonicErrorHandler}
    ]
})
export class AppModule {}
