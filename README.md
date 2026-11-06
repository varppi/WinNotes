<p align="center">
  <img width="300" src="https://github.com/user-attachments/assets/70425a97-373a-4d78-8e31-fb45304eb2b8" />
</p>

## Windows Notes
<b>An extremely simple note taking application designed for quick note taking. No bloat, just simple notes with no hassle.</b>

<br>

## Installation and usage
1. Download the ZIP file from https://github.com/varppi/WinNotes/releases
2. Unpack and run WinNotes.exe (it won't look like it ran, but it most likely did)
3. Press CTRL + Shift + Space to spawn a new note Window.
4. To kill the app, go to the icon tray on the right bottom corner of Windows, right click on the app and click "close" or press Win + R and type `taskkill /f /im WinNotes.exe`

## From source
First make sure you have .NET 10.0 installed and added to your PATH environment variable.
1. `git clone https://github.com/varppi/WinNotes`
2. `cd WinNotes/WinNotes`
3. `dotnet publish -c Release -r win-x86 --self-contained true -p:PublishSingleFile=true`

<br>

## Demo

<img width="810" height="455"  src="https://github.com/user-attachments/assets/e328dcf4-c40f-456c-b0a3-4cfaca36a164" />

