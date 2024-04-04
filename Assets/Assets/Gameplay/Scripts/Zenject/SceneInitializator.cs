using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
using Sirenix.OdinInspector;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class SceneInitializator : MonoBehaviour
{
    [SerializeField] protected float minDelay = 1;
    [ValueDropdown("GetAllScenes")][SerializeField] protected string _loadScene;
    
    protected async void Start()
    {
        var activeSceneName = SceneManager.GetActiveScene().name;
        // if (systems != null && systems.Count > 0)
        // {
        //     var initializeTasks = systems.Select(s => s.InitializeAsync()).ToList();
        //     initializeTasks.Add(Task.Delay(TimeSpan.FromSeconds(minDelay)));
        //
        //     Logger.Log($"Initializing systems... ({activeSceneName})");
        //     await Task.WhenAll(initializeTasks);
        //     Logger.Log($"Systems initialized. ({activeSceneName})");
        // }
        
       Debug.Log($"Initializing systems... ({activeSceneName})");
       await Task.Delay(3000);
       Debug.Log($"No systems to initialize. ({activeSceneName})");
       
       LoadNextScene();
    }

    protected virtual void LoadNextScene()
    {
        SceneManager.LoadScene(_loadScene);
    }

#if UNITY_EDITOR
    protected IEnumerable<string> GetAllScenes()
    {
        return (from scene in EditorBuildSettings.scenes where scene.enabled select scene.path).ToArray();
    }
#endif
}