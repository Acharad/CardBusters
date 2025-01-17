using System;
using System.Collections;
using System.Linq;
using Assets.Gameplay.Scripts.DataSystem;
using UnityEngine;
using Zenject;

namespace Assets.Gameplay.Scripts.Looper.InternalFieldCreationLoops
{
    public class TickRandomizeDeck : TickBase
    {
        [Inject] private CardBusterPlayerData _cardBusterPlayerData;
        public override IEnumerator Tick()
        {
            _cardBusterPlayerData.GameDeckData.PlayerDeck = _cardBusterPlayerData.GameDeckData.PlayerDeck.OrderBy(_ => Guid.NewGuid()).ToList();
            _cardBusterPlayerData.GameDeckData.EnemyDeck = _cardBusterPlayerData.GameDeckData.EnemyDeck.OrderBy(_ => Guid.NewGuid()).ToList();
            yield break;
        }
    }
}
