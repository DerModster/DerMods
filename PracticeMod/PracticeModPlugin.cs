using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;

namespace PracticeMod
{
    [BepInPlugin(myGUID, pluginName, versionString)]
    public class PracticeModPlugin : BaseUnityPlugin
    {
        private const string myGUID = "com.dermodster.practicemod";
        private const string pluginName = "Practice Mod";
        private const string versionString = "1.0.0";

        public static ConfigEntry<float> ConfigKnifeDamageMultiplier;

        private static readonly Harmony harmony = new Harmony(myGUID);
        public static ManualLogSource logger;

        private void Awake()
        {
            ConfigKnifeDamageMultiplier = Config.Bind("General", "KnifeDamageMultiplier", 1.0f, "Knife Damage Multiplier");

            harmony.PatchAll();
            Logger.LogInfo(pluginName + " " + versionString + " " + "loaded.");
            logger = Logger;
        }
    }
}