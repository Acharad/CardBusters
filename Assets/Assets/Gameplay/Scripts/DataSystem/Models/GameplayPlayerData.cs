using System.Collections.Generic;
using Assets.Gameplay.Scripts.Card;
using Assets.Gameplay.Scripts.DataSystem.Interface;
using Assets.Gameplay.Scripts.Events;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace Assets.Gameplay.Scripts.DataSystem.Models
{
    public class GameplayPlayerData
    {
        //player
        public Stack<CardType> PlayerCardsInDeck = new();
        public List<CardView> PlayerCardsInHand = new();
        private int _manaCount;
        private int _maxManaCount;

        
        public Stack<CardType> EnemyCardsInDeck = new();
        public List<CardView> EnemyCardsInHand = new();
        private int _manaCountEnemy;
        private int _maxManaCountEnemy;
        
        [Inject] private SignalBus _signalBus;
        
        public void Init(List<CardType> playerCardsInDeck, int manaCount, int maxManaCount, List<CardType> enemyCardsInDeck)
        {
            foreach (var cardType in playerCardsInDeck)
            {
                PlayerCardsInDeck.Push(cardType);
            }

            foreach (var cardType in enemyCardsInDeck)
            {
                EnemyCardsInDeck.Push(cardType);
            }
            
            _manaCount = manaCount;
            _maxManaCount = maxManaCount;

            _manaCountEnemy = manaCount;
            _maxManaCountEnemy = maxManaCount;
            
            
            _signalBus.Fire(new IGameplayEvents.OnPlayerManaChanged()
            {
                Value = _manaCount
            });
            
            _signalBus.Fire(new IGameplayEvents.OnEnemyManaChanged()
            {
                Value = _manaCountEnemy
            });
        }

        public void IncreasePlayerMaxMana()
        {
            _maxManaCount += 1;
            _manaCount = _maxManaCount;
            SetPlayerMana(_maxManaCount);
        }
        
        public void IncreaseEnemyMaxMana()
        {
            _maxManaCountEnemy += 1;
            _manaCountEnemy = _maxManaCountEnemy;
            SetEnemyMana(_maxManaCountEnemy);
        }
        
        public void DecreasePlayerMana(int value)
        {
            _manaCount -= value;
            _signalBus.Fire(new IGameplayEvents.OnPlayerManaChanged()
            {
                Value = _manaCount
            });
        }
        
        public void DecreaseEnemyMana(int value)
        {
            _manaCountEnemy -= value;
            _signalBus.Fire(new IGameplayEvents.OnEnemyManaChanged()
            {
                Value = _manaCountEnemy
            });
        }

        public void IncreasePlayerMana(int value)
        {
            _manaCount += value;
            _signalBus.Fire(new IGameplayEvents.OnPlayerManaChanged()
            {
                Value = _manaCount
            });
        }
        
        public void IncreaseEnemyMana(int value)
        {
            _manaCountEnemy += value;
            _signalBus.Fire(new IGameplayEvents.OnEnemyManaChanged()
            {
                Value = _manaCountEnemy
            });
        }

        public void AddPlayerMana(int value)
        {
            if (_manaCount + value <= _maxManaCount)
                _manaCount += value;
            
            _signalBus.Fire(new IGameplayEvents.OnPlayerManaChanged()
            {
                Value = _manaCount
            });
        }
        
        public void AddEnemyMana(int value)
        {
            if (_manaCountEnemy + value <= _maxManaCountEnemy)
                _manaCountEnemy += value;
            
            _signalBus.Fire(new IGameplayEvents.OnEnemyManaChanged()
            {
                Value = _manaCountEnemy
            });
        }

        public void SetPlayerMana(int value)
        {
            if (value <= _maxManaCount)
                _manaCount = value;
            
            _signalBus.Fire(new IGameplayEvents.OnPlayerManaChanged()
            {
                Value = _manaCount
            });
        }
        
        public void SetEnemyMana(int value)
        {
            if (value <= _maxManaCountEnemy)
                _manaCountEnemy = value;
            
            _signalBus.Fire(new IGameplayEvents.OnEnemyManaChanged()
            {
                Value = _manaCountEnemy
            });
        }

        

        public int GetPlayerMana()
        {
            return _manaCount;
        }

        public int GetEnemyMana()
        {
            return _manaCountEnemy;
        }
    }
}
