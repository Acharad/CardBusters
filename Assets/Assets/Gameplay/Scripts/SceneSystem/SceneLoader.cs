using System;
using System.Collections;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Assets.Gameplay.Scripts.SystemScripts;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using AsyncOperation = UnityEngine.AsyncOperation;

namespace Assets.Gameplay.Scripts.SceneSystem
{
    public class SceneLoader
    {
        public event Action<SceneLoadData> OnSceneLoadStart;
        public event Action<SceneLoadData> OnSceneLoadFinished;
        private string _oldScene;
        private string _currentScene;
        private readonly TimeSpan _timeout;
        
        private readonly TaskSequence _sequenceBeforeLoad;
        private readonly TaskSequence _sequenceAfterLoad;

        public SceneLoader(TimeSpan timeout)
        {
            _timeout = timeout;
        }
        
        public string OldScene => _oldScene;
        public string CurrentScene
        {
            get => _currentScene = string.IsNullOrEmpty(_currentScene)
                ? SceneManager.GetActiveScene().name
                : _currentScene;
            private set
            {
                _oldScene = _currentScene;
                _currentScene = value;
            }
        }
        public string SceneToLoad { get; private set; }
        
        private Task _runningTask;
        // private readonly TaskSequence _sequenceBeforeLoad;
        // private readonly TaskSequence _sequenceAfterLoad;
        
        [Button]
        public void LoadScene(string sceneToLoad)
        {
            SceneToLoad = sceneToLoad;
            LoadSceneAsync();
        }


        public Task LoadSceneAsync(string sceneToLoad)
        {
            if (_runningTask != null)
                return _runningTask;
            

            SceneToLoad = sceneToLoad;
            _runningTask = LoadSceneAsync();
            return _runningTask;
        }
        
        public void AppendBeforeLoad(Func<Task> taskFactory)
        {
            if (_runningTask != null)
            {
                Debug.LogWarning("Scene load in progress");
                return;
            }
            _sequenceBeforeLoad.Append(taskFactory);
        }
        
        public void AppendAfterLoad(Func<Task> taskFactory)
        {
            if (_runningTask != null)
            {
                Debug.LogWarning("Scene load in progress");
                return;
            }
            _sequenceAfterLoad.Append(taskFactory);
        }

        private async Task LoadSceneAsync()
        {
            using var cts = new CancellationTokenSource(_timeout);
            var asyncOperation = SceneManager.LoadSceneAsync(SceneToLoad);

            asyncOperation.allowSceneActivation = false;
            OnSceneLoadStart?.Invoke(new SceneLoadData(CurrentScene, SceneToLoad));

            await LoadSceneInternal(asyncOperation);
            
            OnSceneLoadFinished?.Invoke(new SceneLoadData(OldScene, CurrentScene));


            _runningTask = null;
        }
        
        private async Task LoadSceneInternal(AsyncOperation asyncOp)
        {
            while (!asyncOp.isDone)
            {
                if (asyncOp.progress >= 1f)
                    asyncOp.allowSceneActivation = true;
                await Task.Delay(15);
            }

            CurrentScene = SceneToLoad;
            SceneToLoad = null;
            Debug.Log($"Scene Loaded {CurrentScene}, time: {Time.time}");
        }

        public class SceneLoadData
        {
            public string OldScene;
            public string NewScene;

            public SceneLoadData(string oldScene, string newScene)
            {
                OldScene = oldScene;
                NewScene = newScene;
            }
        }
    }
    
}
