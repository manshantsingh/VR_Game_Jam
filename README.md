# VR Game Jam
Unity SDK game for Google Cardboard

## Steps to build and run the project (Windows and MacOS only):

Step 1: Create a new empty project from the Unity Home Screen which loads when you first launch Unity.

Step 2: Make sure that PC, Mac & Linux Standalone is selected as the platform to use by visiting File > Build Settings from the top menu.

Step 3: Create a new cube (Game Object > 3D Object > Cube) and position it in front of the default Main Camera in your new empty scene using the Translate tool.

Step 4: Save your scene (File > Save Scene).

Step 5: Go to Edit > Project Settings > Player and check the box to enable "Virtual Reality Supported".

Step 6: Enter Play mode by pressing Play at the top of the interface.

## Building and running on Android

1. Connect your Android device to your PC/Mac using a micro USB cable.

2. Create a new empty project (menu: File > New Project).

3. Switch your build platform to Android (menu: File > Build Settings).

4. Open the Player Settings (menu: Edit > Project Settings, then select the Player category). Select Other Settings and check the Virtual Reality Supported checkbox.

5. Add Oculus to the Virtual Reality SDK’s list.

6. Create the folder `Plugins/Android/assets` under your project’s Assets folder (note: This folder name is case-sensitive).

7. Include an Oculus signature file in your project in the `Plugins/Android/assets` folder.

8. Build and run. Insert the device into your headset and see the skybox with head tracking.
