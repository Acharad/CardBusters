using Assets.Gameplay.Scripts.DataSystem;
using Assets.Gameplay.Scripts.DataSystem.Models;
using Assets.Gameplay.Scripts.DataSystem.Views;
using Zenject;

namespace Assets.Gameplay.Scripts.Zenject.Installers.Data
{
    public class CardBusterPlayerDataInstaller : MonoInstaller
    {
        private const string _settingsDataFileName = "settingsData.json";

        public override void InstallBindings()
        {
            Container.Bind<GameDeckData>().AsSingle();
            
            Container.Bind<CardBusterPlayerData>().AsSingle();
            Container.Bind<CardBusterEnemyData>().AsSingle();


            // Container.Bind<SettingsDataModel>().FromResolveGetter<CardBusterPlayerData>(data => data.SettingsDataModel).AsSingle();
            // Container.Bind<SettingsDataView>().AsTransient().WithConcreteId(_settingsDataFileName); 
        }
    }
}
