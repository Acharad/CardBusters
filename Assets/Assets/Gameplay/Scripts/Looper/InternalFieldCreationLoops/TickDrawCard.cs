using System.Collections;
using Assets.Gameplay.Scripts.Card;
using Assets.Gameplay.Scripts.DataSystem;
using Assets.Gameplay.Scripts.DataSystem.Models;
using UnityEngine;
using Zenject;

namespace Assets.Gameplay.Scripts.Looper.InternalFieldCreationLoops
{
    public class TickDrawCard : TickBase
    {
        public int drawCardCount = 1;
        
        [Inject] private GameplayPlayerData _gameplayPlayerData;
        [Inject] private CardFactory _cardFactory;
        [Inject] private DeckPositionHolder _deckPositionHolder;
        
        public override IEnumerator Tick()
        {
            Debug.Log(_gameplayPlayerData.PlayerCardsInDeck);
            
            for (var i = 0; i < drawCardCount; i++)
            {
                var cardType = _gameplayPlayerData.PlayerCardsInDeck.Pop();
                var createdCard = _cardFactory.CreateCard(cardType, _deckPositionHolder.deckTransform);
                _gameplayPlayerData.PlayerCardsInHand.Add(createdCard);
            }
            
            
            yield break;
        }
    }
}
