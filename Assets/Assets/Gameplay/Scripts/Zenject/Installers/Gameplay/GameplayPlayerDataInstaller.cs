using Assets.Gameplay.Scripts.DataSystem.Models;
using Zenject;

namespace Assets.Gameplay.Scripts.Zenject.Installers.Gameplay
{
    public class GameplayPlayerDataInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<GameplayPlayerData>().AsSingle();
        }
    }
}
