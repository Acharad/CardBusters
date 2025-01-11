using System.Collections;
using Assets.Gameplay.Scripts.DataSystem;
using Assets.Gameplay.Scripts.DataSystem.Models;
using Assets.Gameplay.Scripts.DataSystem.Turn;
using Zenject;

namespace Assets.Gameplay.Scripts.Looper.InternalFieldCreationLoops
{
    public class TickCreateGameplayData : TickBase
    {
        private GameplayPlayerData _gameplayPlayerData;
        private CardBusterPlayerData _cardBusterPlayerData;
        private CardBusterEnemyData _cardBusterEnemyData;
        private GameData _gameData;
        [Inject]
        private void Construct(GameplayPlayerData gameplayPlayerData, CardBusterPlayerData cardBusterPlayerData, GameData gameData, CardBusterEnemyData cardBusterEnemyData)
        {
            _gameplayPlayerData = gameplayPlayerData;
            _cardBusterPlayerData = cardBusterPlayerData;
            _cardBusterEnemyData = cardBusterEnemyData;
            _gameData = gameData;
        }
        
        public override IEnumerator Tick()
        {
            _gameplayPlayerData.Init(_cardBusterPlayerData.GameDeckData.PlayerDeck, 3, 3, _cardBusterEnemyData.GameDeckData.EnemyDeck);
            _gameData.TurnCount = 0;
            yield break;
        }
    }
}
