using Assets.Gameplay.Scripts.DataSystem.Models;
using Assets.Gameplay.Scripts.Location;
using Zenject;

namespace Assets.Gameplay.Scripts.Card
{
    public class AgentVenomCardView : CardView
    {
        private bool isOnRevealPlayed = false;
        public override void OnRevealFunc(LocationView locationView, bool isFromPlayer = true)
        {
            base.OnRevealFunc(locationView, isFromPlayer);

            OnReveal();
        }


        private void OnReveal()
        {
            if(isOnRevealPlayed) return;
            isOnRevealPlayed = true;
            
            if (_isFromPlayer)
            {
                foreach (var cardView in _locationView.PlayedCards)
                {
                    cardView.GetData().Power += 3;
                    cardView.ShowCardText();
                    // _locationView.CalculateLocationValues();
                }
            }
            else
            {
                foreach (var cardView in _locationView.EnemyCards)
                {
                    cardView.GetData().Power += 3;
                    cardView.ShowCardText();
                }
            }
        }
    }
}
