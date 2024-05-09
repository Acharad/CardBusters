using Assets.Gameplay.Scripts.Card;
using UnityEngine;
using Zenject;

namespace Assets.Gameplay.Scripts.Zenject.Installers.Gameplay
{
    public class CardFactoryInstaller : MonoInstaller
    {
        [SerializeField] private CardFactory cardFactory;
        
        public override void InstallBindings()
        { 
            Container.BindInterfacesAndSelfTo<CardFactory>().FromInstance(cardFactory).AsSingle();
            Container.QueueForInject(cardFactory);
        }
    }
}
