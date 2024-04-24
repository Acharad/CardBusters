using Assets.Gameplay.Scripts.Location;
using UnityEngine;
using Zenject;

namespace Assets.Gameplay.Scripts.Zenject.Installers.Gameplay
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Installers/LocationDataSOInstaller", fileName = "LocationDataSOInstaller")]
    public class LocationDataSOInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private LocationDataSO locationDataSo;

        public override void InstallBindings()
        {
            Container.BindInstance(locationDataSo).AsSingle();
        }
    }
}
