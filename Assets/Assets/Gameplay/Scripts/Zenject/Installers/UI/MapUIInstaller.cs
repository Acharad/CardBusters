using Assets.Gameplay.Scripts.UI.ButtonScripts;
using UnityEngine;
using Zenject;

namespace Assets.Gameplay.Scripts.Zenject.Installers.UI
{
    public class MapUIInstaller : MonoInstaller
    {
        [SerializeField] private LevelPlayButton _levelPlayButton;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<LevelPlayButton>().FromInstance(_levelPlayButton).AsSingle();
            Container.QueueForInject(_levelPlayButton);
        }
    }
}
