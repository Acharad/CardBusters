using Assets.Gameplay.Scripts.DataSystem.Models;
using Zenject;

namespace Assets.Gameplay.Scripts.Zenject.Installers.Data
{
    public class CardBusterPlayerDataInstaller : MonoInstaller
    {
        private const string _settingsDataFileName = "settingsData.json";

        public override void InstallBindings()
        {
            Container.Bind<SettingsDataModel>().AsTransient().WithConcreteId(_settingsDataFileName); 
        }
    }
}
