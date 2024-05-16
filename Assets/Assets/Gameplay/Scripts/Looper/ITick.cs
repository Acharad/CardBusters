using System.Collections;
using UnityEngine;

namespace Assets.Gameplay.Scripts.Looper
{
    public interface ITick
    {
        bool WillStop { get; }
        bool WillWait { get; }
        IEnumerator Tick();
        void InitTick();
    }
}
