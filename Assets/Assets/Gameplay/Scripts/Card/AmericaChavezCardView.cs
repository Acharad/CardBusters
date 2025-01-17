using Assets.Gameplay.Scripts.DataSystem.Models;
using Assets.Gameplay.Scripts.Location;
using UnityEngine;
using Zenject;

namespace Assets.Gameplay.Scripts.Card
{
    public class AmericaChavezCardView : CardView
    {
        [Inject] private GameplayPlayerData _gameplayPlayerData; 
        
        public override void OnRevealFunc(LocationView locationView, bool isFromPlayer = true)
        {
            base.OnRevealFunc(locationView, isFromPlayer);

            OnReveal();
        }


        private void OnReveal()
        {
            if (_isFromPlayer)
            {
                if(_gameplayPlayerData.PlayerCardsInHand.Count <= 0) return;
                var random = Random.Range(0, _gameplayPlayerData.EnemyCardsInHand.Count);
                var card = _gameplayPlayerData.EnemyCardsInHand[random];
                card.GetData().Power += 2;
                card.ShowCardText();
            }
            else
            {
                if(_gameplayPlayerData.EnemyCardsInHand.Count <= 0) return;
                var random = Random.Range(0, _gameplayPlayerData.EnemyCardsInHand.Count);
                var card = _gameplayPlayerData.EnemyCardsInHand[random];
                card.GetData().Power += 2;
                card.ShowCardText();
            }
            
        }
    }
}
