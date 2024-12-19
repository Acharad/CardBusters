using Assets.Gameplay.Scripts.Card;
using Assets.Gameplay.Scripts.DataSystem.Turn;
using UnityEngine;
using Zenject;

namespace Assets.Gameplay.Scripts.Location.AsgardLocation
{
    public class AsgardLocationView : LocationView
    {
        private bool _isTurnEndActionPlayed;
        [Inject] private GameData _gameData;
        [Inject] private CardDrawer _cardDrawer;

        protected override void TurnEndAction()
        {
            if (!_isLocationRevealed) return;
            if (_isTurnEndActionPlayed) return;
            if (_gameData.TurnCount != 4) return;
            _isTurnEndActionPlayed = true;
            
            
            _cardDrawer.DrawCard(2, DrawCardType.Special);
        }
    }
}
