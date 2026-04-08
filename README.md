# 🎮 Open World Treasure Hunt

**Open World Treasure Hunt** is a high-fidelity 3D exploration game developed in **Unity 6.3 (URP)**. The project focuses on procedural world-generation, advanced raycast-based interactions, and dynamic game-state management. Players are tasked with navigating a massive environment to locate hidden treasures before the temporal mission window expires.

This project was developed as a **Bachelor of Technology (B.Tech)** Professional Elective Project at **SR University, Warangal**.

---

## 🚀 Key Technical Features

* **🛠️ Procedural Asset Spawning:** Dynamically populates the 4km² terrain (-1500 to +1500 coordinates) with loot using `Physics.Raycast` for perfect grounding at runtime.
* **📡 Raycast Interaction System:** Implements a camera-vector interaction model using the **'E' key**, replacing traditional collision triggers for higher gameplay precision.
* **🗺️ Dynamic Radar System:** A real-time UI compass that tracks treasure distance and converts Unity units into **"Paces"** for intuitive navigation.
* **⏱️ Balanced Mission Timer:** A backend algorithm that calculates a fair time limit based on the actual spatial distribution of spawned assets.
* **🌫️ URP Local Volumes:** Immersive "Cursed Fog" zones that trigger green color shifts and vignettes as players approach targets.
* **🔄 Integrated Game Loop:** Complete state management from procedural initialization to the final **"Mission Completed"** victory state.

---

## 🛠️ Installation & Setup

1. **Clone the Repository:** `git clone https://github.com/2403A51L03/Open-World-Treasure-Hunt-Game.git`
2. **Unity Version:** Open the project in **Unity 6 (v6.3 recommended)**.
3. **Pipeline:** Ensure the **Universal Render Pipeline (URP)** is active in Graphics Settings.
4. **Play:** Load the `MainScene` and press Play! 🎉

---

## 🎮 How to Play

### **Controls**
* **W / A / S / D:** Move Explorer
* **Mouse:** Look / Aim Camera
* **Space:** Jump
* **E:** Interact / Collect Treasure (When in range)

### **Gameplay Flow**
1. **Explore:** Use the radar at the top of the HUD to find the nearest treasure.
2. **Scavenge:** Enter the green fog zones and locate the chest. 
3. **Interact:** Center your view on the chest and press **E** to collect.
4. **Win:** Collect all spawned treasures before the timer hits zero to achieve **"Mission Completed"**.

---

## 📂 Project Structure

### **🔧 Core Scripts**
* `TreasureSpawner.cs` → Handles procedural coordinate generation and raycast grounding.
* `GameManager.cs` → Singleton pattern managing game states, timer, and win/loss conditions.
* `InteractionSystem.cs` → Manages raycasting from camera to detect interactable tags.
* `RadarUI.cs` → Updates HUD distance and paces metrics.
