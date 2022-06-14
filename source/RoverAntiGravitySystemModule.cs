using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using KSP;
using KSP.UI.Screens;
using KSP.Localization;

namespace RoverAntiGravitySystem
{
    public class RoverAntiGravitySystemModule : PartModule
    {
        [KSPField(isPersistant = false)]
        public float GeeMoho = 2.59f;

        [KSPField(isPersistant = false)]
        public float GeeEve = 16.66f;

        [KSPField(isPersistant = false)]
        public float GeeGilly = 0.03f;

        [KSPField(isPersistant = false)]
        public float GeeKerbin = 9.81f;

        [KSPField(isPersistant = false)]
        public float GeeMun = 1.62f;

        [KSPField(isPersistant = false)]
        public float GeeMinmus = 0.43f;

        [KSPField(isPersistant = false)]
        public float GeeDuna = 2.88f;

        [KSPField(isPersistant = false)]
        public float GeeIke = 1.01f;

        [KSPField(isPersistant = false)]
        public float GeeDres = 1.10f;

        [KSPField(isPersistant = false)]
        public float GeeLaythe = 7.85f;

        [KSPField(isPersistant = false)]
        public float GeeVall = 2.27f;

        [KSPField(isPersistant = false)]
        public float GeeTylo = 7.78f;

        [KSPField(isPersistant = false)]
        public float GeeBop = 0.35f;

        [KSPField(isPersistant = false)]
        public float GeePol = 0.36f;

        [KSPField(isPersistant = false)]
        public float GeeEeloo = 1.66f;

        [KSPField(isPersistant = true)]
        public int selectedCelestial = 0;

        [KSPField(isPersistant = true)]
        public readonly double Consumption = 0.5f; // should this scale with the mass of the rover?

        public readonly string[] Celestials = new string[15];
        public readonly float[] Gravities = new float[15];

        public float gravity = 0;

        public bool isOn = false;
        public bool thereIsAnEngine = false;
        public bool isSwitching = false;

        private Animation myAnimation;

        public float[] GetGravities()
        {
            Gravities[0] = GeeMoho;
            Gravities[1] = GeeEve;
            Gravities[2] = GeeGilly;
            Gravities[3] = GeeKerbin;
            Gravities[4] = GeeMun;
            Gravities[5] = GeeMinmus;
            Gravities[6] = GeeDuna;
            Gravities[7] = GeeIke;
            Gravities[8] = GeeDres;
            Gravities[9] = GeeLaythe;
            Gravities[10] = GeeVall;
            Gravities[11] = GeeTylo;
            Gravities[12] = GeeBop;
            Gravities[13] = GeePol;
            Gravities[14] = GeeEeloo;
            return Gravities;
        }
        public string[] GetCelestials()
        {
            Celestials[0] = Localizer.Format("#autoLOC_910051"); // Moho^N
            Celestials[1] = Localizer.Format("#autoLOC_910049"); // Eve^N
            Celestials[2] = Localizer.Format("#autoLOC_910037"); // Gilly^N
            Celestials[3] = Localizer.Format("#autoLOC_910048"); // Kerbin^N
            Celestials[4] = Localizer.Format("#autoLOC_910035"); // The Mun^N
            Celestials[5] = Localizer.Format("#autoLOC_910033"); // Minmus^N
            Celestials[6] = Localizer.Format("#autoLOC_910045"); // Duna^N
            Celestials[7] = Localizer.Format("#autoLOC_910031"); // Ike^N
            Celestials[8] = Localizer.Format("#autoLOC_910043"); // Dres^N
            Celestials[9] = Localizer.Format("#autoLOC_910029"); // Laythe^N
            Celestials[10] = Localizer.Format("#autoLOC_910027"); // Vall^N
            Celestials[11] = Localizer.Format("#autoLOC_910025"); // Tylo^N
            Celestials[12] = Localizer.Format("#autoLOC_910023"); // Bop^N
            Celestials[13] = Localizer.Format("#autoLOC_910021"); // Pol^N
            Celestials[14] = Localizer.Format("#autoLOC_910039"); // Eeloo^N
            return Celestials;
        }

