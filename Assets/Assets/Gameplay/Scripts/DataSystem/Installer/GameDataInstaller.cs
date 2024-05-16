using Assets.Gameplay.Scripts.DataSystem.Turn;
using UnityEngine;
using Zenject;

namespace Assets.Gameplay.Scripts.DataSystem.Installer
{
    public class GameDataInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<GameData>().AsSingle();
        }
    }
}
