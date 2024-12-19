namespace Assets.Gameplay.Scripts.Location.AtlantisLocation
{
    public class AtlantisLocationView : LocationView
    {
        private bool _isPlayerPowerAdded = false;
        private bool _isEnemyPowerAdded = false;


        protected override void TurnEndAction()
        {
            if(!_isLocationRevealed) return;
            
            if (PlayedCards.Count == 1 && !_isPlayerPowerAdded)
            {
                _locationModel.PlayerPower += 5;
                _isPlayerPowerAdded = true;
            }

            if (PlayedCards.Count > 1 && _isPlayerPowerAdded)
            {
                _locationModel.PlayerPower -= 5;
            }

            if (EnemyCards.Count == 1 && !_isEnemyPowerAdded)
            {
                _locationModel.EnemyPower += 5;
                _isEnemyPowerAdded = true;
            }
            
            if (EnemyCards.Count > 1 && _isEnemyPowerAdded)
            {
                _locationModel.EnemyPower -= 5;
            }
            
            SetLocationValues();
        }
    }
}
