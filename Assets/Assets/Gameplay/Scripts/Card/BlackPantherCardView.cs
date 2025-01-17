using Assets.Gameplay.Scripts.Location;
using UnityEngine;

namespace Assets.Gameplay.Scripts.Card
{
    public class BlackPantherCardView : CardView
    {
        public override void OnRevealFunc(LocationView locationView, bool isFromPlayer = true)
        {
            base.OnRevealFunc(locationView, isFromPlayer);

            OnReveal();
        }


        private void OnReveal()
        {
            GetData().Power *= 2;
            ShowCardText();
        }
    }
}
