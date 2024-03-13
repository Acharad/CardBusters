using System.Collections.Generic;
using System.Linq;
using ModestTree;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;
using Zenject.Internal;

namespace Assets.Gameplay.Scripts.Zenject
{
    public class ProjectContextExtended : ProjectContext
    {
        protected override void GetInjectableMonoBehaviours(List<MonoBehaviour> monoBehaviours)
        {
            // disable state machine injectors
            // ZenUtilInternal.AddStateMachineBehaviourAutoInjectersUnderGameObject(gameObject);
            ZenUtilInternal.GetInjectableMonoBehavioursUnderGameObject(gameObject, monoBehaviours);
        }
        
        [Button]
        private void CopyFrom()
        {
#if UNITY_EDITOR
            var contexts = GetComponents<ProjectContext>();
            var source = contexts.First(ctx => ctx != this);
            UnityEditor.EditorUtility.CopySerializedManagedFieldsOnly(source, this);

            UnityEditor.AssetDatabase.Refresh();
#endif
        }

        [Button]
        private void RefreshInstallers()
        {
#if UNITY_EDITOR
            var savedInstallers = Installers as List<MonoInstaller> ?? new List<MonoInstaller>(0);
            var actualInstallers = new List<MonoInstaller>(GetComponents<MonoInstaller>().Where(c => c.enabled));

            var installersToRemove = new List<MonoInstaller>(savedInstallers.Except(actualInstallers));
            var installersToAdd = new List<MonoInstaller>(actualInstallers.Except(savedInstallers));

            if (installersToRemove.IsEmpty() && installersToAdd.IsEmpty())
            {
                Debug.Log("No need to update mono installers.");
                return;
            }

            foreach (var installer in installersToRemove)
            {
                savedInstallers.Remove(installer);
            }

            foreach (var installer in installersToAdd)
            {
                savedInstallers.Add(installer);
            }

            Debug.Log("Updated mono installers.");
            Debug.Log($"Removed ({installersToRemove.Count}):\n{string.Join('\n', installersToRemove)}");
            Debug.Log($"Added ({installersToAdd.Count}):\n{string.Join('\n', installersToAdd)}");
#endif
        }
        
    }
}
