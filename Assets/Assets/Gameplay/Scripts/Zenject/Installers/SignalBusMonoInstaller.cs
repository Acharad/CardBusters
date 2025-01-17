using Assets.Gameplay.Scripts.Events;
using UnityEngine;
using Zenject;

namespace Assets.Gameplay.Scripts.Zenject.Installers
{
    public class SignalBusMonoInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
            
            //turn events
            Container.DeclareSignal<IGameplayEvents.OnTurnEnd>();
            Container.DeclareSignal<IGameplayEvents.OnTurnStart>();
            Container.DeclareSignal<IGameplayEvents.OnTurnEndLocationAction>();

            //game events
            Container.DeclareSignal<IGameplayEvents.OnGameWin>();
            Container.DeclareSignal<IGameplayEvents.OnGameLose>();
            Container.DeclareSignal<IGameplayEvents.OnGameEnd>();
            
            Container.DeclareSignal<IGameplayEvents.OnCardAddedToLocation>();
            
            //data events
            Container.DeclareSignal<IGameplayEvents.OnPlayerManaChanged>();
            Container.DeclareSignal<IGameplayEvents.OnEnemyManaChanged>();
        }
    }
}
