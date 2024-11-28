using System.Collections;
using Assets.Gameplay.Scripts.DataSystem.Turn;
using UnityEngine;
using Zenject;

namespace Assets.Gameplay.Scripts.Looper.InternalTurnStartActions
{
    public class TickRevealLocations : TickBase
    { 
        [Inject] private GameData _gameData;
        
        public override IEnumerator Tick()
        {
            foreach (var gameLocationData in _gameData.GameLocationDataList)
            {
                gameLocationData.LocationView.CheckLocationCanReveal(_gameData.TurnCount);
            }

            yield break;
        }
    }
}
