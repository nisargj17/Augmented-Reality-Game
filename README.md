# Augmented-Reality-Game

This game allow people with different devices to be able to play the same game in the same space.
We started with the TANKS! Networking Demo project that is available from the Asset Store. This turned out to be a good start since the project is a simple one which allows you to play a multiplayer game between various mobile devices. The main thing missing was to make it work as an AR experience, and share that experience across multiple devices.

The existing project worked by using this flow: LobbyScene -> CompleteMainScene

This flow used the Lobby scene to do matchmaking of the users on the different devices, and then forwarded the matched users to play together in the main scene.

To make our modifications, we first got rid of the CameraRig that the main scene had, since we were going to create a camera that was going to be controlled by the AR device and not by the movement of the tanks. Then we changed the flow of the game by adding a new scene at the beginning of the flow: ARSetupScene -> LobbyScene -> CompleteMainScene

In this case, we set up the AR session and camera in the AR setup scene. Then we pass control over to the Lobby scene, making sure that we make the AR session and camera stay in the scene when we load the subsequent scenes.

The AR setup scene itself uses plane detection to find a good place to create the game. Both devices will look at the same table surface, and use its center to show where the level should appear. Since both use a real world table center and orientation to sync up their coordinate systems, the shared level is created in the same spot according to both devices.

We then consider the size of the plane and the size of the level in Tanks! to figure out what scale we should use on the level content using the mechanism described in the scaled content section. We then use this scale for the Tanks! level we are going to display for both players. We also made some changes to be able to directly interact with the Tanks by screen touch and dragging.

To try this out, in Build Settings, select ARSetupScene, LobbyScene and CompleteMainScene and build those scenes out to your device.