        public override void OnStart(PartModule.StartState state)
        {
            base.OnStart(state);

            GetCelestials();
            GetGravities();

            this.part.force_activate();

            gravity = Gravities[selectedCelestial];

            Events["NextGravitySetupEvent"].guiName = Localizer.Format("#RAGS-NextGravSetup", Celestials[selectedCelestial], (selectedCelestial != 14 ? Celestials[selectedCelestial + 1] : Celestials[0]));
            Events["PrevGravitySetupEvent"].guiName = Localizer.Format("#RAGS-PrevGravSetup", Celestials[selectedCelestial], (selectedCelestial != 0 ? Celestials[selectedCelestial - 1] : Celestials[14]));

            // #RAGS-NextGravSetup = Current <b><<1>></b>. Next: <b><<2>></b>.
            //Events["NextGravitySetupEvent"].guiName = "Current: " + Celestials[selectedCelestial] + ". Next: " + (selectedCelestial != 14 ? Celestials[selectedCelestial + 1] : Celestials[0]) + ".";
            //Events["PrevGravitySetupEvent"].guiName = "Current: " + Celestials[selectedCelestial] + ". Prev: " + (selectedCelestial != 0 ? Celestials[selectedCelestial - 1] : Celestials[14]) + ".";

            myAnimation = this.part.GetComponentInChildren<Animation>();
            this.myAnimation["switch"].wrapMode = WrapMode.Once;

            isOn = false;

            this.gameObject.GetChild("buttonGreen").GetComponent<Renderer>().material.SetColor("_EmissiveColor", Color.green);
            this.gameObject.GetChild("buttonRed").GetComponent<Renderer>().material.SetColor("_EmissiveColor", Color.black);

        }

        public override void OnActive()
        {
            base.OnActive();

            thereIsAnEngine = false;

            foreach (Part p in this.vessel.rootPart.children)
            {
                foreach (PartModule pm in p.Modules)
                {
                    if (pm.moduleName.Contains("ModuleEngines"))
                        thereIsAnEngine = true;
                }
            }
        }

        public override void OnAwake() { base.OnAwake(); }
        public override void OnInactive() { base.OnInactive(); }
        public override void OnInitialize() { base.OnInitialize(); }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (Input.GetKeyDown(KeyCode.Keypad5))
            {
                isOn = !isOn;
                isSwitching = true;
            }

            if (isSwitching)
            {
                if (isOn)
                {
                    this.myAnimation["switch"].time = 0;
                    this.myAnimation["switch"].speed = 1;
                    this.myAnimation.Play("switch");

                    this.gameObject.GetChild("buttonGreen").GetComponent<Renderer>().material.SetColor("_EmissiveColor", Color.black);
                    this.gameObject.GetChild("buttonRed").GetComponent<Renderer>().material.SetColor("_EmissiveColor", Color.red);

                    isSwitching = false;
                }
                else // = !isON
                {
                    this.myAnimation["switch"].time = this.myAnimation["switch"].length;
                    this.myAnimation["switch"].speed = -1;
                    this.myAnimation.Play("switch");

                    this.gameObject.GetChild("buttonGreen").GetComponent<Renderer>().material.SetColor("_EmissiveColor", Color.green);
                    this.gameObject.GetChild("buttonRed").GetComponent<Renderer>().material.SetColor("_EmissiveColor", Color.black);

                    isSwitching = false;
                }
            }

            //if (isOn && isSwitching)
            //{
            //    this.myAnimation["switch"].time = 0;
            //    this.myAnimation["switch"].speed = 1;
            //    this.myAnimation.Play("switch");

            //    this.gameObject.GetChild("buttonGreen").GetComponent<Renderer>().material.SetColor("_EmissiveColor", Color.green);
            //    this.gameObject.GetChild("buttonRed").GetComponent<Renderer>().material.SetColor("_EmissiveColor", Color.black);

