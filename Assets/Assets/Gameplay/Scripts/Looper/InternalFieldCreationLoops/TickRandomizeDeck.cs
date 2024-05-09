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
            Debug.Log(_cardBusterPlayerData.PlayerDeckData.PlayerDeck);
            _cardBusterPlayerData.PlayerDeckData.PlayerDeck = _cardBusterPlayerData.PlayerDeckData.PlayerDeck.OrderBy(_ => Guid.NewGuid()).ToList();
            yield break;
        }
    }
}
