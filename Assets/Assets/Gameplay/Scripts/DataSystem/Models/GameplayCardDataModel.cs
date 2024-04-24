using System.Collections.Generic;
using Assets.Gameplay.Scripts.Card;
using Assets.Gameplay.Scripts.DataSystem.Interface;
using UnityEngine;

namespace Assets.Gameplay.Scripts.DataSystem.Models
{
    public class GameplayCardDataModel :  IDataChanged<GameplayCardDataModel>
    {
        private List<CardModel> _playerCardsInDeck = new();
        private List<CardModel> _playerCardsInHand = new();
        private int _manaCount;
        private int _maxManaCount;

        public List<CardModel> PlayerCardsInDeck
        {
            get => _playerCardsInDeck;
            set
            {
                var data = Copy();
                _playerCardsInDeck = value;
                OnChanged?.Invoke(this, data);
            }
        }
        
        public List<CardModel> PlayerCardsInHand
        {
            get => _playerCardsInHand;
            set
            {
                var data = Copy();
                _playerCardsInHand = value;
                OnChanged?.Invoke(this, data);
            }
        }
        
        public int ManaCount
        {
            get => _manaCount;
            set
            {
                var data = Copy();
                _manaCount = value;
                OnChanged?.Invoke(this, data);
            }
        }
        
        public int MaxManaCount
        {
            get => _maxManaCount;
            set
            {
                var data = Copy();
                _maxManaCount = value;
                OnChanged?.Invoke(this, data);
            }
        }
        
        public event IDataChanged<GameplayCardDataModel>.OnChangeHandler OnChanged;
        public GameplayCardDataModel Copy()
        {
            var data = new GameplayCardDataModel()
            {
                _playerCardsInDeck = PlayerCardsInDeck,
                _playerCardsInHand = _playerCardsInHand,
                _manaCount = ManaCount,
                _maxManaCount = MaxManaCount
            };
            return data;
        }
    }
}