            //    isSwitching = false;
            //}
            //else if (!isOn && isSwitching)
            //{
            //    this.myAnimation["switch"].time = this.myAnimation["switch"].length;
            //    this.myAnimation["switch"].speed = -1;
            //    this.myAnimation.Play("switch");

            //    this.gameObject.GetChild("buttonGreen").GetComponent<Renderer>().material.SetColor("_EmissiveColor", Color.green);
            //    this.gameObject.GetChild("buttonRed").GetComponent<Renderer>().material.SetColor("_EmissiveColor", Color.black);

            //    isSwitching = false;
            //}

        }

        public override void OnFixedUpdate()
        {
            base.OnFixedUpdate();

            if (isOn && !thereIsAnEngine)
            { 
                if (this.part.RequestResource("ElectricCharge", Consumption) >= Consumption)
                {
                    Rigidbody vs = this.vessel.GetComponent<Rigidbody>(); ;

                    vs.AddForceAtPosition(-FlightGlobals.getGeeForceAtPosition(this.vessel.CoMD) * this.vessel.GetTotalMass(), this.vessel.CoMD);
                    vs.AddForceAtPosition(-FlightGlobals.getCentrifugalAcc(this.vessel.CoMD, this.vessel.mainBody) * this.vessel.GetTotalMass(), this.vessel.CoMD);
                }
                else
                {
                    isOn = false;
                    isSwitching = true;
                }
            }
            else
            {
                this.myAnimation["switch"].time = 0;

                this.gameObject.GetChild("buttonGreen").GetComponent<Renderer>().material.SetColor("_EmissiveColor", Color.green);
                this.gameObject.GetChild("buttonRed").GetComponent<Renderer>().material.SetColor("_EmissiveColor", Color.black);
            }
        }

/// ************************************************

        [KSPEvent(guiActive = true, guiActiveUnfocused = true, unfocusedRange = 20.0f, guiActiveEditor = false, guiName = "#RAGS-Booting")]



        //[KSPEvent(guiActive = true, guiActiveUnfocused = true, unfocusedRange = 20.0f, guiActiveEditor = false, guiName = "Current: Space. Next: Moho.")]

        public void NextGravitySetupEvent()
        {
            selectedCelestial++;

            if (selectedCelestial > 14)
                selectedCelestial = 0;

            Events["NextGravitySetupEvent"].guiName = Localizer.Format("#RAGS-NextGravSetup", Celestials[selectedCelestial], (selectedCelestial != 14 ? Celestials[selectedCelestial + 1] : Celestials[0]));
            Events["PrevGravitySetupEvent"].guiName = Localizer.Format("#RAGS-PrevGravSetup", Celestials[selectedCelestial], (selectedCelestial != 0 ? Celestials[selectedCelestial - 1] : Celestials[14]));

            // #RAGS-NextGravSetup = Current <b><<1>></b>. Next: <b><<2>></b>.
            //Events["NextGravitySetupEvent"].guiName = "Current: " + Celestials[selectedCelestial] + ". Next: " + (selectedCelestial != 14 ? Celestials[selectedCelestial + 1] : Celestials[0]) + ".";
            //Events["PrevGravitySetupEvent"].guiName = "Current: " + Celestials[selectedCelestial] + ". Prev: " + (selectedCelestial != 0 ? Celestials[selectedCelestial - 1] : Celestials[14]) + ".";

            gravity = Gravities[selectedCelestial];
        }

/// ************************************************
        [KSPEvent(guiActive = true, guiActiveUnfocused = true, unfocusedRange = 20.0f, guiActiveEditor = false, guiName = "Current: Space. Prev: Eeloo.")]
        public void PrevGravitySetupEvent()
        {
            selectedCelestial--;

            if (selectedCelestial < 0)
                selectedCelestial = 14;

            Events["NextGravitySetupEvent"].guiName = Localizer.Format("#RAGS-NextGravSetup", Celestials[selectedCelestial], (selectedCelestial != 14 ? Celestials[selectedCelestial + 1] : Celestials[0]));
            Events["PrevGravitySetupEvent"].guiName = Localizer.Format("#RAGS-PrevGravSetup", Celestials[selectedCelestial], (selectedCelestial != 0 ? Celestials[selectedCelestial - 1] : Celestials[14]));

            // #RAGS-NextGravSetup = Current <b><<1>></b>. Next: <b><<2>></b>.
            //Events["NextGravitySetupEvent"].guiName = "Current: " + Celestials[selectedCelestial] + ". Next: " + (selectedCelestial != 14 ? Celestials[selectedCelestial + 1] : Celestials[0]) + ".";
            //Events["PrevGravitySetupEvent"].guiName = "Current: " + Celestials[selectedCelestial] + ". Prev: " + (selectedCelestial != 0 ? Celestials[selectedCelestial - 1] : Celestials[14]) + ".";

            gravity = Gravities[selectedCelestial];
        }

