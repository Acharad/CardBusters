using System.Collections;
using Assets.Gameplay.Scripts.Card;
using Zenject;

namespace Assets.Gameplay.Scripts.Looper.InternalFieldCreationLoops
{
    public class TickDrawCardFTA : TickBase
    {
        [Inject] private CardDrawer _cardDrawer;
        public int firstTimeDrawCardCount = 3;
        
        public override IEnumerator Tick()
        {
            _cardDrawer.DrawCard(firstTimeDrawCardCount, DrawCardType.FirstTime);
            
            yield break;
        }
    }
}
