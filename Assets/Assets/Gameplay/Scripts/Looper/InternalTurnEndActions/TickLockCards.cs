using System.Collections;
using Assets.Gameplay.Scripts.DataSystem.Turn;
using UnityEngine;
using Zenject;

namespace Assets.Gameplay.Scripts.Looper.InternalTurnEndActions
{
    public class TickLockCards : TickBase
    {
        [Inject] private CurrentTurnData _turnData;
        public override IEnumerator Tick()
        {
            foreach (var cardView in _turnData.PlayedCardsLinkedList)
            {
                cardView.GetData().SetIsCardLocked(true);
            }

            foreach (var cardView in _turnData.PlayedCardsEnemyLinkedList)
            {
                cardView.GetData().SetIsCardLocked(true);
            }

            yield break;
        }
    }
}
