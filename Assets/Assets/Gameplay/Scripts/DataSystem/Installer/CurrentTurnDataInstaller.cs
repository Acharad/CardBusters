using Assets.Gameplay.Scripts.DataSystem.Turn;
using Zenject;

namespace Assets.Gameplay.Scripts.DataSystem.Installer
{
    public class CurrentTurnDataInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<CurrentTurnData>().AsSingle();
        }
    }
}
