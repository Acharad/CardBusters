using Assets.Gameplay.Scripts.GamePlay;
using Assets.Gameplay.Scripts.Looper;
using Assets.Gameplay.Scripts.State;
using UnityEngine;
using Zenject;

namespace Assets.Gameplay.Scripts.Zenject.Installers.Gameplay
{
    public class GameSystemsInstaller : MonoInstaller
    {
        [SerializeField] private GameStateController gameStateController;
        [SerializeField] private GameLooper gameLooper;
        [SerializeField] private LevelInitializer levelInitializer;
        //input and data can add here

        public override void InstallBindings()
        {
            Container.BindInstance(gameStateController).AsSingle().NonLazy();
            Container.BindInstance(gameLooper).AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<LevelInitializer>().FromInstance(levelInitializer).AsSingle().NonLazy();
        }
    }
}
