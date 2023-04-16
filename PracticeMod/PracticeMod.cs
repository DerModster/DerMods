using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using BepInEx.Logging;

namespace PracticeMod
{
    public static class PracticeMod
    {
        [HarmonyPatch(typeof(PlayerTool))]
        public static class PlayerToolPatch
        {
            [HarmonyPatch(nameof(PlayerTool.Awake))]
            [HarmonyPostfix]
            public static void AwakePrefix(PlayerTool __instance)
            {
                if (__instance.GetType() == typeof(Knife))
                {
                    float damageMultiplier = PracticeModPlugin.ConfigKnifeDamageMultiplier.Value;

                    Knife knife = __instance as Knife;

                    float knifeDamage = knife.damage;
                    float newKnifeDamage = knifeDamage * 2.0f;

                    knife.damage = newKnifeDamage;

                    PracticeModPlugin.logger.Log(LogLevel.Info, $"Knife damage was: {knifeDamage}," + $" is now: {newKnifeDamage}");
                }
            }
        }
    }
}