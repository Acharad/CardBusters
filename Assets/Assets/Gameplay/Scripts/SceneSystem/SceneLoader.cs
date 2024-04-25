using System;
using System.Threading;
using System.Threading.Tasks;
using Assets.Gameplay.Scripts.SystemScripts;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Gameplay.Scripts.SceneSystem
{
    public class SceneLoader
    {
        public struct SceneLoadEventArgs
        {
            public readonly string OldScene;
            public readonly string NewScene;

            public SceneLoadEventArgs(string oldScene, string newScene)
            {
                OldScene = oldScene;
                NewScene = newScene;
            }

            public override string ToString()
            {
                return $"SceneLoadEventArgs({OldScene}->{NewScene})";
            }
        }

        public delegate void SceneLoadHandler(SceneLoadEventArgs args);

        public event SceneLoadHandler OnSceneLoading;
        public event SceneLoadHandler OnSceneLoaded;

        private readonly TimeSpan _timeout;

        private readonly TaskSequence _sequenceBeforeLoad;
        private readonly TaskSequence _sequenceAfterLoad;

        public string PreviousScene => _previousScene;

        public string CurrentScene
        {
            get => _currentScene = string.IsNullOrEmpty(_currentScene)
                ? SceneManager.GetActiveScene().name
                : _currentScene;
            private set
            {
                _previousScene = _currentScene;
                _currentScene = value;
            }
        }

        private Task _runningTask;

        public string SceneToLoad { get; private set; }

        private string _previousScene;
        private string _currentScene;

        public void AppendBeforeLoad(Func<Task> taskFactory)
        {
            if (_runningTask != null)
            {
                Debug.LogWarning("Scene load in progress");
                return;
            }
            _sequenceBeforeLoad.Append(taskFactory);
        }

        public void JoinBeforeLoad(Func<Task> taskFactory)
        {
            if (_runningTask != null)
            {
                Debug.LogWarning("Scene load in progress");
                return;
            }
            _sequenceBeforeLoad.Join(taskFactory);
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

        public void JoinAfterLoad(Func<Task> taskFactory)
        {
            if (_runningTask != null)
            {
                Debug.LogWarning("Scene load in progress");
                return;
            }
            _sequenceAfterLoad.Join(taskFactory);
        }

        public SceneLoader(TimeSpan timeout)
        {
            // todo maybe add a default constructor using Timeout.InfiniteTimeSpan
            _timeout = timeout;

            _sequenceBeforeLoad = new TaskSequence();
            _sequenceAfterLoad = new TaskSequence();
        }

        [Button]
        public void LoadScene(string sceneToLoad)
        {
            SceneToLoad = sceneToLoad;
            LoadSceneAsync().FireAndForget();
        }

        public Task LoadSceneAsync(string sceneToLoad)
        {
            if (_runningTask != null)
                return _runningTask;

            SceneToLoad = sceneToLoad;
            _runningTask = LoadSceneAsync();
            return _runningTask;
        }

        private async Task LoadSceneAsync()
        {
            using var cts = new CancellationTokenSource(_timeout);
            var asyncOp = SceneManager.LoadSceneAsync(SceneToLoad);
            asyncOp.allowSceneActivation = false;
            await _sequenceBeforeLoad.RunAsync(cts.Token);

            OnSceneLoading?.Invoke(new SceneLoadEventArgs(CurrentScene, SceneToLoad));
            await LoadSceneInternal(asyncOp);

            await _sequenceAfterLoad.RunAsync(CancellationToken.None);
            OnSceneLoaded?.Invoke(new SceneLoadEventArgs(PreviousScene, CurrentScene));

            _sequenceAfterLoad.Clear();
            _sequenceBeforeLoad.Clear();
            _runningTask = null;
        }

        private async Task LoadSceneInternal(AsyncOperation asyncOp)
        {
            // scene1 -> scene2 -> scene3
            //       S1,S2    S2,S3

            Debug.Log($"Load Scene {SceneToLoad}, time: {Time.time}");

            while (!asyncOp.isDone)
            {
                if (asyncOp.progress >= 0.9f)
                    asyncOp.allowSceneActivation = true;
                await Task.Delay(16);
            }

            CurrentScene = SceneToLoad;
            SceneToLoad = null;

            Debug.Log($"Scene Loaded {CurrentScene}, time: {Time.time}");
        }

    }
}
