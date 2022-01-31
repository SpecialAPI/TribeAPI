using System;
using System.Collections.Generic;
using System.Text;
using DiskCardGame;
using HarmonyLib;
using UnityEngine;

namespace TribeAPI
{
    [HarmonyPatch(typeof(CardSingleChoicesSequencer), "GetCardbackTexture")]
    public class CardSingleChoicesSequencer_GetCardbackTexture
    {
        [HarmonyPostfix]
        public static void Postfix(ref Texture __result, CardChoice choice)
        {
            if(__result == null && choice.resourceType != ResourceType.Blood && choice.resourceType != ResourceType.Bone)
            {
                __result = NewTribe.tribes.Find((x) => x.tribe == choice.tribe).tribeChoiceIcon;
            }
        }
    }
}
