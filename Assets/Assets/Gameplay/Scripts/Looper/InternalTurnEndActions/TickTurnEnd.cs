using System.Collections;
using Assets.Gameplay.Scripts.Events;
using UnityEngine;
using Zenject;

namespace Assets.Gameplay.Scripts.Looper.InternalTurnEndActions
{
    public class TickTurnEnd : TickBase
    {
        [Inject] private SignalBus _signalBus;


        public override IEnumerator Tick()
        {
            _signalBus.Fire<IGameplayEvents.OnTurnEnd>();
            yield break;
        }
    }
}
