using Assets.Gameplay.Scripts.Location;

namespace Assets.Gameplay.Scripts.Card
{
    public class MedusaCardView : CardView
    {
        public override void OnRevealFunc(LocationView locationView, bool isFromPlayer = true)
        {
            base.OnRevealFunc(locationView, isFromPlayer);

            if (locationView.GetModel().RevealTurnCount == 2)
            {
                IncreaseItemPower();
            }
        }


        private void IncreaseItemPower()
        {
            _cardModel.Power += 3;
            Prepare();
        }
    }
}
