using System;
using Assets.Gameplay.Scripts.Location;

namespace Assets.Gameplay.Scripts.Card
{
    public class AngelaCardView : CardView
    {
        
        public override void OnRevealFunc(LocationView locationView, bool isFromPlayer = true)
        {
            base.OnRevealFunc(locationView, isFromPlayer);

            locationView.OnCardAddedAfterTurnEnd += IncreaseItemPower;
        }


        private void IncreaseItemPower()
        {
            _cardModel.Power += 1;
            Prepare();
            _locationView.OnCardAddedAfterTurnEnd -= IncreaseItemPower;
        }
    }
}
