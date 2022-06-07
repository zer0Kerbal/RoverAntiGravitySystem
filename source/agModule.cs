//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using UnityEngine;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using KSP.IO;
using KSP;

namespace RoverAntiGravitySystem
{
    public class agModule : PartModule
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
        public static int selectedCelestial = 0;

        [KSPField(isPersistant = true)]
        public static double Consumption = 0.5;

        public string[] Celestials = new string[15];
        public float[] Gravities = new float[15];

        public float gravity = 0;

        public bool isOn = false;
        public bool thereIsAnEngine = false;
        public bool isSwitching = false;

        private Animation myAnimation;

        public override void OnStart(PartModule.StartState state)
        {
            base.OnStart(state);

            Celestials[0] = "Moho";
            Celestials[1] = "Eve";
            Celestials[2] = "Gilly";
            Celestials[3] = "Kerbin";
            Celestials[4] = "Mun";
            Celestials[5] = "Minmus";
            Celestials[6] = "Duna";
            Celestials[7] = "Ike";
            Celestials[8] = "Dres";
            Celestials[9] = "Laythe";
            Celestials[10] = "Vall";
            Celestials[11] = "Tylo";
            Celestials[12] = "Bop";
            Celestials[13] = "Pol";
            Celestials[14] = "Eeloo";

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

            this.part.force_activate();

            gravity = Gravities[selectedCelestial];

            Events["nextGravitySetupEvent"].guiName = "Current: " + Celestials[selectedCelestial] + ". Next: " + (selectedCelestial != 14 ? Celestials[selectedCelestial + 1] : Celestials[0]) + ".";
            Events["prevGravitySetupEvent"].guiName = "Current: " + Celestials[selectedCelestial] + ". Prev: " + (selectedCelestial != 0 ? Celestials[selectedCelestial - 1] : Celestials[14]) + ".";

            myAnimation = this.part.GetComponentInChildren<Animation>();
            this.myAnimation["switch"].wrapMode = WrapMode.Once;

            isOn = false;

            this.gameObject.GetChild("Box002").renderer.material.SetColor("_EmissiveColor", Color.black);
            this.gameObject.GetChild("Box003").renderer.material.SetColor("_EmissiveColor", Color.red);
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

        public override void OnAwake()
        {
            base.OnAwake();
        }

        public override void OnInactive()
        {
            base.OnInactive();
        }

        public override void OnInitialize()
        {
            base.OnInitialize();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (isSwitching && isOn)
            {
                this.myAnimation["switch"].time = 0;
                this.myAnimation["switch"].speed = 5;
                this.myAnimation.Play("switch");

                this.gameObject.GetChild("Box002").renderer.material.SetColor("_EmissiveColor", Color.green);
                this.gameObject.GetChild("Box003").renderer.material.SetColor("_EmissiveColor", Color.black);

                isSwitching = false;
            }
            else if (isSwitching && !isOn)
            {
                this.myAnimation["switch"].time = this.myAnimation["switch"].length;
                this.myAnimation["switch"].speed = -5;
                this.myAnimation.Play("switch");

                this.gameObject.GetChild("Box002").renderer.material.SetColor("_EmissiveColor", Color.black);
                this.gameObject.GetChild("Box003").renderer.material.SetColor("_EmissiveColor", Color.red);

                isSwitching = false;
            }
        }

        public override void OnFixedUpdate()
        {
            base.OnFixedUpdate();

            if (!thereIsAnEngine)
            {
                if (isOn)
                {
                    if (this.part.RequestResource("ElectricCharge", Consumption) >= Consumption)
                    {
                        this.vessel.rigidbody.AddForceAtPosition(-FlightGlobals.getGeeForceAtPosition(this.vessel.findWorldCenterOfMass()) * this.vessel.GetTotalMass(), this.vessel.findWorldCenterOfMass());
                        this.vessel.rigidbody.AddForceAtPosition(-FlightGlobals.getCentrifugalAcc(this.vessel.findWorldCenterOfMass(), this.vessel.mainBody) * this.vessel.GetTotalMass(), this.vessel.findWorldCenterOfMass());

                        this.vessel.rigidbody.AddForceAtPosition(FlightGlobals.getGeeForceAtPosition(this.vessel.findWorldCenterOfMass()).normalized * gravity * this.vessel.GetTotalMass(), this.vessel.findWorldCenterOfMass());
                    }
                    else
                    {
                        isOn = false;
                        isSwitching = true;
                    }
                }
            }
            else
            {
                this.myAnimation["switch"].time = 0;

                this.gameObject.GetChild("Box002").renderer.material.SetColor("_EmissiveColor", Color.black);
                this.gameObject.GetChild("Box003").renderer.material.SetColor("_EmissiveColor", Color.red);
            }
        }

        [KSPEvent(guiActive = true, guiActiveUnfocused = true, unfocusedRange = 20.0f, guiActiveEditor = false, guiName = "Current: Space. Next: Moho.")]
        public void nextGravitySetupEvent()
        {
            selectedCelestial++;

            if (selectedCelestial > 14)
                selectedCelestial = 0;

            Events["nextGravitySetupEvent"].guiName = "Current: " + Celestials[selectedCelestial] + ". Next: " + (selectedCelestial != 14 ? Celestials[selectedCelestial + 1] : Celestials[0]) + ".";
            Events["prevGravitySetupEvent"].guiName = "Current: " + Celestials[selectedCelestial] + ". Prev: " + (selectedCelestial != 0 ? Celestials[selectedCelestial - 1] : Celestials[14]) + ".";

            gravity = Gravities[selectedCelestial];
        }

        [KSPEvent(guiActive = true, guiActiveUnfocused = true, unfocusedRange = 20.0f, guiActiveEditor = false, guiName = "Current: Space. Prev: Eeloo.")]
        public void prevGravitySetupEvent()
        {
            selectedCelestial--;

            if (selectedCelestial < 0)
                selectedCelestial = 14;

            Events["nextGravitySetupEvent"].guiName = "Current: " + Celestials[selectedCelestial] + ". Next: " + (selectedCelestial != 14 ? Celestials[selectedCelestial + 1] : Celestials[0]) + ".";
            Events["prevGravitySetupEvent"].guiName = "Current: " + Celestials[selectedCelestial] + ". Prev: " + (selectedCelestial != 0 ? Celestials[selectedCelestial - 1] : Celestials[14]) + ".";

            gravity = Gravities[selectedCelestial];
        }

        [KSPEvent(guiActive = true, guiActiveUnfocused = false, guiActiveEditor = false, guiName = "Toggle anti-gravity")]
        public void onSwitch()
        {
            isOn = !isOn;
            isSwitching = true;
        }
    }
}
