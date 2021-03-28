# Level-Builder-AR-VictorArmisen
Level Builder AR for mobile devices (Android/iOS)

# Project Description 

# Instalation guide

Download the full source code of this Unity Project in this Github page. Then, use Unity Hub to add the project into your computer. Click Add in Unity Hub and search for the subfolder 
"Level-Builder-AR-VictorArmisen" containing the Assets folder. Then the project will be visible in your Unity's Hub Interface. 

Requirements: <br />
Unity version: Unity 2020.2.4f1 <br />
Android build support: UnityHub -> Installs -> Select Unity 2020.2.4f1 -> Add modules -> Android Build support checked. <br />
iOS build support. UnityHub -> Installs -> Select Unity 2020.2.4f1 -> Add modules -> iOS Build support checked. <br />

Once you have this, you're ready to go. Open the Unity Project ("Level-Builder-AR-VictorArmisen") in the Unity Hub's Projects section. 

# Folder Estructure

Basically, the hierarchy of the folders it is the following one: 
- Art: Folder which contains all the 3D Assets, Materials, Textures, Animations, UI....
- Scripts: Folder which contains all the scripts for the scenes. 
- Scripts_Prototype: These contains the file of the non-inmersive prototype. Just 3D. For mechanics and test of the Tower Defense. 
- Prefabs: This contains all the prefabs created for the scenes. 
- Tools: Plugins and packs to help the debugging process in AR Foudantion. 
- XR: Folder which contains files of the XR Plugin in Unity. 
- Scenes: Folder which contains all the scenes for this project: 
  We have two main scenes for now: 
    1. TouchScreen: Game Scene where the player simple detects a horizontal plane with the camare detection movement and
    set the path points for the game.
    Explation: 
    This scene contains the following GameObjects: 
      - AR Session Origin: With all the AR Foundation scripts to produce the plane detection of the enviroment.
      - AR Session: AR Session and AR Input Manager script. 
      - Canvas: With all the following UI elements to manage the gameplay by the mobile interface. 
      - OnlyOneActivated: The aim of this script is to correct the continuous instantiation of planes in AR Foundation. Leaving only one plane always detected in the scene. 
        This is updated and can be changed to a newer one. 
      - GameManager:  It is a GameObject that contains an script that controls the match propierties of the state of the gameplay. 
      - EnemySpawn: The position of the enemies will be instantiated. 
    2. ImageTracking: Game Scene where the player uses an printed image to set the path of the gameplay. We use image tracking AR Foundation
    to recognize the images. Then the player, click a UI button to instantiate the point once the image is scanned. Only one image detection at once. 
    This scene contains the following GameObjects: 
      - AR Session Origin: With all the AR Foundation scripts to produce the plane detection of the enviroment. 
        In this scene, we put the script Image Track Single, that instantiates the path point for each Image Tracked and Spawn the enemy horde. 
      - AR Session: AR Session and AR Input Manager script. 
      - Canvas: With all the following UI elements to manage the gameplay by the mobile interface. 
    3. Prototype-Tower-Defense(NO-AR): Game Scene to prove and test the diferent mechanics for the game. No inmersive technology it is used in this scene. 
    4. Object tracking (NOT CREATED) (FUTURE IMPLEMENTION). 
