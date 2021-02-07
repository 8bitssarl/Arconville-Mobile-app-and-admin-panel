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
import { AddFamilyPage } from '../pages/add-family/add-family';
import { EditProfilePage } from '../pages/edit-profile/edit-profile';
import { PackagesPage } from '../pages/packages/packages';
import { SettingsPage } from '../pages/settings/settings';
import { PackageDetailPage } from '../pages/package-detail/package-detail';

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
        ReservationPage,
        FamilyPage,
        AddFamilyPage,
        SettingsPage,
        EditProfilePage,
    ],
    imports: [
        BrowserModule,
        HttpModule,
        IonicModule.forRoot(MyApp)
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
        ReservationPage,
        FamilyPage,
        AddFamilyPage,
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
