using System.Collections;
using Assets.Gameplay.Scripts.Events;
using UnityEngine;
using Zenject;

namespace Assets.Gameplay.Scripts.Looper.InternalLoseLoops
{
    internal class TickGameLose : TickBase
    {
        [Inject] private SignalBus _signalBus;
        
       
        public override IEnumerator Tick()
        {
            _signalBus.Fire<IGameplayEvents.OnGameLose>();
            Debug.Log("Game events | Game Lose!");
            yield break;
        }
    }
}
