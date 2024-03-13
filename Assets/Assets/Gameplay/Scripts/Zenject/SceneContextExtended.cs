using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;
using Zenject.Internal;

namespace Assets.Gameplay.Scripts.Zenject
{
    public class SceneContextExtended : SceneContext
    {
        //     protected override void Awake()
//     {
//         // do nothing
//         // we don't want initialization during Awake as the scene is not yet loaded
//         // injection performance is unacceptable if the scene is not yet loaded
//
//         var scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
//         Debug.Log($"is scene ({scene.name}) loaded? {scene.isLoaded}");
//     }
//
//     private void Start()
//     {
// #if ZEN_INTERNAL_PROFILING
//         ProfileTimers.ResetAll();
//         using (ProfileTimers.CreateTimedBlock("Other"))
// #endif
//         {
//             Initialize();
//         }
//     }

        protected override void GetInjectableMonoBehaviours(List<MonoBehaviour> monoBehaviours)
        {
            var scene = gameObject.scene;

            // disable state machine injectors
            // we shouldn't sacrifice performance for the features we aren't using
            // ZenUtilInternal.AddStateMachineBehaviourAutoInjectersInScene(scene);
            ZenUtilInternal.GetInjectableMonoBehavioursInScene(scene, monoBehaviours);
        }
/*
        [Button]
        private void CopyFrom()
        {
#if UNITY_EDITOR
            var contexts = GetComponents<SceneContext>();
            var source = contexts.First(ctx => ctx != this);
            UnityEditor.EditorUtility.CopySerializedManagedFieldsOnly(source, this);

            UnityEditor.AssetDatabase.Refresh();
#endif
        }
        */
    }
}
