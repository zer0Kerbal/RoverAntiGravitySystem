# Changelog  
  
| modName    | Rover Anti Gravity System (RAGS)                                    |
| ---------- | ------------------------------------------------------------------- |
| license    | CC-BY-NC-SA-4.0                                                     |
| author     | ximrm, Tuareg and zer0Kerbal                                        |
| forum      | (https://forum.kerbalspaceprogram.com/index.php?/topic/208483-*/)   |
| github     | (https://github.com/zer0Kerbal/zer0Kerbal/RoverAntiGravitySystem)   |
| curseforge | (https://www.curseforge.com/kerbal/ksp-mods/RoverAntiGravitySystem) |
| spacedock  | (https://spacedock.info/mod/)                                       |
| ckan       | RoverAntiGravitySystem                                              |

## Version 1.1.99.0-adoption `<EDITION>` edition

* 15 Jun 2022
* Released for Kerbal Space Program 1.12.x

### Adoption

### Localization

* Create
  * Localization/
    * <en-us.cfg>
    * [readme.md] v2.1.1.0
    * [quickstart.md] v1.0.1.0
  * updates #5 - Localization - Master
  * closes #6 - English <us-en.cfg>
  * closes #24 - Part Localization
  * closes #25 - Code Localization

### docs/

* Update
  * [Attribution.md] v1.0.6.0
  * [ManualInstallation.md] v1.1.7.0
* Add
  * [404.md] v1.0.3.1
  * [Disclaimer.md] v1.0.0.0
  * [LegalMumboJumbo.md] v1.0.5.0
  * [Localizations.md] v1.1.3.1
  * [Marketing.md] v1.0.0.0
  * [Notices.md] v1.0.0.0
  * [PartInvoice.md] v1.1.3.1
  * [Why.md] v1.1.0.0
  * [_config.yml]

### Previous Release Archive Creation

* Previous Releases
  * 1.0.0.0.release
  * 1.1.0.0.release
  * 1.1.1.0.release
  * 1.1.2.0.release
  * 1.1.4.0.release
* closes #26 - Previous Releases
* closes #27 - 1.0.0.0.release
* closes #28 - 1.1.0.0.release
* closes #29 - 1.1.1.0.release
* closes #30 - 1.1.2.0.release
* closes #31 - 1.1.4.0.release


### Status

* Issues
  * closes #1 - Rover Anti Gravity System (RAGS) 1.1.99.0-adoption <NAME>
  * closes #2 - 1.1.99.0 Verify Legal Mumbo Jumbo
  * closes #3 - 1.1.99.0 Create Documentation
  * closes #4 - 1.1.99.0 Create Social Media


### docs/

* Update
  * [Attribution.md] v1.0.6.0
  * [ManualInstallation.md] v1.1.7.0
* Add
  * [404.md] v1.0.3.1
  * [Disclaimer.md] v1.0.0.0
  * [LegalMumboJumbo.md] v1.0.5.0
  * [Localizations.md] v1.1.3.1
  * [Marketing.md] v1.0.0.0
  * [Notices.md] v1.0.0.0
  * [PartInvoice.md] v1.1.3.1
  * [Why.md] v1.1.0.0
  * [_config.yml]

### Previous Release Archive Creation

* Previous Releases
  * 1.0.0.0-release
  * 1.1.0.0-release
  * 1.1.1.0-release
  * 1.1.2.0-release
  * 1.1.4.0-release
* closes #26 - Previous Releases
* closes #27 - 1.0.0.0-release
* closes #28 - 1.1.0.0-release
* closes #29 - 1.1.1.0-release
* closes #30 - 1.1.2.0-release
* closes #31 - 1.1.4.0-release

* Nov 24, 2015
* Released for Kerbal Space Program 1.0.5
* by ximrm and Tuareg

### Status

* Issues
  * closes #
  * updates #

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

### Status

* Issues
  * updates #26 - Previous Releases
  * closes #31 - 1.1.4.0.release

---

## Version 1.1.2.0-release

* 01 Feb 2015
* Released for Kerbal Space Program 1.0.5
* by ximrm and Tuareg

### Update

* [agModule.cfg]
  * [node_stack_bottom] from 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0 to 0.0, 0.0, 0.0, 0.0, -1.0, 0.0, 0
  * [category] from Structural to Utility
  * [mass] from 1 to 0.2
  * [attachRules] from 1,1,1,1,0 to 1,1,1,0,0

### Code

* Changes
  * from [public static int selectedCelestial = 0;] to [public int selectedCelestial = 0;]
  * from [public static double Consumption = 0.5;] to [public float Consumption = 0.5f;]
* [RoverAntiGravitySystem.dll] v1.1.2.35

### Status

* Issues
  * updates #26 - Previous Releases
  * closes #30 - 1.1.2.0.release

---

## Version 1.1.1.0-release

* 13 Jan 2015
* Released for Kerbal Space Program 1.0.5
* by ximrm and Tuareg

### Changes

* Add license.url
* [RoverAntiGravitySystem.dll] v1.1.1.34

### Status

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

### Code

* Rename
  * Box002 to buttonGreen
  * Box003 to buttonRed
* Add Hotkey (keypad 5)
* this.myAnimation["switch"].speed = 1 from 5;
* [RoverAntiGravitySystem.dll] v1.1.0.33
  
### Status

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

### Status

* Issues
  * updates #26 - Previous Releases
  * closes #27 - 1.0.0.0-release

---
