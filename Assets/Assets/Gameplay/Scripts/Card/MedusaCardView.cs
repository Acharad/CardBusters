using Assets.Gameplay.Scripts.Location;

namespace Assets.Gameplay.Scripts.Card
{
    public class MedusaCardView : CardView
    {
        public override void OnRevealFunc(LocationView locationView)
        {
            base.OnRevealFunc(locationView);

            if (locationView.GetModel().RevealTurnCount == 2)
            {
                IncarseItemPower();
            }
        }


        private void IncarseItemPower()
        {
            _cardModel.Power += 3;
            Prepare();
        }
    }
}
