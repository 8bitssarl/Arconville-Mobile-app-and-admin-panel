@echo on
cd /d "D:\TOOLS\android\android-sdk-windows\platform-tools"
call adb uninstall "com.ziadbooking"
call adb install "D:\apks\ZiadBooking.apk"
cd /d "D:\PROJECTS\DotNotCore\ZiadBooking\mapp"