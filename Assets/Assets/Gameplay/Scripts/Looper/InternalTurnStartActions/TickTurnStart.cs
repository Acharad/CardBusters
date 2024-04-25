using System.Collections;
using Assets.Gameplay.Scripts.Events;
using Zenject;

namespace Assets.Gameplay.Scripts.Looper.InternalTurnStartActions
{
    public class TickTurnStart : TickBase
    {
        [Inject] private SignalBus _signalBus;

        public override IEnumerator Tick()
        {
            _signalBus.Fire<IGameplayEvents.OnTurnStart>();
            
            yield break;
        }
    }
}
