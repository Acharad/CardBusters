using Assets.Gameplay.Scripts.Location;
using UnityEngine;
using Zenject;

namespace Assets.Gameplay.Scripts.Card
{
    public class CrystalCardView : CardView
    {
        [Inject] private CardDrawer _cardDrawer;
        public override void OnRevealFunc(LocationView locationView, bool isFromPlayer = true)
        {
            base.OnRevealFunc(locationView, isFromPlayer);

            OnReveal();
        }


        private void OnReveal()
        {
            _cardDrawer.DrawCard(1, DrawCardType.Special);
        }
    }
}
