using Assets.Gameplay.Scripts.Looper;
using Zenject;

namespace Assets.Gameplay.Scripts.UI.ButtonScripts
{
    public class TurnEndButton : AbstractButton
    {
        private GameLooper _gameLooper;
        [Inject]
        private void Construct(GameLooper gameLooper)
        {
            _gameLooper = gameLooper;
            
        }
        protected override void OnClickListener()
        {
            _gameLooper.StartTurnEndActions();
        }
    }
}
