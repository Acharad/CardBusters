using System;
using System.Text.RegularExpressions;
using Assets.Gameplay.Scripts.SceneSystem;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;
using Zenject;


#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Assets.Gameplay.Scripts.UI.ButtonScripts
{
    public class LevelPlayButton : AbstractButton
    {
        private SceneLoader _sceneLoader;
        private SignalBus _signalBus;
        private LoadingScreenController _loadingScreenController;
        [ValueDropdown("GetAllScenes")][SerializeField] protected string _loadScene;
        
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
            var match = Regex.Match(_loadScene, pattern);
            
            
            //_sceneLoader.AppendBeforeLoad(_loadingScreenController.CloseAnimationAsync);
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
