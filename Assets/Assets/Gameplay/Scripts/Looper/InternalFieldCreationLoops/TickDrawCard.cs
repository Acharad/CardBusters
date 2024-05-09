using System.Collections;
using Assets.Gameplay.Scripts.Card;
using Assets.Gameplay.Scripts.DataSystem;
using UnityEngine;
using Zenject;

namespace Assets.Gameplay.Scripts.Looper.InternalFieldCreationLoops
{
    public class TickDrawCard : TickBase
    {
        [Inject] private CardBusterPlayerData _cardBusterPlayerData;
        [Inject] private CardFactory _cardFactory;
        [Inject] private DeckPositionHolder _deckPositionHolder;
        
        public override IEnumerator Tick()
        {
            Debug.Log(_cardBusterPlayerData.PlayerDeckData.PlayerDeck);
            // _cardFactory.CreateCard()
            
            yield break;
        }
    }
}
