using Zenject;
using UnityEngine;
namespace Assets.Gameplay.Scripts.Zenject.Installers.UI
{
    public class LoadingScreenInstaller : MonoInstaller
    {
        [SerializeField] private GameObject loadingScreenPrefab;
        public override void InstallBindings()
        {
            Container.Bind<LoadingScreenController>()
                .FromMethod(ctx =>
                    ctx.Container.InstantiatePrefab(loadingScreenPrefab).GetComponent<LoadingScreenController>())
                .AsSingle()
                .NonLazy();
        }
    }
}
