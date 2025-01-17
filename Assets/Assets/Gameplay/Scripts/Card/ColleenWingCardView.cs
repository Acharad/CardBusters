using Assets.Gameplay.Scripts.DataSystem.Models;
using Assets.Gameplay.Scripts.Location;
using UnityEngine;
using Zenject;

namespace Assets.Gameplay.Scripts.Card
{
    public class ColleenWingCardView : CardView
    {
        [Inject] private GameplayPlayerData _gameplayPlayerData;
       
        public override void OnRevealFunc(LocationView locationView, bool isFromPlayer = true)
        {
            base.OnRevealFunc(locationView, isFromPlayer);


            OnReveal();
        }


        private void OnReveal()
        {
            var deck = _isFromPlayer ? _gameplayPlayerData.PlayerCardsInHand : _gameplayPlayerData.EnemyCardsInHand;
            if(deck.Count <= 0)
                return;
            var minCostCard = deck[0];
            
            foreach (var cardView in deck)
            {
                if (cardView.GetData().ManaCost < minCostCard.GetData().ManaCost)
                {
                    minCostCard = cardView;
                }
            }

            deck.Remove(minCostCard);
            minCostCard.RemoveCard();
            
            _locationView.OnCardAddedAfterTurnEnd -= OnReveal;
        }
    }
}
