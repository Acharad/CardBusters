using System.Collections.Generic;
using Assets.Gameplay.Scripts.Card;
using Assets.Gameplay.Scripts.DataSystem.Interface;
using UnityEngine;

namespace Assets.Gameplay.Scripts.DataSystem.Models
{
    public class GameplayPlayerData
    {
        public List<CardType> PlayerCardsInDeck = new();
        public List<CardModel> PlayerCardsInHand = new();
        public int ManaCount;
        public int MaxManaCount;

        public void Init(List<CardType> playerCardsInDeck, int manaCount, int maxManaCount)
        {
            ManaCount = manaCount;
            MaxManaCount = maxManaCount;
            
            foreach (var cardType in playerCardsInDeck)
            {
                PlayerCardsInDeck.Add(cardType);
            }
        }
    }
}
