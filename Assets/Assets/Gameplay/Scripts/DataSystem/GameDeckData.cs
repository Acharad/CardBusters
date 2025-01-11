using System.Collections.Generic;
using Assets.Gameplay.Scripts.Card;

namespace Assets.Gameplay.Scripts.DataSystem
{
    public class GameDeckData
    {
        public List<CardType> PlayerDeck = new();
        public List<CardType> EnemyDeck = new();
    }
}
