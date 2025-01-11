using System.Collections;
using Assets.Gameplay.Scripts.DataSystem.Models;
using Zenject;

namespace Assets.Gameplay.Scripts.Looper.InternalTurnEndActions
{
    public class TickIncreasePlayerMaxMana : TickBase
    {
        [Inject] private GameplayPlayerData _gameplayPlayerData;
        
        public override IEnumerator Tick()
        {
            _gameplayPlayerData.IncreasePlayerMaxMana();
            _gameplayPlayerData.IncreaseEnemyMaxMana();
            yield break;
        }
    }
}
