using Assets.Gameplay.Scripts.Location;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Assets.Gameplay.Scripts.Zenject.Installers.Gameplay
{
    public class LocationFactoryInstaller : MonoInstaller
    {
        [SerializeField] private LocationFactory locationFactory;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<LocationFactory>().FromInstance(locationFactory).AsSingle();
            Container.QueueForInject(locationFactory);
        }
    }
}
