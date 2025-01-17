using System.Collections;
using System.Collections.Generic;
using Assets.Gameplay.Scripts.Card;
using Assets.Gameplay.Scripts.DataSystem.Models;
using Assets.Gameplay.Scripts.DataSystem.Turn;
using Assets.Gameplay.Scripts.Events;
using Zenject;
using UnityEngine;


namespace Assets.Gameplay.Scripts.Looper.InternalTurnEndActions
{
    public class TickEnemyPlayCard : TickBase
    {
        private GameData _gameData;
        private GameplayPlayerData _gameplayPlayerData; 
        private SignalBus _signalBus;
        [Inject]
        public void Construct(GameData gameData, SignalBus signalBus, GameplayPlayerData gameplayPlayerData)
        {
            _gameData = gameData;
            _signalBus = signalBus;
            _gameplayPlayerData = gameplayPlayerData;
            
        }
        public override IEnumerator Tick()
        {
            var playableCards = new List<CardView>();
            var locations = _gameData.GameLocationDataList;

            var currentMana = _gameplayPlayerData.GetEnemyMana();
            var canPlay = true;

            while (currentMana > 0 && canPlay)
            {
                playableCards.Clear();
                foreach (var card in _gameplayPlayerData.EnemyCardsInHand)
                {
                    if(card.GetData().ManaCost <= currentMana)
                        playableCards.Add(card);
                }
                
               
                if (playableCards.Count > 0)
                {
                    var randomLocation = locations[Random.Range(0, locations.Count)];
                    var randomCard  = playableCards[Random.Range(0, playableCards.Count)];
                
                    var isLocated = randomLocation.LocationView.TryLocateCard(randomCard, false);
                    if(!isLocated)
                        continue;
                    
                    
                    _signalBus.Fire(new IGameplayEvents.OnCardAddedToLocation()
                    {
                        CardView = randomCard,
                        LocationView = randomLocation.LocationView,
                        IsFromPlayer = false,
                    });
                    
                    _gameplayPlayerData.DecreaseEnemyMana(randomCard.GetData().ManaCost);
                    playableCards.Remove(randomCard);
                    _gameplayPlayerData.EnemyCardsInHand.Remove(randomCard);
                    currentMana = _gameplayPlayerData.GetEnemyMana();
                    Debug.Log("ahmet card located" + randomCard);
                }
                else
                {
                    canPlay = false;
                }
                    
            }
            
            
            
            yield break;
        }
    }
}
