using System.Collections.Generic;
using Assets.Gameplay.Scripts.Location;
using UnityEngine;

namespace Assets.Gameplay.Scripts.DataSystem.Turn
{
    public class GameData
    {
        public List<LocationView> GameLocations = new();
        public int TurnCount;
    }
}
