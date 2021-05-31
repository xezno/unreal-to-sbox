# UE4 to s&box converter

This converts UE4 meshes to s&box-compatible vmdls.

Please note that this is still in a really basic stage. I'd recommend waiting until I have materials worked out before using it.

## Current features

- Imports meshes

## Planned features

- Auto-import materials
- Import animations

## Is this legal?

Yes.

![Unreal Marketplace FAQ](https://cdn.discordapp.com/attachments/839155256964284459/849029387910250496/unknown.png)

(Taken from [here](https://www.unrealengine.com/en-US/marketplace-faq) on 31/05/2021)

## How do I use it?

1. Make an empty Unreal project. Import the assets you want to use
2. Download [UE Viewer](https://www.gildor.org/en/projects/umodel). Export all the meshes, textures, and materials within the project's `Content` directory
3. Move all of the exported stuff to `<sbox dir>/addons/<your addon>/models/`
4. Drag Gltf2Fbx.exe into `<sbox dir>/addons/<your addon>/models/` (or the root directory for your new content)
5. Launch Gltf2Fbx.exe
6. Launch s&box, let all the models compile. Then you'll need to go in and manually hook up all of the textures and materials