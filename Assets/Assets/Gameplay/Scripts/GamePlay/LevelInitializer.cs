using System;
using Assets.Gameplay.Scripts.DataSystem;
using Assets.Gameplay.Scripts.DataSystem.Models;
using Assets.Gameplay.Scripts.Looper;
using Assets.Gameplay.Scripts.Zenject.Installers.Data;
using UnityEngine;
using Zenject;

namespace Assets.Gameplay.Scripts.GamePlay
{
    public class LevelInitializer : MonoBehaviour
    {
        public event Action OnLevelDataLoaded;

        private DataCarrier<GameplayCardDataModel> _playerCardData;
        private GameLooper _gameLooper;

        
        [Inject]
        private void Construct([Inject(Id = DataCarrierIDs.GamePlayDataId)] DataCarrier<GameplayCardDataModel> playerCardData,
            GameLooper gameLooper)
        {
            _playerCardData = playerCardData;
            _gameLooper = gameLooper;
        }

        private void Start()
        {
            OnLevelDataLoaded?.Invoke();
            SetGameLooperType();
            _gameLooper.InitAllTicks();
            _gameLooper.StartFirstTimeActions();
        }

        private bool SetGameLooperType()
        {
            try
            {
                var gameLoopType = GameLoopType.Default;
                _gameLooper.SetGameLoop(gameLoopType);
                _gameLooper.BuildGameLoop();

                return true;
            }
            catch (Exception e)
            {
                Debug.LogError(e);
                return false;
            }
        }
    }
}
