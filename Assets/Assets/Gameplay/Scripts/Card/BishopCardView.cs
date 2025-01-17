using Assets.Gameplay.Scripts.Location;
using UnityEngine;

namespace Assets.Gameplay.Scripts.Card
{
    public class BishopCardView : CardView
    {
        public override void OnRevealFunc(LocationView locationView, bool isFromPlayer = true)
        {
            base.OnRevealFunc(locationView, isFromPlayer);

            locationView.OnCardAddedAfterTurnEnd += OnReveal;
        }


        private void OnReveal()
        {
            GetData().Power += 1;
            ShowCardText();
        }
    }
}
