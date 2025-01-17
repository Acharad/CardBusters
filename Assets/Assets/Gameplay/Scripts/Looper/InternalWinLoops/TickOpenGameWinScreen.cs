using System.Collections;
using UnityEngine;
using Zenject;

namespace Assets.Gameplay.Scripts.Looper.InternalWinLoops
{
    public class TickOpenGameWinScreen : TickBase
    {
        [SerializeField] private GameObject gameWinScreen;
        [Inject] private IInstantiator _instantiator;
        public override IEnumerator Tick()
        {
            _instantiator.InstantiatePrefab(gameWinScreen);
            yield break;
        }
    }
}
