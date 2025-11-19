# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

This is a Unity 2D tutorial project - a Flappy Bird-style game. Built with Unity 6 (6000.0) using the Universal Render Pipeline (URP) 2D template.

## Key Architecture

### Game Scripts (Assets/)

- **BirdScript.cs**: Player controller with flap mechanics and collision detection
  - Uses `Rigidbody2D.linearVelocity` for physics-based movement
  - `isAlive` flag controls input and game state
  - References LogicScript via GameObject tag "Logic"

- **PipeSpawnScript.cs**: Procedural obstacle generation
  - Spawns pipes at regular intervals (`spawnRate`)
  - Randomizes vertical position within `heightOffset` range
  - Uses `Time.deltaTime` for timer

- **PipeMoveScript.cs**: Obstacle movement and cleanup
  - Moves pipes left at constant `moveSpeed`
  - Auto-destroys when reaching `deadZone` (-45 units)

- **PipeMiddleScript.cs**: Score trigger detection
  - Uses `OnTriggerEnter2D` to detect bird passing through pipes
  - Checks for layer 3 (bird layer) before awarding points
  - References LogicScript for score updates

- **LogicScript.cs**: Game state manager
  - Manages player score and UI (`scoreText`)
  - Controls game over screen
  - Scene reloading via `SceneManager.LoadScene()`
  - Uses `[ContextMenu]` for testing

### Unity Configuration

- Scene: `Assets/Scenes/SampleScene.unity`
- Uses Unity's new Input System (com.unity.inputsystem 1.11.2)
- Layer 3 is reserved for the bird/player

## Development Commands

This is a Unity project - there are no CLI build commands. Development is done through the Unity Editor.

To work with this project:
1. Open the project folder in Unity Editor
2. Open SampleScene.unity from Assets/Scenes/
3. Use Unity's Play mode to test
4. Scripts auto-compile when saved