        [KSPEvent(guiActive = true, guiActiveUnfocused = false, guiActiveEditor = false, guiName = "#RAGS-OnSwitch")] // "Toggle anti-gravity")]
        public void OnSwitch()
        {
            isOn = !isOn;
            isSwitching = true;
        }

        /// <summary>Used to convert a rate float to a string, (/sec /min /hr) </summary>
        /// <param name="Rate"></param>
        /// <returns></returns>
        public string RateString(double Rate)
        {
            // limit decimal places to 10 and add sfx
            string sfx = Localizer.Format("#autoLOC_6001048", Rate); // per second
            if (Rate <= 0.004444444f)
            {
                Rate *= 3600;
                sfx = Localizer.Format("#autoLOC_6001047", Rate); // per hour
            }
            else if (Rate < 0.2666667f)
            {
                Rate *= 60;
                sfx = sfx = Localizer.Format("##RAGS-perMin", Rate); // per minute
            }
            return sfx;
        }

        /// <summary>Module information shown in editors</summary>
        private string info = string.Empty;

        /// <summary>this is what is shown in the editors/// </summary>
        /// <returns>Info</returns>
        public override string GetInfo()
        {
            //? this is what is shown in the editor
            //? As annoying as it is, pre-parsing the config MUST be done here, because this is called during part loading.
            //? The config is only fully parsed after everything is fully loaded (which is why it's in OnStart())

            /* :::This is what it should look like with default settings:::
             * Lunatic Aeronautics
             * Rover Anti Grav System (RAGS) v1.3.0.0
             * 
             * Required: (color)
             *   ElectricCharge: 0.5/sec
             * 
             * Output:
             * Magic!
             * 
             */

            if (info == string.Empty)
            {
                info += Localizer.Format("#LA-Agency-titl") + "\r\n"; // #LA-Agency-titl = Lunatic Aeronautics
                info += Localizer.Format("# RAGS-modnamev", Version.SText) + "\r\n"; // Rover Anti Grav Manipulator v Version Number text
                info += "\n<color=#b4d455FF>" + Localizer.Format("#RAGS-GetInfo"); // Now, with advances in technology, Lunatics brings you the feeling of... flying rovers. Can't change atmospheric influences. Only to be used on rovers!

                // Requires
                info += $"\r\n<color=#FFFF19>{Localizer.Format("#autoLOC_244332")}:</color>\r\n"; // Requires:
                info += String.Format("- {0}: {1:n3}\r\n", Localizer.Format("#autoLOC_501004"), RateString(Consumption));

                // Outputs
                info += $"\r\n<color=#FFFF19>{Localizer.Format("#autoLOC_244333")}:</color>\r\n"; // Outputs:
                info += String.Format("- {0}\r\n", Localizer.Format("#RAGS-output"));
            }
            return info;
        }
    }
}