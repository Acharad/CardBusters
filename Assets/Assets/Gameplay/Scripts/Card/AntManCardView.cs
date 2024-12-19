using Assets.Gameplay.Scripts.Location;
using UnityEngine;

namespace Assets.Gameplay.Scripts.Card
{
    public class AntManCardView : CardView
    {
        public override void OnRevealFunc(LocationView locationView)
        {
            base.OnRevealFunc(locationView);

            locationView.OnCardAddedAfterTurnEnd += IncarseItemPower;
        }


        private void IncarseItemPower()
        {
            if (_locationView.playerCardHolder.GetCurrentCardCount() == 4)
            {
                _cardModel.Power += 4;
                Prepare();
                _locationView.OnCardAddedAfterTurnEnd -= IncarseItemPower;
            }
            
        }
    }
}
