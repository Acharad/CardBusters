using System;
using UnityEngine;

namespace Assets.Gameplay.Scripts.Card
{
    public interface IOnRevealCard
    {
        void OnRevealFunc();
        event Action OnRevealObjectAdded;
    }
}
