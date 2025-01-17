using System.Collections.Generic;
using System.Linq;
using Assets.Gameplay.Scripts.Events;
using Assets.Gameplay.Scripts.SceneSystem;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Gameplay.Scripts.UI
{
    public class GameWinScreen : MonoBehaviour
    {
        [SerializeField] private Button GameWinButton;

        [SerializeField] private Button ScreenButton;
        
        private SceneLoader _sceneLoader;
        private SignalBus _signalBus;
        
        [ValueDropdown("GetAllScenes")][SerializeField] protected string _loadScene;
        
        
        [Inject]
        private void Construct(SceneLoader sceneLoader, SignalBus signalBus)
        {
            _sceneLoader = sceneLoader;
            _signalBus = signalBus;
            Init();
        }
        private void Init()
        {
            GameWinButton.onClick.AddListener(OnLeaveButtonClicked);
            ScreenButton.onClick.AddListener(OnScreenButtonClicked);
            
            _signalBus.Subscribe<IGameplayEvents.OnGameWin>(OnGameWin);
        }

        private void OnDestroy()
        {
            GameWinButton.onClick.RemoveAllListeners();
            ScreenButton.onClick.RemoveAllListeners();
            
            _signalBus.Unsubscribe<IGameplayEvents.OnGameWin>(OnGameWin);
        }

        private void OnGameWin()
        {
            gameObject.SetActive(true);
        }

        private void OnLeaveButtonClicked()
        {
            LoadMainMenu();
            gameObject.SetActive(false);
        }

        private void OnScreenButtonClicked()
        {
            LoadMainMenu();
            gameObject.SetActive(false);
        }
        
        private void LoadMainMenu()
        {
            _sceneLoader.LoadSceneAsync(_loadScene);
        }
        
#if UNITY_EDITOR
        protected IEnumerable<string> GetAllScenes()
        {
            return (from scene in EditorBuildSettings.scenes where scene.enabled select scene.path).ToArray();
        }
#endif
    }
}
