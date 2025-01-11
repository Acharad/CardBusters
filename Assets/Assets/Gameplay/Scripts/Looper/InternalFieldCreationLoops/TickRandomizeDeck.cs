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
            //todo randomize deck
            Debug.Log("ahmet randomize");
            Debug.Log("--------");
            Debug.Log(_cardBusterPlayerData.GameDeckData.PlayerDeck);
            Debug.Log(_cardBusterPlayerData.GameDeckData.EnemyDeck);
            
            _cardBusterPlayerData.GameDeckData.PlayerDeck = _cardBusterPlayerData.GameDeckData.PlayerDeck.OrderBy(_ => Guid.NewGuid()).ToList();
            _cardBusterPlayerData.GameDeckData.EnemyDeck = _cardBusterPlayerData.GameDeckData.EnemyDeck.OrderBy(_ => Guid.NewGuid()).ToList();
            
            Debug.Log(_cardBusterPlayerData.GameDeckData.PlayerDeck);
            Debug.Log(_cardBusterPlayerData.GameDeckData.EnemyDeck);
            Debug.Log("--------");
            yield break;
        }
    }
}
