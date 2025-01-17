
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
                        
                        createdCard = _cardFactory.CreateCard(createdCardType, _deckPositionHolder.deckTransform, _deckPositionHolder.deckTransformForEnemy, true);
                        _gameplayPlayerData.PlayerCardsInHand.Add(createdCard);

                    }
                    else
                    {
                        createdCardType = _gameplayPlayerData.PlayerCardsInDeck.Pop();
                        createdCard = _cardFactory.CreateCard(createdCardType, _deckPositionHolder.deckTransform, _deckPositionHolder.deckTransformForEnemy, true);
                        _gameplayPlayerData.PlayerCardsInHand.Add(createdCard);
                    }
                    
                }
                
                for (var i = 0; i < count; i++)
                {
                    
                    if (_gameplayPlayerData.EnemyCardsInDeck.Contains(CardType.QuickSilver))
                    {
                        createdCardType = CardType.QuickSilver;
                        var tempList = new List<CardType>(_gameplayPlayerData.EnemyCardsInDeck);

                        tempList.Remove(createdCardType);
                        _gameplayPlayerData.EnemyCardsInDeck = new Stack<CardType>(tempList);
                        
                        createdCard = _cardFactory.CreateCard(createdCardType, _deckPositionHolder.deckTransform, _deckPositionHolder.deckTransformForEnemy, false);
                        _gameplayPlayerData.EnemyCardsInHand.Add(createdCard);

                    }
                    else
                    {
                        createdCardType = _gameplayPlayerData.EnemyCardsInDeck.Pop();
                        createdCard = _cardFactory.CreateCard(createdCardType, _deckPositionHolder.deckTransform, _deckPositionHolder.deckTransformForEnemy, false);
                        _gameplayPlayerData.EnemyCardsInHand.Add(createdCard);
                    }
                    
                }
            }
            else if (drawCardType == DrawCardType.TurnEnd || drawCardType == DrawCardType.Special)
            {
                createdCardType = _gameplayPlayerData.PlayerCardsInDeck.Pop();
                createdCard = _cardFactory.CreateCard(createdCardType, _deckPositionHolder.deckTransform, _deckPositionHolder.deckTransformForEnemy, true);
                _gameplayPlayerData.PlayerCardsInHand.Add(createdCard);

                createdCardType = _gameplayPlayerData.EnemyCardsInDeck.Pop();
                createdCard = _cardFactory.CreateCard(createdCardType, _deckPositionHolder.deckTransform, _deckPositionHolder.deckTransformForEnemy, false);
                _gameplayPlayerData.EnemyCardsInHand.Add(createdCard);
            }
            
            
            Debug.Log("Player Cards in deck count " + _gameplayPlayerData.PlayerCardsInDeck.Count);
            Debug.Log("Enemy Cards in deck count " + _gameplayPlayerData.EnemyCardsInDeck.Count);
            foreach (var cardType in _gameplayPlayerData.PlayerCardsInDeck)
            {
                Debug.Log("Player Cards In Deck Type : " + cardType);
            }
            
            foreach (var cardType in _gameplayPlayerData.EnemyCardsInDeck)
            {
                Debug.Log("Enemy Cards In Deck Type : " + cardType);
            }
        }
    }


    public enum DrawCardType
    {
        FirstTime,
        TurnEnd,
        Special
    }
}
