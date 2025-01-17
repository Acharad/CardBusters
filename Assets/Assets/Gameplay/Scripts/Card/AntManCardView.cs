using Assets.Gameplay.Scripts.Location;
using UnityEngine;

namespace Assets.Gameplay.Scripts.Card
{
    public class AntManCardView : CardView
    {
        public override void OnRevealFunc(LocationView locationView, bool isFromPlayer = true)
        {
            base.OnRevealFunc(locationView, isFromPlayer);

            locationView.OnCardAddedAfterTurnEnd += IncreaseItemPower;
        }


        private void IncreaseItemPower()
        {
            if (_locationView.playerCardHolder.GetCurrentCardCount() == 4)
            {
                _cardModel.Power += 4;
                Prepare();
                _locationView.OnCardAddedAfterTurnEnd -= IncreaseItemPower;
            }
            
            if (_locationView.enemyCardHolder.GetCurrentCardCount() == 4)
            {
                _cardModel.Power += 4;
                Prepare();
                _locationView.OnCardAddedAfterTurnEnd -= IncreaseItemPower;
            }
            
        }
    }
}
