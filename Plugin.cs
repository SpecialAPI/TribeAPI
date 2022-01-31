using BepInEx;
using HarmonyLib;
using System;

namespace TribeAPI
{
    [BepInPlugin(GUID, NAME, VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        private const string NAME = "TribeAPI";
        private const string GUID = "spapi.inscryption.tribeapi";
        private const string VERSION = "1.0";

        public void Awake()
        {
            Harmony harm = new Harmony(GUID);
            harm.PatchAll();
        }
    }
}
