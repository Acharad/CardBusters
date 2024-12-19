using System;
using Assets.Gameplay.Scripts.Location;

namespace Assets.Gameplay.Scripts.Card
{
    public class AngelaCardView : CardView
    {
        
        public override void OnRevealFunc(LocationView locationView)
        {
            base.OnRevealFunc(locationView);

            locationView.OnCardAddedAfterTurnEnd += IncarseItemPower;
        }


        private void IncarseItemPower()
        {
            _cardModel.Power += 1;
            Prepare();
            _locationView.OnCardAddedAfterTurnEnd -= IncarseItemPower;
        }
    }
}
