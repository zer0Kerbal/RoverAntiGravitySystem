---
permalink: /ManualInstallation.html
title: Manual Installation
description: the flat-pack Kiea instructions, written in Kerbalese, unusally present
tags: installation,directions,page,kerbal,ksp,zer0Kerbal,zedK
---
<!-- ManualInstallation.md v1.1.8.1
Rover Anti Gravity System (RAGS)
created: 01 Oct 2019
updated: 29 Jul 2022 -->

<!-- based upon work by Lisias -->

# Rover Anti Gravity System (RAGS)

[Home](./index.md)

> And an other new release from your Lunatic scientists:
>
> Theeeee Rover gravity manipulator!
>
> A module to manipulate the gravity affecting your rover
>
> You can choose which planet or moon settings you want to apply, turn it on and flyyyyyyyyyy.
>
> Sadly our scientist were not able to solve the problem of conflicting with engine electronics.

## Installation Instructions

### Using CurseForge/OverWolf app or CKAN

You should be all good! (check for latest version on CurseForge)

### If Downloaded from CurseForge/OverWolf manual download

To install, place the `LunaticAeronautics` folder inside your Kerbal Space Program's GameData folder:

* **REMOVE ANY OLD VERSIONS OF THE PRODUCT BEFORE INSTALLING**
  * Delete `<KSP_ROOT>/GameData/LunaticAeronautics/RoverAntiGravitySystem`
* Extract the package's `LunaticAeronautics` folder into your KSP's GameData folder as follows:
  * `<PACKAGE>/LunaticAeronautics` --> `<KSP_ROOT>/GameData`
    * Overwrite any preexisting folder/file(s).
  * you should end up with `<KSP_ROOT>/GameData/LunaticAeronautics/RoverAntiGravitySystem`

### If Downloaded from SpaceDock / GitHub / other

To install, place the `GameData` folder inside your Kerbal Space Program folder:

* **REMOVE ANY OLD VERSIONS OF THE PRODUCT BEFORE INSTALLING**
  * Delete `<KSP_ROOT>/GameData/LunaticAeronautics/RoverAntiGravitySystem`
* Extract the package's `GameData` folder into your KSP's root folder as follows:
  * `<PACKAGE>/GameData` --> `<KSP_ROOT>`
    * Overwrite any preexisting file.
  * you should end up with `<KSP_ROOT>/LunaticAeronautics/GameData/RoverAntiGravitySystem`

## The following file layout must be present after installation

```markdown
<KSP_ROOT>
  + [GameData]
    + [LunaticAeronautics]
      + [LunaticAeronauticsLtd]
        ...
      + [RoverAntiGravitySystem]
        + [Compatibility]
          ...
        + [Localization]
          ...
        + [Parts]
          ...
        + [Plugins]
          ...
        * #.#.#.#.htm
        * Attributions.htm
        * changelog.md
        * GPL-2.0.txt
        * ManualInstallation.htm
        * readme.htm
        * RoverAntiGravitySystem.version
    ...
    * ModuleManager.ConfigCache
  * KSP.log
  ...
```

### Dependencies

* [Lunatic Aeronautics Ltd (LA/L)][LAL]

[LAL]: https://forum.kerbalspaceprogram.com/index.php?/topic/191424-*/ "Lunatic Aeronautics Ltd (LAL)"
