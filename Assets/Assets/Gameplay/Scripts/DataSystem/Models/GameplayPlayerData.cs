using System.Collections.Generic;
using Assets.Gameplay.Scripts.Card;
using Assets.Gameplay.Scripts.DataSystem.Interface;
using Assets.Gameplay.Scripts.Events;
using UnityEngine;
using Zenject;

namespace Assets.Gameplay.Scripts.DataSystem.Models
{
    public class GameplayPlayerData
    {
        public Stack<CardType> PlayerCardsInDeck = new();
        public List<CardView> PlayerCardsInHand = new();
        private int _manaCount;
        private int _maxManaCount;

        [Inject] private SignalBus _signalBus;
        
        public void Init(List<CardType> playerCardsInDeck, int manaCount, int maxManaCount)
        {
            foreach (var cardType in playerCardsInDeck)
            {
                PlayerCardsInDeck.Push(cardType);
            }
            
            _manaCount = manaCount;
            _maxManaCount = maxManaCount;
            _signalBus.Fire(new IGameplayEvents.OnPlayerManaChanged()
            {
                Value = _manaCount
            });
        }

        public void IncreaseMaxMana()
        {
            _maxManaCount += 1;
            _manaCount = _maxManaCount;
            SetMana(_maxManaCount);
        }

        public void AddMana(int value)
        {
            if (_manaCount + value <= _maxManaCount)
                _manaCount += value;
            
            _signalBus.Fire(new IGameplayEvents.OnPlayerManaChanged()
            {
                Value = _manaCount
            });
        }

        public void SetMana(int value)
        {
            if (value <= _maxManaCount)
                _manaCount = value;
            
            _signalBus.Fire(new IGameplayEvents.OnPlayerManaChanged()
            {
                Value = _manaCount
            });
        }
    }
}
