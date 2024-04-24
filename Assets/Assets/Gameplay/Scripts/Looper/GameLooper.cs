using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Gameplay.Scripts.Common;
using Assets.Gameplay.Scripts.State;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Assets.Gameplay.Scripts.Looper
{
    public class GameLooper : MonoBehaviour
    {
        [Serializable]
        class GameLooperInitializersDictionary : UnitySerializedDictionary<GameLoopType, GameObject> { }
        [SerializeField] private GameLooperInitializersDictionary gameLoopPrefabs;

        [ShowInInspector]
        private static int _interactionLockCheck;
        
        [SerializeField] private bool isManagerActive = true;
        [SerializeField] private GameObject currentGameLoopBuilderObj;
        [SerializeField] private GameLoopBuilder currentGameLoopBuilder;
        
        [Sirenix.OdinInspector.ShowInInspector]
        private List<ITick> _loopList;

        [Sirenix.OdinInspector.ShowInInspector]
        private List<ITick> _firstOneTimeActionsList;

        [Sirenix.OdinInspector.ShowInInspector]
        private List<ITick> _fieldCreationActionsList;

        [Sirenix.OdinInspector.ShowInInspector]
        private List<ITick> _winActionsList;

        [Sirenix.OdinInspector.ShowInInspector]
        private List<ITick> _loseActionsList;

        [Sirenix.OdinInspector.ShowInInspector]
        private List<ITick> _playOnToGameActionsList;

        [Sirenix.OdinInspector.ShowInInspector]
        private GameObject _currentLoopObject;

        [Sirenix.OdinInspector.ShowInInspector]
        private IEnumerator _currentLoopTick;

        [Sirenix.OdinInspector.ShowInInspector]
        private IEnumerator _currentPreActionTick;

        [Sirenix.OdinInspector.ShowInInspector]
        private IEnumerator _currentFieldCreationActionTick;

        [Sirenix.OdinInspector.ShowInInspector]
        private IEnumerator _currentWinTick;

        [Sirenix.OdinInspector.ShowInInspector]
        private IEnumerator _currentLoseTick;

        [Sirenix.OdinInspector.ShowInInspector]
        private IEnumerator _currentPlayOnToGameTick;
        
        private IInstantiator _instantiator;
        
        private GameStateController _gameStateController;

        private bool _isGameWinActionsStarted;


        private bool _duplicateCheck;
        
        private Coroutine _mainGameLoop;
        private Coroutine _loseActionsCor;
        private Coroutine _currentLoseActionCor;
        
        [Inject]
        private void Construct(IInstantiator instantiator, GameStateController gameStateController)
        {
            _instantiator = instantiator;
            _gameStateController = gameStateController;
        }
        
        private void Start()
        {
            _gameStateController.OnGameStateChanged += HandleGameStateChange;
        }
        
        private void OnDestroy()
        {
            _gameStateController.OnGameStateChanged -= HandleGameStateChange;
        }

        private void HandleGameStateChange(GameState gameState)
        {
            if (gameState == GameState.Play || gameState == GameState.Resume)
            {
                _duplicateCheck = false;
            }
        }
        
        public static void IncreaseInteractionLock()
        {
            _interactionLockCheck++;
        }

        public static void DecreaseInteractionLock()
        {
            _interactionLockCheck--;
        }

        public static bool CheckIfInteractionsEnded()
        {
            return _interactionLockCheck <= 0;
        }
        
        private void Awake()
        {
            InitializeLoopList();
        }
        
        public static int GetInteractionLockValue()
        {
            return _interactionLockCheck;
        }

        private void InitializeLoopList()
        {
            _loopList = new List<ITick>();
            _firstOneTimeActionsList = new List<ITick>();
            _fieldCreationActionsList = new List<ITick>();
            _winActionsList = new List<ITick>();
            _loseActionsList = new List<ITick>();
            _playOnToGameActionsList = new List<ITick>();
        }

        public void SetGameLoop(GameLoopType gameMode)
        {
            if (!gameLoopPrefabs.ContainsKey(gameMode))
            {
                Debug.LogError($"Given level mode's : {gameMode} Game Looper Prefab is not added to GameLooperManager -> GameLooperPrefabs! Please add required Prefab!");
                return;
            }

            if (currentGameLoopBuilderObj != null)
            {
                Destroy(currentGameLoopBuilderObj);
            }

            currentGameLoopBuilderObj = _instantiator.InstantiatePrefab(gameLoopPrefabs[gameMode], transform.position, Quaternion.identity, transform);
            try
            {
                currentGameLoopBuilder = currentGameLoopBuilderObj.GetComponent<GameLoopBuilder>();
                currentGameLoopBuilder.CheckValidateAndInitializeBuilder();
            }
            catch (System.Exception e)
            {
                Debug.LogError($"Error while gettin BaseGameLooper from CurrentGameLoopBuilderObj! CurrentGameLoopBuilderObj name is : {currentGameLoopBuilderObj}. Please check the prefab for corresponding Game Mode : {gameMode}! Error : {e}");
            }
        }
        
        public void BuildGameLoop()
        {
            if (currentGameLoopBuilder == null)
            {
                Debug.LogError($"CurrentGameLoopBuilder is null! Cannot build GameLoop!");
                return;
            }

            _loopList.Clear();
            _firstOneTimeActionsList.Clear();
            _fieldCreationActionsList.Clear();
            _winActionsList.Clear();
            _loseActionsList.Clear();
            _playOnToGameActionsList.Clear();

            if (currentGameLoopBuilder != null)
            {
                currentGameLoopBuilder.BuildLooper(ref _loopList);
                currentGameLoopBuilder.BuildFirstTimeActions(ref _firstOneTimeActionsList);
                currentGameLoopBuilder.BuildFieldCreationActions(ref _fieldCreationActionsList);
                currentGameLoopBuilder.BuildWinActions(ref _winActionsList);
                currentGameLoopBuilder.BuildLoseActions(ref _loseActionsList);
            }
        }
        
        public void StartFirstTimeActions()
        {
            if (!GetIsManagerActive())
                return;
                
            StartCoroutine(ExecuteFirstTimeActions());
        }

        private IEnumerator ExecuteFirstTimeActions()  
        {
            for (int i = 0; i < _firstOneTimeActionsList.Count; i++)
            {
                _currentPreActionTick = _firstOneTimeActionsList[i].Tick();

                if (_firstOneTimeActionsList[i].WillWait)
                {
                    yield return StartCoroutine(_currentPreActionTick);
                }
                else
                {
                    StartCoroutine(_currentPreActionTick);
                }
            }

            _currentPreActionTick = null;
            StartFieldCreationActions();
        }

        public void StartFieldCreationActions()
        {
            if (!GetIsManagerActive())
                return;
                
            StartCoroutine(ExecuteFieldCreationActions());
        }

        private IEnumerator ExecuteFieldCreationActions()
        {
            for (int i = 0; i < _fieldCreationActionsList.Count; i++)
            {
                _currentFieldCreationActionTick = _fieldCreationActionsList[i].Tick();

                if (_fieldCreationActionsList[i].WillWait)
                {
                    yield return StartCoroutine(_currentFieldCreationActionTick);
                }
                else
                {
                    StartCoroutine(_currentFieldCreationActionTick);
                }
            }

            _currentFieldCreationActionTick = null;
            StartMainGameLoop();
        }

        public void StartMainGameLoop()
        {
            if (!GetIsManagerActive())
                return;
            
            if(_mainGameLoop != null)
                StopCoroutine(_mainGameLoop);
            
            _mainGameLoop = StartCoroutine(MainGameLoop());
        }

        private IEnumerator MainGameLoop()
        {
            foreach (var tick in _loopList)
            {
                _currentLoopTick = tick.Tick();

                if (tick.WillWait)
                {
                    yield return StartCoroutine(_currentLoopTick);
                }
                else
                {
                    StartCoroutine(_currentLoopTick);
                }
            }
            
            _currentLoopTick = null;
            yield break;
        }


        //TODO: Match3 takma
        public void StartWinActions()
        {
            if (!GetIsManagerActive())
                return;
        
            if (_isGameWinActionsStarted)
            {
                Debug.LogException(new Exception("Exception! Game win actions already started, returning..."));
                return;
            }
            
            if (_gameStateController.GetGameState() == GameState.Win)
            {
                Debug.LogException(new Exception("Exception! Current game state is already Win, returning..."));
                return;
            }
        
            _isGameWinActionsStarted = true;
            
            _gameStateController.SetGameState(GameState.Win);
        
            Debug.Log("Starting Win Actions...");
            
            //TODO: Match3 takma
            // if (_firstInputReceivedGetter.IsFirstInputReceived())
            // {
            //     OnFirstInputReceived?.Invoke(false);
            //     _lifeController.AddLife(1,  true);
            // }
            
            StartCoroutine(WinActions());
        }

        private IEnumerator WinActions()
        {
            foreach (var winTick in _winActionsList)
            {
                _currentWinTick = winTick.Tick();

                if (winTick.WillWait)
                {
                    yield return StartCoroutine(_currentWinTick);
                }
                else
                {
                    StartCoroutine(_currentWinTick);
                }
            }

            _currentWinTick = null;
        }
        
        
        public void StartLoseActions()
        {
            if (!GetIsManagerActive())
                return;
            if (_duplicateCheck)
                return;
            _duplicateCheck = true;

            _loseActionsCor = StartCoroutine(LoseActions());
        }

        private IEnumerator LoseActions()
        {
            foreach (var loseTick in _loseActionsList)
            {
                _currentLoseTick = loseTick.Tick();
                _currentLoseActionCor = StartCoroutine(_currentLoseTick);

                if (loseTick.WillWait)
                {
                    yield return _currentLoseActionCor;
                }
            }

            _currentLoseTick = null;

            yield break;
        }

        public void StartPlayOnToGameActions()
        {
            if (!GetIsManagerActive())
                return;
            
            StopLoseActions();
            
            _duplicateCheck = false;
            StartCoroutine(PlayOnToGameActions());
        }

        public void StopLoseActions()
        {
            if(_currentLoseActionCor != null)
                StopCoroutine(_currentLoseActionCor);

            _currentLoseTick = null;
            
            if(_loseActionsCor != null)
                StopCoroutine(_loseActionsCor);
        }
        
        private IEnumerator PlayOnToGameActions()
        {
            foreach (var playOnToGameTick in _playOnToGameActionsList)
            {
                _currentPlayOnToGameTick = playOnToGameTick.Tick();

                if (playOnToGameTick.WillWait)
                {
                    yield return StartCoroutine(_currentPlayOnToGameTick);
                }
                else
                {
                    StartCoroutine(_currentPlayOnToGameTick);
                }
            }

            _currentPlayOnToGameTick = null;
            yield break;
        }

        [Sirenix.OdinInspector.Button()]
        private void DebugAllTickInfo()
        {
            // foreach (var tick in _loopList)
            // {
            //     try
            //     {
            //         Debug.LogError(tick.DebugInfo());
            //     }
            //     catch
            //     {
            //         // ignored
            //     }
            // }
        }

        public void InitAllTicks()
        {
            foreach (var tick in _loopList)
            {
                try
                {
                    tick.InitTick();
                }
                catch (System.Exception e)
                {
                    Debug.LogError("Error while Initializing Tick : " + tick + "! Error : " + e);
                }
            }

            foreach (var ftaTick in _firstOneTimeActionsList)
            {
                try
                {
                    ftaTick.InitTick();
                }
                catch (System.Exception e)
                {
                    Debug.LogError("Error while Initializing Tick : " + ftaTick + "! Error : " + e);
                }
            }
        }

        private void OnEnable()
        {
            SetIsManagerActive(true);
        }

        private void OnDisable()
        {
            SetIsManagerActive(false);
        }

        private void OnApplicationQuit()
        {
            SetIsManagerActive(false);
        }

        public bool GetIsManagerActive() => isManagerActive;

        public void SetIsManagerActive(bool value) => isManagerActive = value;
    }
}
