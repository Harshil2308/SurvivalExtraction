# Mobile 3D Survival & Extraction Game

A 3D survival and extraction game prototype developed using **Unity 6 and C#**, designed primarily for Android devices. The project focuses on mobile controls, player movement, weapon mechanics, enemy AI, and wave-based survival gameplay.

## 🎮 Project Overview

The objective is to survive enemy encounters, complete objectives, and eventually reach an extraction point.

The project is being developed with a focus on:
- Mobile-friendly gameplay and touch controls.
- First-person player movement and camera control.
- Weapon mechanics, including shooting, reloading, and switching.
- Enemy navigation and AI behaviour.
- Wave-based enemy encounters.
- Performance optimization for Android devices.

## 🛠️ Technology Stack

| Technology | Purpose |
|---|---|
| Unity 6 | Game development engine |
| C# | Gameplay programming |
| Universal Render Pipeline (URP) | Rendering |
| AI Navigation | Enemy navigation and pathfinding |
| Character Controller | Player movement |
| Physics Raycasting | Weapon hit detection |
| Unity UI | Mobile interface |

## ✅ Development Progress

### Phase 1 – Project Setup & Player Movement

- Created a Unity 6 project using the Universal 3D (URP) template.
- Created the main survival arena with a ground plane and surrounding walls.
- Set up the player using a Capsule and Character Controller.
- Implemented first-person camera positioning using a camera pivot.
- Created `PlayerController.cs`.

**Implemented player mechanics:**
- Forward, backward, left, and right movement.
- Sprinting.
- Jumping.
- Gravity and ground detection.
- Mouse-based camera rotation for editor testing.
- Mobile input support through public control methods.

### Phase 2 – Mobile Touch Controls & UI

Created a mobile UI system using Unity Canvas.

**Implemented:**
- Canvas configured with Canvas Scaler.
- Virtual joystick for player movement.
- Touch-based camera look area.
- Sprint button.
- Jump button.
- Fire button.
- Reload button.
- Weapon switch button.
- Pause button.
- Pause menu with Resume and Quit options.

**Scripts created:**
- `VirtualJoystick.cs`
- `TouchCamera.cs`
- `MobileInput.cs`
- `PauseButton.cs`

The UI is configured using a reference resolution of 1920 × 1080 with Scale With Screen Size.

### Phase 3 – Weapon System

Implemented the initial weapon system using C#.

**Implemented mechanics:**
- Two weapon slots.
- Weapon switching.
- Shooting using Physics Raycast.
- Weapon-specific damage and range.
- Fire-rate control.
- Magazine ammunition.
- Reserve ammunition.
- Reloading with a reload delay.
- Enemy damage detection.

**Scripts created:**
- `WeaponController.cs`
- `EnemyHealth.cs`

**Current weapon configuration:**

| Weapon | Damage | Magazine | Reserve Ammo | Fire Rate |
|---|---:|---:|---:|---:|
| Rifle | 25 | 30 | 90 | 0.2 seconds |
| Pistol | 40 | 12 | 36 | 0.5 seconds |

The weapon system has been tested using a temporary enemy object with an EnemyHealth component. Raycast detection was corrected by excluding the Player layer from the weapon's hit layers.

### Phase 4 – Enemy AI & Navigation (In Progress)

Started implementing enemy movement and AI using Unity's AI Navigation package.

**Implemented:**
- Installed AI Navigation.
- Added NavMesh Surface to the arena ground.
- Baked the navigation mesh.
- Added NavMesh Agent to the enemy.
- Configured enemy movement parameters.
- Created `EnemyAI.cs`.
- Tested enemy navigation and player chasing.

**Current development status:**

- Basic NavMesh movement works.
- Enemy can follow the player when continuous chasing is enabled.
- Detection range and line-of-sight behaviour are being implemented.
- Last-known-player-position tracking is being developed.

The line-of-sight detection currently needs further debugging before this phase can be considered complete.

## 📂 Current Project Structure

```text
Assets/
│
├── Scenes/
│   └── SurvivalArena.unity
│
├── Scripts/
│   ├── PlayerController.cs
│   ├── VirtualJoystick.cs
│   ├── TouchCamera.cs
│   ├── MobileInput.cs
│   ├── PauseButton.cs
│   ├── WeaponController.cs
│   ├── EnemyHealth.cs
│   └── EnemyAI.cs
│
├── Prefabs/
│   └── (To be organized)
│
├── Materials/
│   └── (To be organized)
│
└── UI/
    └── (UI elements currently organized in the scene)
```

*Note: The structure above represents the intended organization of the scripts and assets. Some folders may still need to be created or organized in the Unity project.*

## 🎮 Current Controls

| Action | Control |
|---|---|
| Move | Virtual joystick |
| Look Around | Touch on right-side screen area |
| Sprint | Sprint button |
| Jump | Jump button |
| Shoot | Fire button |
| Reload | Reload button |
| Switch Weapon | Switch button |
| Pause | Pause button |

For editor testing, player movement and camera controls can also be tested using keyboard and mouse.

## 🚧 Upcoming Development

The following features are planned but have not yet been completed.

### Phase 5 – Advanced Enemy AI
- Complete player detection and line-of-sight.
- Implement last-known-position tracking.
- Add melee enemy behaviour.
- Add ranged enemy behaviour.
- Introduce boss enemy behaviour.
- Configure enemy attack and damage systems.

### Phase 6 – Wave & Mission System
- Implement five enemy waves.
- Configure enemy counts for each wave.
- Introduce three communication terminals.
- Implement the extraction objective.
- Add wave progression and completion logic.

### Phase 7 – HUD & Inventory
- Health and ammunition display.
- Weapon information.
- Wave counter.
- Mission objective indicators.
- Inventory management.
- Responsive UI and safe-area support.

### Phase 8 – Game States & Saving
- Main menu.
- Pause and resume functionality.
- Game over screen.
- Mission completion screen.
- Local save system.

### Phase 9 – Optimization & Android Build
- Object pooling for enemies, projectiles, and hit effects.
- Mobile performance optimization.
- Android build configuration.
- Device testing.
- APK generation.

## 📌 Current Project Status

| System | Status |
|---|---|
| Unity project setup | Completed |
| Survival arena | Completed |
| Player movement | Implemented |
| Camera control | Implemented |
| Mobile touch controls | Implemented |
| Pause menu | Implemented |
| Weapon shooting | Implemented |
| Reloading and ammunition | Implemented |
| Weapon switching | Implemented |
| Enemy health and damage | Implemented |
| NavMesh navigation | Working |
| Enemy chasing | Basic version working |
| Enemy detection and line-of-sight | In Progress |
| Wave system | Pending |
| Mission objectives | Pending |
| Extraction system | Pending |
| Inventory and HUD | Pending |
| Save system | Pending |
| Android optimization and final build | Pending |

## 🎯 Project Goal

Build a complete 3D mobile survival and extraction game with responsive touch controls, multiple weapons, intelligent enemy behaviour, progressive enemy waves, mission objectives, and an extraction-based ending.

The project is being developed incrementally, with each gameplay system implemented and tested before moving to the next phase.

---

**Engine:** Unity 6  
**Language:** C#  
**Rendering:** Universal Render Pipeline (URP)  
**Target Platform:** Android  
**Project Type:** 3D Survival / Extraction Game
