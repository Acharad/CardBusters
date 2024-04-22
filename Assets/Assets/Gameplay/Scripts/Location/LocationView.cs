using System;
using UnityEngine;

namespace Assets.Gameplay.Scripts.Location
{
    public class LocationView : MonoBehaviour, IOnRevealLocation
    {
        private LocationModel _locationModel;

        public LocationView(LocationModel locationModel)
        {
            _locationModel = locationModel;
        }

        public void OnRevealFunc()
        {
            
            OnLocationRevealed?.Invoke();
        }

        public event Action OnLocationRevealed;
    }
}
