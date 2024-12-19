
using System.Collections.Generic;
using Assets.Gameplay.Scripts.DataSystem.Models;
using UnityEngine;
using Zenject;

namespace Assets.Gameplay.Scripts.Card
{
    public class CardDrawer
    {
        [Inject] private GameplayPlayerData _gameplayPlayerData;
        [Inject] private CardFactory _cardFactory;
        [Inject] private DeckPositionHolder _deckPositionHolder;

        public void DrawCard(int count, DrawCardType drawCardType)
        {
            //Todo add enemy
            CardView createdCard;
            CardType createdCardType;
            if (drawCardType == DrawCardType.FirstTime)
            {
                for (var i = 0; i < count; i++)
                {
                    
                    if (_gameplayPlayerData.PlayerCardsInDeck.Contains(CardType.QuickSilver))
                    {
                        createdCardType = CardType.QuickSilver;
                        var tempList = new List<CardType>(_gameplayPlayerData.PlayerCardsInDeck);

                        tempList.Remove(createdCardType);
                        _gameplayPlayerData.PlayerCardsInDeck = new Stack<CardType>(tempList);
                        
                        createdCard = _cardFactory.CreateCard(createdCardType, _deckPositionHolder.deckTransform);
                        _gameplayPlayerData.PlayerCardsInHand.Add(createdCard);

                    }
                    else
                    {
                        createdCardType = _gameplayPlayerData.PlayerCardsInDeck.Pop();
                        createdCard = _cardFactory.CreateCard(createdCardType, _deckPositionHolder.deckTransform);
                        _gameplayPlayerData.PlayerCardsInHand.Add(createdCard);
                    }
                    
                }
            }
            else if (drawCardType == DrawCardType.TurnEnd)
            {
                createdCardType = _gameplayPlayerData.PlayerCardsInDeck.Pop();
                createdCard = _cardFactory.CreateCard(createdCardType, _deckPositionHolder.deckTransform);
                _gameplayPlayerData.PlayerCardsInHand.Add(createdCard);
            }
            
            
            Debug.Log("Player Cards in deck count " + _gameplayPlayerData.PlayerCardsInDeck.Count);
            foreach (var cardType in _gameplayPlayerData.PlayerCardsInDeck)
            {
                Debug.Log("Player Cards In Deck Type : " + cardType);
            }
            Debug.Log("---------");
        }
    }


    public enum DrawCardType
    {
        FirstTime,
        TurnEnd,
        Special
    }
}
