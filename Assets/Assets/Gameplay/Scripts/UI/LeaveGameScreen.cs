using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Gameplay.Scripts.SceneSystem;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Gameplay.Scripts.UI
{
    public class LeaveGameScreen : MonoBehaviour
    {
        [SerializeField] private Button LeaveButton;
        [SerializeField] private Button ContinueButton;
        [SerializeField] private Button ScreenButton;
        private SceneLoader _sceneLoader;
        [ValueDropdown("GetAllScenes")][SerializeField] protected string _loadScene;

        [Inject]
        private void Construct(SceneLoader sceneLoader, SignalBus signalBus)
        {
            _sceneLoader = sceneLoader;
            // _loadingScreenController = loadingScreenController;
        }
        private void Start()
        {
            LeaveButton.onClick.AddListener(LoadMainMenu);
            ContinueButton.onClick.AddListener(CloseScreen);
            ScreenButton.onClick.AddListener(OnScreenButtonClicked);
        }

        private void OnDestroy()
        {
            LeaveButton.onClick.RemoveAllListeners();
            ContinueButton.onClick.RemoveAllListeners();
            ScreenButton.onClick.RemoveAllListeners();
        }


        private void LoadMainMenu()
        {
            _sceneLoader.LoadSceneAsync(_loadScene);
        }

        private void CloseScreen()
        {
            gameObject.SetActive(false);
        }
        
        private void OnScreenButtonClicked()
        {
            gameObject.SetActive(false);
        }
        
#if UNITY_EDITOR
        protected IEnumerable<string> GetAllScenes()
        {
            return (from scene in EditorBuildSettings.scenes where scene.enabled select scene.path).ToArray();
        }
#endif
    }
}
