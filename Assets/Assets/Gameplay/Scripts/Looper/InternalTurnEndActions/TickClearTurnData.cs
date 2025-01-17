using System.Collections;
using Assets.Gameplay.Scripts.DataSystem.Turn;
using Zenject;

namespace Assets.Gameplay.Scripts.Looper.InternalTurnEndActions
{
    public class TickClearTurnData : TickBase
    {
        [Inject] private CurrentTurnData _turnData;
        public override IEnumerator Tick()
        {
            _turnData.PlayedCardsLinkedList?.First?.List.Clear();
            _turnData.PlayedCardsEnemyLinkedList?.First?.List.Clear();
            yield break;
        }
    }
}
