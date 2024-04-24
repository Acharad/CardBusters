using System;
using UnityEngine;
using Random = UnityEngine.Random;
using Zenject;

namespace Assets.Gameplay.Scripts.Location
{
    public class LocationFactory : MonoBehaviour
    {
        [SerializeField] private LocationView locationViewBasePrefab;
        private LocationDataSO _locationDataSo;
        
        [Inject]
        public void Construct(LocationDataSO locationDataSo)
        {
            _locationDataSo = locationDataSo;
        }

        public LocationModel CreateLocation(LocationType locationType, Transform parent)
        {
            if (locationType ==  LocationType.None)
            {
                return null;
            }

            if (locationType == LocationType.Random)
            {
                locationType = GetRandomLocation();
            }

            var locationView = Instantiate(locationViewBasePrefab, Vector3.zero, Quaternion.identity, parent);
            
            LocationModel locationModel = null; 
            switch (locationType)
            {
                case LocationType.IceBox:
                    locationModel = CreateIceBoxLocation(locationView);
                    break;
            }





            return locationModel;
        }

        private LocationModel CreateIceBoxLocation(LocationView locationView)
        {
            if (!_locationDataSo.gameLocationSpriteDictionary.TryGetValue(LocationType.IceBox, out var locationSprite))
            {
                Debug.LogError("Location sprite is NULL");
                return null;
            }
            IceBoxLocation.IceBoxLocation iceBoxLocation = new(locationView);
            locationView.PrePareLocation(locationSprite);
            return iceBoxLocation;
        }



        // Random int starts from 2 because location 0 none and 1 is random.
        private LocationType GetRandomLocation()
        {
            var values = Enum.GetValues(typeof(LocationType));
            var randomInt = Random.Range(2, values.Length);
            return (LocationType)values.GetValue(randomInt);
        }
    }
}
