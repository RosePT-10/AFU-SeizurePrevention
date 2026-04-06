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
        
        [HarmonyPatch(typeof(EMPgrenade_View), "Draw", new Type[] {typeof(float)})]
        public class EMPFix
        {
            public static void Postfix(EMPgrenade_View __instance)
            {
                //Melon<Core>.Logger.Msg("detected");
                __instance.myLight.range = 0;
            }
            
        }

        [HarmonyPatch(typeof(RiotStick_View), "Draw", new Type[] {typeof(float)})]
        public class RiotStickFix
        {
            public static void Postfix(RiotStick_View __instance)
            {
                //Melon<Core>.Logger.Msg("detected");
                __instance.myLight.range = 0;
            }
            
        }

        [HarmonyPatch(typeof(Flashbang_View), "Draw", new Type[] {typeof(float)})]
        public class FlashbangFix
        {
            public static void Postfix(Flashbang_View __instance)
            {
                //Melon<Core>.Logger.Msg("detected");
                //__instance.myLight.range = 0; 
                __instance.Retire();
            }
            
        }

        public override void OnInitializeMelon()
        {
            LoggerInstance.Msg("Initialized. Bye bye flashbangs!");
        }
    }
}