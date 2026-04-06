using MelonLoader;
using System.Reflection;
using HarmonyLib;
using UnityEngine;
using Il2CppView_Equipment;

[assembly: MelonInfo(typeof(AFUSeizurePrevention.Core), "AFUSeizurePrevention", "1.0.0", "taldo", null)]
[assembly: MelonGame("Videocult", "Airframe")]

namespace AFUSeizurePrevention
{
    public class Core : MelonMod
    {
        public override void OnInitializeMelon()
        {
            LoggerInstance.Msg("Initialized.");
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            Type my_light_override = typeof(EMPgrenade_View);
            FieldInfo myLight_field = my_light_override.GetField("myLight");
            LoggerInstance.Msg(myLight_field.GetValue(new EMPgrenade_View()));

        }
    }
}