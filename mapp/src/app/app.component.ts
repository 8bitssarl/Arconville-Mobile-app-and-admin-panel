import { Component } from '@angular/core';
import { Platform } from 'ionic-angular';
import { StatusBar } from '@ionic-native/status-bar';
import { SplashScreen } from '@ionic-native/splash-screen';
import { SplashPage } from '../pages/splash/splash';
import { TranslateService } from '@ngx-translate/core';

@Component({
    templateUrl: 'app.html'
})
export class MyApp {

    rootPage:any = SplashPage;

    constructor(platform: Platform, statusBar: StatusBar, splashScreen: SplashScreen, private ts: TranslateService,) {
        platform.ready().then(() => {
            // Okay, so the platform is ready and our plugins are available.
            // Here you can do any higher level native things you might need.
            statusBar.styleDefault();
            statusBar.overlaysWebView(false);
          statusBar.backgroundColorByHexString('#0c68b3');
          this.setLanguage(); // I am setting the language here... I do not know how are you planing to set this automatically.

          splashScreen.hide();
        });
    }


  setLanguage() {
    this.ts.setDefaultLang('en');
  }
}

