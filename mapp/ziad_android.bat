@echo on
cd /d "D:\PROJECTS\DotNotCore\ZiadBooking\mapp"
call ionic cordova build android --release
del "D:\apks\ZiadBookingr.apk"
copy "D:\PROJECTS\DotNotCore\ZiadBooking\mapp\platforms\android\app\build\outputs\apk\release\app-release-unsigned.apk" "D:\apks\ZiadBookingr.apk"
call jarsigner -verbose -sigalg SHA1withRSA -digestalg SHA1 -keystore "D:\TOOLS\Android\usmani.keystore" "D:\apks\ZiadBookingr.apk" usmaniandroid2
del "D:\apks\ZiadBooking.apk"
cd /d "D:\TOOLS\android\android-sdk-windows\build-tools\29.0.3"
call zipalign -v 4 "D:\apks\ZiadBookingr.apk" "D:\apks\ZiadBooking.apk"
cd /d "D:\PROJECTS\DotNotCore\ZiadBooking\mapp"
IF "%1"=="--install" call install.bat