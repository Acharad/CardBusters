using System.Collections.Generic;
using Assets.Gameplay.Scripts.Card;
using UnityEngine;

namespace Assets.Gameplay.Scripts.DataSystem.Turn
{
    public class CurrentTurnData 
    {
        public List<CardView> PlayedCardsList = new();
    }
}
