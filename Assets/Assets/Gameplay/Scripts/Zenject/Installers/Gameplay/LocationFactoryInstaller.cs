using Assets.Gameplay.Scripts.Location;
using UnityEngine;
using Zenject;

namespace Assets.Gameplay.Scripts.Zenject.Installers.Gameplay
{
    public class LocationFactoryInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<LocationFactory>().AsSingle().NonLazy();
        }
    }
}
