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

        public LocationView CreateLocation(LocationType locationType, Transform parent, int locationRevealInt)
        {
            if (locationType ==  LocationType.None)
            {
                return null;
            }

            if (locationType == LocationType.Random)
            {
                locationType = GetRandomLocation();
            }

            LocationView locationView = null;
            switch (locationType)
            {
                case LocationType.IceBox:
                    locationView = CreateIceBoxLocation(parent, locationRevealInt);
                    break;
                case LocationType.Asgard:
                    locationView = CreateAsgardLocation(parent ,locationRevealInt);
                    break;
                case LocationType.Atlantis:
                    locationView = CreateAtlantisLocation(parent ,locationRevealInt);
                    break;
                case LocationType.Ruins:
                    locationView = CreateRuinsLocation(parent, locationRevealInt);
                    break;
                default:
                    Debug.LogError($"Location cant find  with this : {locationType}");
                    break;
            }
            if (locationView != null)
                locationView.GetComponent<RectTransform>().localPosition = Vector3.one;
            
            return locationView;
        }

        private LocationView CreateIceBoxLocation(Transform parent, int revealCount)
        {
            if (!_locationDataSo.gameLocationViewDictionary.TryGetValue(LocationType.IceBox, out var locationData))
            {
                Debug.LogError("Location sprite is NULL");
                return null;
            }
            var iceBoxView = Instantiate(locationData.LocationView, Vector3.zero, Quaternion.identity, parent);
            iceBoxView.Init(locationData.LocationModel, revealCount);
            
            return iceBoxView;
        }
        
        private LocationView CreateAsgardLocation(Transform parent, int revealCount)
        {
            if (!_locationDataSo.gameLocationViewDictionary.TryGetValue(LocationType.Asgard, out var locationData))
            {
                Debug.LogError("Location sprite is NULL");
                return null;
            }
            var asgardView = Instantiate(locationData.LocationView, Vector3.zero, Quaternion.identity, parent);
            asgardView.Init(locationData.LocationModel, revealCount);
            
            return asgardView;
        }
        
        private LocationView CreateAtlantisLocation(Transform parent, int revealCount)
        {
            if (!_locationDataSo.gameLocationViewDictionary.TryGetValue(LocationType.Atlantis, out var locationData))
            {
                Debug.LogError("Location sprite is NULL");
                return null;
            }
            var atlantisLocation = Instantiate(locationData.LocationView, Vector3.zero, Quaternion.identity, parent);
            atlantisLocation.Init(locationData.LocationModel, revealCount);
            
            return atlantisLocation;
        }
        
        private LocationView CreateRuinsLocation(Transform parent, int revealCount)
        {
            if (!_locationDataSo.gameLocationViewDictionary.TryGetValue(LocationType.Ruins, out var locationData))
            {
                Debug.LogError("Location sprite is NULL");
                return null;
            }
            var locationView = Instantiate(locationData.LocationView, Vector3.zero, Quaternion.identity, parent);
            locationView.Init(locationData.LocationModel, revealCount);
            
            return locationView;
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
