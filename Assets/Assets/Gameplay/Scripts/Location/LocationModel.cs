using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Gameplay.Scripts.Location
{
    public class LocationModel : MonoBehaviour, IOnRevealLocation
    {
        private LocationView _locationView;

        public LocationModel(LocationView locationView)
        {
            _locationView = locationView;
        }

        public void OnRevealFunc()
        {
            
            OnLocationRevealed?.Invoke();
        }

        public event System.Action OnLocationRevealed;
    }
}
