using System;
using UnityEngine;
using Zenject;

namespace Assets.Gameplay.Scripts.State
{
    public class GameStateController : MonoBehaviour
    {
        [SerializeField] private GameState currentGameState;

        private SignalBus _signalBus;

        public event Action<GameState> OnGameStateChanged;

        private void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        private void Start()
        {
            SetGameState(GameState.Start);
        }

        private void OnDestroy()
        {
            //uns events.
        }

        public GameState GetGameState() => currentGameState;

        public void SetGameState(GameState state)
        {
            if (currentGameState == state)
            {
                return;
            }

            currentGameState = state;
            OnGameStateChanged?.Invoke(currentGameState);
        }
    } 
    
    public enum GameState
    {
        Blank,
        Start,
        Play,
        Resume,
        Pause,
        Win,
        Lose,
    }
}
