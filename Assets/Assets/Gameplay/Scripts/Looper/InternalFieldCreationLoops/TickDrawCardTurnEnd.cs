using System.Collections;
using Assets.Gameplay.Scripts.Card;
using Assets.Gameplay.Scripts.DataSystem;
using Assets.Gameplay.Scripts.DataSystem.Models;
using UnityEngine;
using Zenject;

namespace Assets.Gameplay.Scripts.Looper.InternalFieldCreationLoops
{
    public class TickDrawCardTurnEnd : TickBase
    {
        public int drawCardCount = 1;
        
        [Inject] private CardDrawer _cardDrawer;
        
        public override IEnumerator Tick()
        {
            _cardDrawer.DrawCard(drawCardCount, DrawCardType.TurnEnd);
            
            yield break;
        }
    }
}
