using Assets.Gameplay.Scripts.Card;
using Zenject;

namespace Assets.Gameplay.Scripts.Zenject.Installers.Gameplay
{
    public class CardDrawerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<CardDrawer>().AsSingle();
        }
    }
}
