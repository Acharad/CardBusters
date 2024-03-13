using UnityEngine;
using Zenject;

namespace Assets.Gameplay.Scripts.Zenject.Installers
{
    public class SignalBusMonoInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
            
            // decleration info
            //Container.DeclareSignal<IPlayOnEvents.OnShowPlayOnBar>();
        }
    }
}
