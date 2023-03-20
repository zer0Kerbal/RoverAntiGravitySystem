---
permalink: /Changelog.html
title: The Change Log
description: The Opening Credits, and the closing credits, plus the first of two (or is three) end credit scenes
tags: changes,changelog,change-log,page,kerbal,ksp,zer0Kerbal,zedK
---
<!-- 
hdr-changelog.md v1.0.0.0
Rover Anti Gravity System (RAGS)
created: 13 May 2022
updated:
CC BY-ND 4.0 by zer0Kerbal
--># Changelog  
  
| modName    | Rover Anti Gravity System (RAGS)                                    |
| ---------- | ------------------------------------------------------------------- |
| license    | GPL-2.0                                                             |
| author     | ximrm, Tuareg and zer0Kerbal                                        |
| forum      | (https://forum.kerbalspaceprogram.com/index.php?/topic/208483-*/)   |
| github     | (https://github.com/zer0Kerbal/zer0Kerbal/RoverAntiGravitySystem)   |
| curseforge | (https://www.curseforge.com/kerbal/ksp-mods/RoverAntiGravitySystem) |

## Version 1.7.0.0-release `<There's No Place Like Kerbin>`

* 19 Mar 2023
* Released for Kerbal Space Program 1.9.1
* by [zer0Kerbal](https://github.com/zer0Kerbal)

* Recompile for 1.9.1
* <RoverAntiGravitySystem.dll>  v1.6.0.108 --> v1.7.0.111

### Status 1.7.0.0

* Issues
  * closes #47 - KSP 1.9.x
  * updates #38 - Recompile for major KSP version

---

## Version 1.6.0.0-release `<Moar Antigons!!!>`

* 22 Dec 2022
* Released for Kerbal Space Program 1.8.1
* by zer0Kerbal

## Summary 1.6.0.0

* Recompile for 1.8.1
* <RoverAntiGravitySystem.dll>  v1.5.0.107 --> v1.6.0.108

### Status 1.6.0.0

* Issues
  * closes #46 - KSP 1.8.1
  * updates #38 - Recompile for major KSP version

---

## Version 1.5.0.0-release `<Room to Fly>`

* 7 Jun, 2022
* Released for Kerbal Space Program 1.7.3
* by zer0Kerbal

* Recompile for 1.7.3
* <RoverAntiGravitySystem.dll> v1.4.0.106 --> v1.5.0.107
* <rags-agmodule.cfg> v1.2.1.0
  * add ModuleCargoPart (early)
  * reduced resource consumption from 0.5 to 0.05
    * future will make it scale based upon vessel gross mass

### Code 1.5.0.0

* .OnActive
  * allow for [ModuleEnginesFX]
  * if (pm.moduleName.Contains("ModuleEngines") | pm.moduleName.Contains("ModuleEnginesFX"))
* closes #88 - [BUG] .OnActive () throwing err

### Status 1.5.0.0

* Issues
  * updates #38 - Recompile for major KSP version
  * closes #45 - KSP 1.7.x
  * updates #85 - [Request]: resource consumption
  * closes #87 - Add ModuleCargoPart

---

## Version 1.4.0.0-release `<To Hover or not To Hover>`

* 16 Dec 2022
* Released for Kerbal Space Program 1.6.1
* by zer0Kerbal

* Recompile for 1.6.1
* <RoverAntiGravitySystem.dll> v1.3.0.105 --> v1.4.0.106

### Status 1.4.0.0

* Issues
  * closes #44 - KSP 1.6.1
  * updates #38 - Recompile for major KSP version

---

## Version 1.3.0.0-release `<Dressed for Flight>`

* 15 Dec 2022
* Released for Kerbal Space Program 1.5.1
* by zer0Kerbal

* Recompile for 1.5.1
* <RoverAntiGravitySystem.dll> v1.2.0.104 --> v1.3.0.105

### Status 1.3.0.0

* Issues
  * closes #43 - KSP 1.5.1
  * updates #38 - Recompile for major KSP version

---

## Version 1.2.0.0-release `<Remaking History>`

* 15 Dec 2022
* Released for Kerbal Space Program 1.4.5
* by zer0Kerbal

* Recompile for 1.4.5
* <RoverAntiGravitySystem.dll> v1.1.75.103 --> v1.2.0.104
* Create hero logo/cover
* Updated License: GPL-2.0 + CC BY-SA 4.0
  * was: CC BY-SA 4.0
* Rename
  * part
  * part file
  * module
* Add
  * <ghostparts.cfg> v1.3.0.0
  * <RoverAntiGravitySystem.cfg> v1.0.0.0
* Update
  * <en-us.cfg> v1.1.1.0

### Status 1.2.0.0

* Issues
  * closes #42 - KSP 1.4.5
  * updates #38 - Recompile for major KSP version
  * updates #5 - Localization - Master
  * updates #6 - English <us-en.cfg>
  * closes #78 - Create HeroLogo.png
  * closes #77 - Update License

---

## Version 1.1.7.5-release - `<Away With Words>` edition

* 15 Jun, 2022
* Released for Kerbal Space Program 1.3.x
* by zer0Kerbal

### Recompile for 1.3.x

* x64 bit only
* Away With Words - Localization
* <RoverAntiGravitySystem.dll> v1.1.75.103

* Update

* Rename
  * [agmodule.cfg] to [roverantigrav.cfg]
    * [agModule] to [RoverAntiGravitySystemModule]
    * [title] from #RAGS-agmodul-titl to #RAGS-titl
    * [description] = #RAGS-agmodul-desc to #RAGS-desc
    * [tags] from #RAGS-agmodul-tags to #RAGS-tags

### Code

* [RoverAntiGravitySystem.dll] v1.1.7.103
* [Bug 🐞]: Module switches off unexpectantly
  * fixed
  * declaration of variable `Consumption` was changed from float to double
    * was: `public float Consumption = 0.5f;`
    * to: `public double Consumption = 0.5;`
  * changing back to float fixed issue
  * closes #74 - [Bug 🐞]: Module switches off unexpectantly
* [Bug 🐞]: buttons not changing color
  * fixed
  * Color.green -> Color.black (line 147)
  * Color.red -> Color.black (line 148)
  * closes #73 - [Bug 🐞]: buttons not changing color
* Update
  * Localization
  * tightening white space
  * tightening if's, suggested by @Lisias
    * combine several nested if's into one
    * if (isOn && isSwitching)
    * if (isOn && !thereIsAnEngine)
* [Consumption]
  * change from float to *readonly double*
  * should this scale with the mass of the rover?
* Move array construction out of
  * [OnStart]
  * into:
    * [GetGravities]
    * [GetCelestials]
* Add
  * GetInfo()
    * localized
  * RateString();
    * localized
* closes #64 - Add GetInfo()
* closes #63 - localize code

### Localization 1.1.7.5

* Create
  * Localization/
    * <en-us.cfg>
    * [readme.md] v2.1.1.0
    * [quickstart.md] v1.0.1.0
* Part
  * create
    * agency
    * Flag
    * scaled.truecolor
  * run localizer
* Parts to localize
  * [agmodule.cfg]
* Code
  * settings
  * GUI
  * screen
  * PAW
  * InstallChecker
  * scrap KSP dictionary
  * updates #5 - Localization - Master
  * closes #6 - English <us-en.cfg>
  * closes #24 - Part Localization
  * closes #25 - Code Localization

### docs/ 1.1.7.5

* Add
  * [ManualInstallation.md] v1.1.7.0
  * [Attribution.md] v1.0.6.0
  * [404.md] v1.0.3.1
  * [Disclaimer.md] v1.0.0.0
  * [LegalMumboJumbo.md] v1.0.5.0
  * [Localizations.md] v1.1.3.1
  * [Marketing.md] v1.0.0.0
  * [Notices.md] v1.0.0.0
  * [PartInvoice.md] v1.1.3.1
  * [Why.md] v1.1.0.0
  * [_config.yml]
* closes #71 - docs/

### Status 1.1.7.5

* Issues
  * closes #41 - KSP 1.3.x
  * updates #38 - Recompile for major KSP version

---

## Version 1.1.7.0-release

* 7 Jun, 2022
* Released for Kerbal Space Program 1.3.x
* by zer0Kerbal

### Recompile for 1.3.x

* x64 bit only
* released for KSP 1.3.x
* KSP minimum version updated to 1.3.0

### Code 1.1.7.0

* Rename
  * [agModule.cs] to [RoverAntiGravitySystemModule.cs]
  * [nextGravitySetupEvent] to [NextGravitySetupEvent]
  * [prevGravitySetupEvent] to [prevGravitySetupEvent]
  * [onSwitch] to [OnSwitch]
* [RoverAntiGravitySystem.dll] v1.1.7.68

### Status 1.1.7.0

* Issues
  * updates #41 - KSP 1.3.x
  * updates #38 - Recompile for major KSP version

---

## Version 1.1.6.0-release

* 7 Jun, 2022
* Released for Kerbal Space Program 1.2.x
* by zer0Kerbal

### Recompile for 1.2.x

* x64 bit only

* Update
  * [agmodule.cfg]
    * [category] from Utility to Control
    * linting
    * some light remodeling

### Code 1.1.6.0

* Update
  * CS1061 error
    * .findWorldCenterOfMass() --> .COMD
* closes #55 - CS1061: findWorldCenterOfMass
* [RoverAntiGravitySystem.dll] v1.1.6.67

### Status 1.1.6.0

* Issues
  * closes #40 - KSP 1.2.x
  * updates #38 - Recompile for major KSP version

---

## Version 1.1.5.0-release

* 7 Jun, 2022
* Released for Kerbal Space Program 1.1.x
* by zer0Kerbal

### Recompile for 1.1.x

* x64 bit only

* Update
  * [agmodule.cfg]
    * [category] from Utility to Control
    * linting
    * some light remodeling

### Code 1.1.5.0

* Update
  * CS1061 error
    * .renderer.material --> GetComponent<Renderer>
    * this.vessel.rigidbody. --> Rigidbody vs = this.vessel.GetComponent<Rigidbody>();
* closes #53 - CS1061: Renderer
* closes #54 - CS1061: Rigidbody
* [RoverAntiGravitySystem.dll] v1.1.5.36

### Status 1.1.5.0

* Issues
  * closes #39 - KSP 1.1.x
  * updates #38 - Recompile for major KSP version

---

## Version 1.1.4.0-release

* 25 Nov 2015
* Released for Kerbal Space Program 1.0.5
* by ximrm and Tuareg

* Add
  * Compatibility
    * [ActiveTextureManager.cfg] v1.0.0.0
* Convert
  * [agr-moremetall-diff] from .png to .dds
  * [green.png] from 8x8 to 4x4
  * [red.png] from 8x8 to 4x4
* Note: do not convert the png's
* Code
  * [RoverAntiGravitySystem.dll] v1.1.4.36
* Update
  * [agModule.cfg]
    * [crashTolerance] from 1 to 11
    * [maxTemp] from 300 to 1650
    * [bulkheadProfiles] = size0
    * [minimum_drag] from 0.2 to 0.1
    * [mass] from 0.2 to 0.045
    * [description] add "Can't change atmospheric influences. Only to be used on rovers!"
    * [title] correct case
    * [manufacturer] correct manufacturer's name
    * [TechRequired] from composites to specializedElectrics
    * [cost] from 16 to 2600

### Status 1.1.4.0

* Issues
  * updates #26 - Previous Releases
  * closes #31 - 1.1.4.0.release

---

## Version 1.1.2.0-release

* 01 Feb 2015
* Released for Kerbal Space Program 1.0.5
* by ximrm and Tuareg

### Update 1.1.2.0

* [agModule.cfg]
  * [node_stack_bottom] from 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0 to 0.0, 0.0, 0.0, 0.0, -1.0, 0.0, 0
  * [category] from Structural to Utility
  * [mass] from 1 to 0.2
  * [attachRules] from 1,1,1,1,0 to 1,1,1,0,0

### Code 1.1.2.0

* Changes
  * from [public static int selectedCelestial = 0;] to [public int selectedCelestial = 0;]
  * from [public static double Consumption = 0.5;] to [public float Consumption = 0.5f;]
* [RoverAntiGravitySystem.dll] v1.1.2.35

### Status 1.1.2.0

* Issues
  * updates #26 - Previous Releases
  * closes #30 - 1.1.2.0.release

---

## Version 1.1.1.0-release

* 13 Jan 2015
* Released for Kerbal Space Program 1.0.5
* by ximrm and Tuareg

### Changes 1.1.1.0

* Add license.url
* [RoverAntiGravitySystem.dll] v1.1.1.34

### Status 1.1.1.0

* Issues
  * updates #26 - Previous Releases
  * closes #29 - 1.1.1.0.release

---

## Version 1.1.0.0-release

* 05 Jan 2015
* Released for Kerbal Space Program 1.0.5
* by ximrm and Tuareg

* [agModule.cfg]
  * [rescaleFactor] from 1 to 2
* changes
  * [agModule.mu]
* add
  * [agr-moremetall-diff.png]

### Code 1.1.0.0

* Rename
  * Box002 to buttonGreen
  * Box003 to buttonRed
* Add Hotkey (keypad 5)
* this.myAnimation["switch"].speed = 1 from 5;
* [RoverAntiGravitySystem.dll] v1.1.0.33
  
### Status 1.1.0.0

* Issues
  * updates #26 - Previous Releases
  * closes #28 - 1.1.0.0-release

---

## Version 1.0.0.0-release

* 03 Jan 2015
* Released for Kerbal Space Program 1.0.5
* by ximrm and Tuareg

* Initial release
* [RoverAntiGravitySystem.dll] v1.0.0.32
* Recompiled by zer0Kerbal
* Slight updates to bring up to modern standards

### Status 1.0.0.0

* Issues
  * updates #26 - Previous Releases
  * closes #27 - 1.0.0.0-release

---
