# TFTray Documentation

## Purpose of this Application
The TFTray is the result of the development of another Application that I am writing for using TinkerForge Hardware.
Due to the fact, that the Communication with the Bricks and Bricklets will be handled by the BrickDaemon Software, it must be assured, that the Service is running if your Software should connect with the Bricks.

Therefore, I wanted to implement a check for the Service Status during the application init and also I wanted to create a small and simple Monitoring of the Service.
The Status should be visible in the SystemTray.

With this thoughts, I have started to create the TFTray to see, how this could be done - and decided then to implement some quick-access functions like Start the Service, or Stop the Service.

***

## Notifications and Indicators
The main reason for this application is, to provide the user a fast and easy way to check, if the Brick Daemon Service is running or not.

Therefor, the Application is showing the Service Status with using a green or red TinkerForge Symbol in the Tray.
It is also showing a small Notification popup if the user is changing the Status of the Service through the application²

Since Windows Vista, an application is not running with the privileges of he currently logged in user.
For all changes that needs to be done on the Computer an application needs higher privileges.
This is also valid for starting or stopping a Service on Windows.

Windows will show a Dialog, the so called UAC if an Application is requesting Administrative rights for performing any kind of changes on the system.

For TFTray, this means, that the Application will be forced to show the UAC Dialog.
If the user is accepting the request, the Application needs to be restarted with the new privileges.  
![Windows UAC Dialog](https://christoph.caina.family/dev/TinkerForge/TFTray/doc/img/TFUacDialog.png)

F.e. the Application will be started and detect, that the BrickDaemon is not running.
Then, we are showing the red offline Icon and our notification - but as soon, as the User will start the Service, the application is checking if it already has Administrator rights.
If not, the UAC will be shown and the Application is restarting after the Userconfirmation.
Now, the user needs select "Start" again, to start the BrickDaemon.

It is only needed to set this privilege once during the runtime of the application.

***
  
### 1. Online
#### Online Indicator Icon
![OnlineIndicator](https://christoph.caina.family/dev/TinkerForge/TFTray/doc/img/TFOnlineIndicator.png)

#### Online Notification (Windows 8.1)
![OnlineNotification_Win8](https://christoph.caina.family/dev/TinkerForge/TFTray/doc/img/TFOnlineNotification_Win8.png)

#### Online Notification (Windows 10)
![OnlineNotification_Win10](https://christoph.caina.family/dev/TinkerForge/TFTray/doc/img/TFOnlineNotification_Win10.png)

  
  
### 2. Offline
#### Offline Indicator Icon
![OfflineIndicator](https://christoph.caina.family/dev/TinkerForge/TFTray/doc/img/TFOfflineIndicator.png)

#### Offline Notification (Windows 8.1)
![OfflineNotification_Win8](https://christoph.caina.family/dev/TinkerForge/TFTray/doc/img/TFOfflineNotification_Win8.png)

#### Offline Notification (Windows 10)
![OfflineNotification_Win10](https://christoph.caina.family/dev/TinkerForge/TFTray/doc/img/TFOfflineNotification_Win10.png)

***

² = currently, the application can't show a notification when the Service Status has changed from outside of the application (in services.msc directly).
Anyway, the Indicator Icon is changing if the Service Status has changed.
Right now, the software is checking the Service Status periodically every x ms and we would show a Notification Message every time, when we're checking if the status of the Service has changed or not.
