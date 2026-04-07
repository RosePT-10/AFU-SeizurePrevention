using MelonLoader;
using System.Reflection;
using HarmonyLib;
using UnityEngine;
using Il2CppView_Equipment;
using Il2CppTMPro;
using Il2CppView_Main;

[assembly: MelonInfo(typeof(AFUSeizurePrevention.Core), "AFUSeizurePrevention", "1.0.0", "taldo", null)]
[assembly: MelonGame("Videocult", "Airframe")]

namespace AFUSeizurePrevention
{
    public class Core : MelonMod
    {
        private MelonPreferences_Category SeizPrevCat;
        private MelonPreferences_Entry<bool> IsEMP;
        private MelonPreferences_Entry<bool> IsRiotStick;
        private MelonPreferences_Entry<bool> IsFlashbang;


        [HarmonyPatch(typeof(EMPgrenade_View), "Draw", new Type[] {typeof(float)})]
        public class EMPFix
        {
            public static void Postfix(EMPgrenade_View __instance)
            {
                //Melon<Core>.Logger.Msg("detected");
                if (Melon<Core>.Instance.IsEMP.Value == true)
                {
                    __instance.myLight.range = 0;
                }
            }
            
        }

        [HarmonyPatch(typeof(RiotStick_View), "Draw", new Type[] {typeof(float)})]
        public class RiotStickFix
        {
            public static void Postfix(RiotStick_View __instance)
            {
                //Melon<Core>.Logger.Msg("detected");
                if (Melon<Core>.Instance.IsRiotStick.Value == true)
                {
                    __instance.myLight.range = 0;
                }
            }
            
        }

        [HarmonyPatch(typeof(Flashbang_View), "Draw", new Type[] {typeof(float)})]
        public class FlashbangFix
        {
            public static void Postfix(Flashbang_View __instance)
            {
                //Melon<Core>.Logger.Msg("detected");
                //__instance.myLight.range = 0; 
                if (Melon<Core>.Instance.IsFlashbang.Value == true)
                {
                    __instance.Retire();
                }
                
            }
            
        }

        public override void OnInitializeMelon()
        {
            SeizPrevCat = MelonPreferences.CreateCategory("AFUSeizurePrevention");
            IsEMP = SeizPrevCat.CreateEntry<bool>("EMPFlashDisabled", true);
            IsRiotStick = SeizPrevCat.CreateEntry<bool>("RiotStickFlashDisabled", true);
            IsFlashbang = SeizPrevCat.CreateEntry<bool>("FlashbangsRemoved", true);
            LoggerInstance.Msg("Initialized. Bye bye flashbangs!");
        }
    }
}