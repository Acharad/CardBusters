using System.Collections;
using Assets.Gameplay.Scripts.Events;
using UnityEngine;
using Zenject;

namespace Assets.Gameplay.Scripts.Looper.InternalGameEndLoops
{
    public class TickGameEnd : TickBase
    {
        [Inject] private SignalBus _signalBus;
        public override IEnumerator Tick()
        {
            _signalBus.Fire<IGameplayEvents.OnGameEnd>();
            Debug.Log("Game Play Events | On game end.");
            yield break;
        }
    }
}
