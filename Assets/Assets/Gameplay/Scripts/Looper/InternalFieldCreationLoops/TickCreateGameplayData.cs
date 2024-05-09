using System.Collections;
using Assets.Gameplay.Scripts.DataSystem;
using Assets.Gameplay.Scripts.DataSystem.Models;
using Zenject;

namespace Assets.Gameplay.Scripts.Looper.InternalFieldCreationLoops
{
    public class TickCreateGameplayData : TickBase
    {
        [Inject] private GameplayPlayerData _gameplayPlayerData;
        [Inject] private CardBusterPlayerData _cardBusterPlayerData;
        public override IEnumerator Tick()
        {
            //_gameplayPlayerData.Init(_cardBusterPlayerData.PlayerDeckData.playerDeck, 3, 3);
            yield break;
        }
    }
}
