using Assets.Gameplay.Scripts.DataSystem.Models;
using UnityEngine;
using Zenject;

namespace Assets.Gameplay.Scripts.Location.IceBoxLocation
{
    public class IceBoxLocationView : LocationView
    {
        [Inject] private GameplayPlayerData _gameplayPlayerData;
        private bool _isTurnEndActionPlayed;

        protected override void TurnEndAction()
        {
            if (!_isLocationRevealed) return;
            if (_isTurnEndActionPlayed) return;
            _isTurnEndActionPlayed = true;
            
            var randomCardPlayer =
                _gameplayPlayerData.PlayerCardsInHand[Random.Range(0, _gameplayPlayerData.PlayerCardsInHand.Count)];
            randomCardPlayer.GetData().ManaCost += 1;
            randomCardPlayer.ShowCardText();


            //todo when enemy card added.
            /*
            var randomCardEnemy =
                _gameplayPlayerData.EnemyCardsInHand[Random.Range(0, _gameplayPlayerData.PlayerCardsInHand.Count)];
            randomCardEnemy.GetData().ManaCost += 1;
            randomCardEnemy.ShowCardText();
            */
        }
    }
}
