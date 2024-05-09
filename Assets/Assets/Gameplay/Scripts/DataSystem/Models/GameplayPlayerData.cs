using System.Collections.Generic;
using Assets.Gameplay.Scripts.Card;
using Assets.Gameplay.Scripts.DataSystem.Interface;
using UnityEngine;

namespace Assets.Gameplay.Scripts.DataSystem.Models
{
    public class GameplayPlayerData
    {
        public Stack<CardType> PlayerCardsInDeck = new();
        public List<CardView> PlayerCardsInHand = new();
        public int ManaCount;
        public int MaxManaCount;

        public void Init(List<CardType> playerCardsInDeck, int manaCount, int maxManaCount)
        {
            ManaCount = manaCount;
            MaxManaCount = maxManaCount;
            
            foreach (var cardType in playerCardsInDeck)
            {
                PlayerCardsInDeck.Push(cardType);
            }
        }
    }
}
