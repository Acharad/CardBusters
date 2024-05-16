using System.Collections;
using Assets.Gameplay.Scripts.DataSystem.Turn;
using Zenject;

namespace Assets.Gameplay.Scripts.Looper.InternalTurnStartActions
{
    public class TickIncreaseTurnCount : TickBase
    {
        [Inject] private GameData _gameData;

        public override IEnumerator Tick()
        {
            _gameData.TurnCount++;
            yield break;
        }
    }
}
