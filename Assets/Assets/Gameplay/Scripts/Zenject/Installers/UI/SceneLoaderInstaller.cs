using System;
using Assets.Gameplay.Scripts.SceneSystem;
using Zenject;

public class SceneLoaderInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<SceneLoader>().AsSingle().WithArguments(TimeSpan.FromSeconds(5));
    }
}
