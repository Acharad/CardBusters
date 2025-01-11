using System.Collections;
using Assets.Gameplay.Scripts.DataSystem.Turn;
using Zenject;

namespace Assets.Gameplay.Scripts.Looper.InternalTurnEndActions
{
    public class TickCheckGameEnd : TickBase
    {
        private GameData _gameData;
        private GameLooper _gameLooper;

        public override bool WillStop => isGameEnd;

        public bool isGameEnd;

        [Inject]
        private void Construct(GameData gameData, GameLooper gameLooper)
        {
            _gameData = gameData;
            _gameLooper = gameLooper;
        }
        public override IEnumerator Tick()
        {
            isGameEnd = _gameData.TurnCount > 6;
            if(isGameEnd)
                _gameLooper.StartGameEndLoop();
            yield break;
        }
    }
}
