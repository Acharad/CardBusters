using Assets.Gameplay.Scripts.Card;
using Assets.Gameplay.Scripts.Location;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Assets.Gameplay.Scripts.Zenject.Installers.UI
{
    public class DeckPositionHolderInstaller : MonoInstaller
    {
        [SerializeField] private DeckPositionHolder deckPositionHolder;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<DeckPositionHolder>().FromInstance(deckPositionHolder).AsSingle();
            Container.QueueForInject(deckPositionHolder);
        }
    }
}
