using System.Collections;
using Assets.Gameplay.Scripts.DataSystem.Turn;
using Zenject;

namespace Assets.Gameplay.Scripts.Looper.InternalTurnEndActions
{
    public class TickPlayOnRevealFunctions : TickBase
    {
        [Inject] private GameData _gameData;
        public override IEnumerator Tick()
        {
            foreach (var gameLocationData in _gameData.GameLocationDataList)
            {
                gameLocationData.LocationView.ActivateOnRevealFunc();
            }
            
            yield break;
        }
    }
}
