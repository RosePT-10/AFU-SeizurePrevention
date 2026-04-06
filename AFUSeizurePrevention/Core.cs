using MelonLoader;
using System.Reflection;
using HarmonyLib;
using UnityEngine;
using Il2CppView_Equipment;
using Il2CppTMPro;

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
        public override void OnInitializeMelon()
        {
            LoggerInstance.Msg("Initialized.");
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            //Type my_light_override = typeof(EMPgrenade_View);
            //FieldInfo myLight_field = my_light_override.GetField("myLight");
            //LoggerInstance.Msg(myLight_field.GetValue(new EMPgrenade_View()));

        }
    }
}