using Assets.Gameplay.Scripts.DataSystem.Views;
using Zenject;

namespace Assets.Gameplay.Scripts.DataSystem.Installer
{
    public class DataInstaller : MonoInstaller
    {
        private const string _playerSettings = "playerSettings.json";


        public override void InstallBindings()
        {
            //todo
            Container.Bind<SettingsDataView>().AsTransient().WithArguments(_playerSettings);
        }
    }
}
