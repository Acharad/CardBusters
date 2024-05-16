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
            foreach (var locationViews in _gameData.GameLocations)
            {
                locationViews.CheckLocationCanReveal(_gameData.TurnCount);
            }

            yield break;
        }
    }
}
