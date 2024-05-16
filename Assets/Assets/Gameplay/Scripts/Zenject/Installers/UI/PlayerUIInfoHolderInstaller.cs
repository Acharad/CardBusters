using Assets.Gameplay.Scripts.GamePlay;
using UnityEngine;
using Zenject;

namespace Assets.Gameplay.Scripts.Zenject.Installers.UI
{
    public class PlayerUIInfoHolderInstaller : MonoInstaller
    {
        [SerializeField] private PlayerUIInfoHolder playerUIInfoHolder;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PlayerUIInfoHolder>().FromInstance(playerUIInfoHolder).AsSingle();
            Container.QueueForInject(playerUIInfoHolder);
        }
    }
}
