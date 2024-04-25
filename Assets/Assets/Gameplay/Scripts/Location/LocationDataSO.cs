using System;
using Assets.Gameplay.Scripts.Common;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Assets.Gameplay.Scripts.Location
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Location", fileName = "LocationDataSO")]
    public class LocationDataSO : ScriptableObject
    {
        [Serializable]
        public class GameLocationViewDictionary : UnitySerializedDictionary<LocationType, LocationData> { }
        [SerializeField] public GameLocationViewDictionary gameLocationViewDictionary;
    }


    [Serializable]
    public class LocationData
    {
        public LocationView LocationView;
        public LocationModel LocationModel;
    }
}
