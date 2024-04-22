using System;
using UnityEngine;

namespace Assets.Gameplay.Scripts.Card
{
    public interface IOnGoingCard
    {
        void OnGoingFunction();
        event Action OnGoingFunctionAdded;
    }
}
