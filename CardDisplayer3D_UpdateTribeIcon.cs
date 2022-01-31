using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DiskCardGame;
using HarmonyLib;
using UnityEngine;

namespace TribeAPI
{
    [HarmonyPatch(typeof(CardDisplayer3D), "UpdateTribeIcon")]
    public class CardDisplayer3D_UpdateTribeIcon
    {
        [HarmonyPostfix]
        public static void Postfix(CardDisplayer3D __instance, CardInfo info)
        {
            foreach(NewTribe tribe in NewTribe.tribes)
            {
                if(tribe.icon != null)
                {
                    if (info.IsOfTribe(tribe.tribe))
                    {
                        bool foundSpriteRenderer = false;
                        foreach (SpriteRenderer spriteRenderer in __instance.tribeIconRenderers)
                        {
                            if (spriteRenderer.sprite == null)
                            {
                                foundSpriteRenderer = true;
                                spriteRenderer.sprite = tribe.icon;
                                break;
                            }
                        }
                        if (!foundSpriteRenderer)
                        {
                            SpriteRenderer last = __instance.tribeIconRenderers.Last();
                            SpriteRenderer spriteRenderer = UnityEngine.Object.Instantiate(last);
                            spriteRenderer.transform.parent = last.transform.parent;
                            spriteRenderer.transform.localPosition = last.transform.localPosition + (__instance.tribeIconRenderers[1].transform.localPosition - __instance.tribeIconRenderers[0].transform.localPosition);
                        }
                    }
                }
            }
        }
    }
}
