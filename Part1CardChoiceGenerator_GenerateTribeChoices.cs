using System;
using System.Collections.Generic;
using System.Text;
using DiskCardGame;
using HarmonyLib;

namespace TribeAPI
{
    [HarmonyPatch(typeof(Part1CardChoiceGenerator), "GenerateTribeChoices")]
    public class Part1CardChoiceGenerator_GenerateTribeChoices
    {
        [HarmonyPrefix]
        public static bool Prefix(ref List<CardChoice> __result, int randomSeed)
        {
			List<Tribe> list = new List<Tribe>
			{
				Tribe.Bird,
				Tribe.Canine,
				Tribe.Hooved,
				Tribe.Insect,
				Tribe.Reptile
			};
			list.AddRange(NewTribe.tribes.FindAll((x) => x.appearInTribeCardChoices).ConvertAll((x) => x.tribe));
			List<Tribe> tribes = new List<Tribe>(RunState.CurrentMapRegion.dominantTribes);
			list.RemoveAll((Tribe x) => tribes.Contains(x));
			while (tribes.Count < 3)
			{
				Tribe item = list[SeededRandom.Range(0, list.Count, randomSeed++)];
				tribes.Add(item);
				list.Remove(item);
			}
			while (tribes.Count > 3)
			{
				tribes.RemoveAt(SeededRandom.Range(0, tribes.Count, randomSeed++));
			}
			List<CardChoice> list2 = new List<CardChoice>();
			foreach (Tribe tribe in tribes.Randomize())
			{
				list2.Add(new CardChoice
				{
					tribe = tribe
				});
			}
			__result = list2;
			return false;
        }
    }
}
