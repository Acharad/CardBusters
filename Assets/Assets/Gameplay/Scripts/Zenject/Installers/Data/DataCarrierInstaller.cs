using Assets.Gameplay.Scripts.DataSystem;
using Assets.Gameplay.Scripts.DataSystem.Models;
using Zenject;

namespace Assets.Gameplay.Scripts.Zenject.Installers.Data
{
    public class DataCarrierInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<DataCarrier<GameplayCardDataModel>>().WithId(DataCarrierIDs.GamePlayDataId).AsCached();
        }
    }


    public class DataCarrierIDs
    {
        public const string GamePlayDataId = "GamePlayData";
    }
}
