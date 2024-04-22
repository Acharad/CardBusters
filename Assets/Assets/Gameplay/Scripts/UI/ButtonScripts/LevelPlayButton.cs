using System.Text.RegularExpressions;
using Assets.Gameplay.Scripts.SceneSystem;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Assets.Gameplay.Scripts.UI.ButtonScripts
{
    public class LevelPlayButton : AbstractButton
    {
        private SceneLoader _sceneLoader;
        private SignalBus _signalBus;
        private LoadingScreenController _loadingScreenController;
        [ValueDropdown("GetAllScenes")]
        [SerializeField] private string _gameScene;
        
        [Inject]
        private void Construct(SceneLoader sceneLoader, SignalBus signalBus, LoadingScreenController loadingScreenController)
        {
            _sceneLoader = sceneLoader;
            _signalBus = signalBus;
            _loadingScreenController = loadingScreenController;
        }
        
        protected override void OnClickListener()
        {
            var pattern = @"([^/\\]+)\.unity$";
            var match = Regex.Match(_gameScene, pattern);
            
            
            //_sceneLoader.AppendBeforeLoad(_loadingScreenController.CloseAnimationAsync);
            _sceneLoader.LoadSceneAsync(_gameScene);
            
        }
    }
}
