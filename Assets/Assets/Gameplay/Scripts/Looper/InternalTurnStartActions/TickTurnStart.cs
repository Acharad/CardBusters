using System.Collections;
using Assets.Gameplay.Scripts.Events;
using UnityEngine;
using Zenject;

namespace Assets.Gameplay.Scripts.Looper.InternalTurnStartActions
{
    public class TickTurnStart : TickBase
    {
        [Inject] private SignalBus _signalBus;

        public override IEnumerator Tick()
        {
            _signalBus.Fire<IGameplayEvents.OnTurnStart>();
            Debug.Log("Game Play Event | On Turn Start");
            
            yield break;
        }
    }
}
