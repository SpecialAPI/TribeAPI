using DiskCardGame;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace TribeAPI
{
    public class NewTribe
    {
        public static List<NewTribe> tribes = new List<NewTribe>();
        public Tribe tribe;
        public Sprite icon;
        public Texture tribeChoiceIcon;
        public bool appearInTribeCardChoices;
        
        public NewTribe(Texture2D icon, bool appearsInTribeCardChoices, Texture2D tribeChoiceIcon = null)
        {
            if(icon != null)
            {
                this.icon = Sprite.Create(icon, new Rect(0f, 0f, icon.width, icon.height), new Vector2(0.5f, 0.5f));
            }
            if (tribeChoiceIcon != null)
            {
                this.tribeChoiceIcon = tribeChoiceIcon;
            }
            tribe = Tribe.NUM_TRIBES + tribes.Count + 1;
            appearInTribeCardChoices = appearsInTribeCardChoices;
            tribes.Add(this);
        }
    }
}
