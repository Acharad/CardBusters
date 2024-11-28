using System.Collections.Generic;
using Assets.Gameplay.Scripts.Card;
using Assets.Gameplay.Scripts.Events;
using Assets.Gameplay.Scripts.Location;
using UnityEngine;
using Zenject;

namespace Assets.Gameplay.Scripts.DataSystem.Turn
{
    public class GameData
    {
        public List<GameLocationData> GameLocationDataList = new();
        public int TurnCount;

        private SignalBus _signalBus;
        [Inject]
        public void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
            _signalBus.Subscribe<IGameplayEvents.OnCardAddedToLocation>(SetCardsToData);
        }
        public void AddGameLocationData(GameLocationData gameLocationData)
        {
            GameLocationDataList.Add(gameLocationData);
        }

        private void SetCardsToData(IGameplayEvents.OnCardAddedToLocation data)
        {
            if (data.IsFromPlayer)
            {
            }
        }

        
    }
    
    public class GameLocationData
    {
        public LocationView LocationView;
        public List<CardView> PlayerCards = new();
        public List<CardView> EnemyCards = new();
    }
}
