using System;
using Assets.Gameplay.Scripts.Location;
using UnityEngine;

namespace Assets.Gameplay.Scripts.Card
{
    public interface IOnRevealCard
    {
        void OnRevealFunc(LocationView locationView, bool isFromPlayer = true);
        event Action OnRevealObjectAdded;
    }
}
