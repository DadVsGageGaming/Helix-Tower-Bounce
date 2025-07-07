# Helix Jump Switch-Style (Unity) — README

## Features

- Tap (mobile) / Space or click (PC) to bounce.
- Collect coins to buy new balls in the shop.
- Speed boost (green arrow) halfway down the level.
- Responsive, smooth controls.
- Unlock and select ball skins.
- Dragon Puppet skin uses your uploaded image.

## Setup

1. **Create a Unity 3D Project.**
2. **Add the scripts from `Assets/Scripts/`.**
3. **Create prefabs:**
   - Platform (`Platform`, tag: Platform)
   - SpeedBoost (`SpeedBoost`, tag: SpeedBoost, color/arrow as desired)
   - Coin (`Coin`, tag: Coin)
   - Ball (`Ball`, attach HelixBallController, BallSkinSelector, assign ballRenderer)
4. **Dragon Puppet Skin:**
   - Download your image from [here](https://drive.google.com/file/d/1RUPhft2gANURXPNHTRl_eovgagG2ZjoQ/view)
   - Import into Unity as a Texture2D/Sprite.
   - Create a new Material (e.g. `DragonPuppet.mat`), assign the imported image as the Albedo texture.
   - In your BallSkinDatabase, add a skin called "Dragon Puppet", with your new material, price (e.g. 100), unlocked = false.
5. **Create a ScriptableObject (`BallSkinDatabase`) and add example skins:**
   - Blue Ball (default, unlocked, price 0)
   - Dragon Puppet (your art, price 100, locked)
   - Pepperoni Ball (pizza look, price 50, locked)
   - Creeper Head (green pixel, price 50, locked)
   - Add more as desired
6. **Set up UI:**
   - Canvas with `coinsText` (for coin display)
   - Dropdown for BallSkinSelector
   - Shop Panel with ShopManager, BallSkinDatabase, GameManager references, and ShopItemPrefab (Button+Text)
7. **Assign tags (`Platform`, `SpeedBoost`, `Coin`) to the correct prefabs.**
8. **Add PlatformSpawner to a GameObject and assign prefabs.**
9. **Add GameManager to a GameObject and assign coinsText.**
10. **Add CameraFollow to the camera, target = ball.**
11. **Play!**

## Expand

- Add sound, juice, effects, new skins, obstacles, scoring, levels, etc.

---

**You must create materials and assign them in the BallSkinDatabase asset for each ball skin.  
SpeedBoost prefab should be visually distinct (green arrow, for example).  
Shop UI can be simple (vertical layout of shopItemPrefab under shopPanel).**

---

Enjoy your Helix Jump Switch-style game!
