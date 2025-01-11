using Assets.Gameplay.Scripts.Events;
using Assets.Gameplay.Scripts.Looper;
using Zenject;

namespace Assets.Gameplay.Scripts.UI.ButtonScripts
{
    public class TurnEndButton : AbstractButton
    {
        private GameLooper _gameLooper;
        [Inject] private SignalBus _signalBus;
        
        [Inject]
        private void Construct(GameLooper gameLooper)
        {
            _gameLooper = gameLooper;
            _signalBus.Subscribe<IGameplayEvents.OnGameEnd>(CloseButtonInteractable);
        }

        private void CloseButtonInteractable()
        {
            Button.interactable = false;
        }
        
        
        protected override void OnClickListener()
        {
            _gameLooper.StartTurnEndActions();
        }
    }
}
