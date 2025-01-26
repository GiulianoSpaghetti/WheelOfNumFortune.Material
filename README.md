# WheelOfNumFortune
## numerone's fortune material

A fortune discover game for windows and linux in avalonia dialect material of Google.
This project does not use the google's xaml stylesheet, but use the reactive ui of avalonia (it's read multitrheaded)·


## Installing using repository (GNU/Linux)
Follow the guide at https://learn.microsoft.com/it-it/dotnet/core/install/linux-debian first

Then follow the guide at http://numeronesoft.ddns.net:8080

and then update and install wheelofnumfortune.avalonia

Prerequisites:

https://learn.microsoft.com/en-us/linux/packages

Note: the packages are system independent and IL, so in theory it is sufficient to reinstall the package at each desktop runtime update and start the program once to get the updated binary code.
Obviously if they update avalonia you need to recompile.

## Using the dark theme

For using the dark theme on debian the app must be recompiled adding the parameter RequestedThemeVariant with the value Dark at the Application node to the App.xaml file.

## Windows

## On Windows

[![winget](https://user-images.githubusercontent.com/49786146/159123313-3bdafdd3-5130-4b0d-9003-40618390943a.png)](https://marticliment.com/wingetui/share?pid=GiulioSorrentino.wheelofnumfortune.Avalonia&pname=wheelofnumfortune.Avalonia&psource=Winget:%20winget)

Prerequisites:

https://winstall.app/apps/Microsoft.DotNet.DesktopRuntime.9

Note: the packages are system independent and IL, so in theory it is sufficient to reinstall the package at each desktop runtime update and start the program once to get the updated binary code.
Obviously if they update avalonia you need to recompile.


## Screenshots

## Debian

![Schermata del 2025-01-26 11-19-05](https://github.com/user-attachments/assets/7ec8a351-dc90-4367-8394-4df92ee1d7f6)
![Schermata del 2025-01-26 11-19-09](https://github.com/user-attachments/assets/f103a5e2-e7da-40f7-bec8-fca90143a90c)
![Schermata del 2025-01-26 11-19-18](https://github.com/user-attachments/assets/ec79744c-c283-4f9c-b47d-7611924fa2d4)
![Schermata del 2025-01-26 11-19-23](https://github.com/user-attachments/assets/026cf948-1bbc-4a17-a5e8-b26570169d04)


## Windows

<img width="1431" alt="2025-01-26" src="https://github.com/user-attachments/assets/a99e7757-f680-4c46-a5b5-5f9f2eb3c73e" />
<img width="1431" alt="2025-01-26 (3)" src="https://github.com/user-attachments/assets/f3fd89e7-9313-41cc-80f5-d9ef7404ceab" />
<img width="1431" alt="2025-01-26 (2)" src="https://github.com/user-attachments/assets/bbb104a5-b2c7-455f-b48f-efa2952bbc26" />
<img width="1431" alt="2025-01-26 (1)" src="https://github.com/user-attachments/assets/bea2a671-da1f-44ca-a013-3c7084c143c9" />


## Knowed Bugs

There are some escape string are not converted, so the screen may be unfriendly, some times.

There are some escape strings are not recognized, so the solution may be wrong even if it's correct. For solving it, try to copy the original string covered by asterisks and change the ones are not discovered yet.

# Donations

http://numerone.altervista.org/donazioni.php
