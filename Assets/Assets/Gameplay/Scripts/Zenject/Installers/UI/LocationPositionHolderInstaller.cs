using Assets.Gameplay.Scripts.Location;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Assets.Gameplay.Scripts.Zenject.Installers.UI
{
    public class LocationPositionHolderInstaller : MonoInstaller
    {
        [SerializeField] private LocationPositionHolder locationPositionHolder;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<LocationPositionHolder>().FromInstance(locationPositionHolder).AsSingle();
            Container.QueueForInject(locationPositionHolder);
        }
    }
}
