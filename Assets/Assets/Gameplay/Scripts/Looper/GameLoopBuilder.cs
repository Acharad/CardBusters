using System.Collections.Generic;
using Assets.Gameplay.Scripts.Looper;
using UnityEngine;

namespace Assets.Gameplay.Scripts.Looper
{
    public class GameLoopBuilder : MonoBehaviour, ILooperBuilder
    {
        [SerializeField] protected Transform internalLoopsParent;
        [SerializeField] protected Transform internalFTAsParent;
        [SerializeField] protected Transform internalFieldCreationActionsParent;
        [SerializeField] protected Transform internalWinActionsParent;
        [SerializeField] protected Transform internalLoseActionsParent;
        [SerializeField] protected Transform internalPlayOnToGameActionsParent;
    
        [Sirenix.OdinInspector.ShowInInspector] 
        protected List<ITick> InternalLoopList;

        [Sirenix.OdinInspector.ShowInInspector] 
        protected List<ITick> InternalFTAList;
        
        [Sirenix.OdinInspector.ShowInInspector] 
        protected List<ITick> InternalFieldCreationActionsList;

        [Sirenix.OdinInspector.ShowInInspector] 
        protected List<ITick> InternalWinActionsList;

        [Sirenix.OdinInspector.ShowInInspector] 
        protected List<ITick> InternalLoseActionsList;

        [Sirenix.OdinInspector.ShowInInspector] 
        protected List<ITick> InternalPlayOnToGameActionsList;

        public virtual void BuildLooper(ref List<ITick> loopList)
        {
            for (int i = 0; i < InternalLoopList.Count; i++)
            {
                loopList.Add(InternalLoopList[i]);
            }
        }

        public virtual void BuildFirstTimeActions(ref List<ITick> loopList)
        {
            for (int i = 0; i < InternalFTAList.Count; i++)
            {
                loopList.Add(InternalFTAList[i]);
            }
        }

        public virtual void BuildFieldCreationActions(ref List<ITick> loopList)
        {
            for (int i = 0; i < InternalFieldCreationActionsList.Count; i++)
            {
                loopList.Add(InternalFieldCreationActionsList[i]);
            }
        }

        public virtual void BuildWinActions(ref List<ITick> loopList)
        {
            for (int i = 0; i < InternalWinActionsList.Count; i++)
            {
                loopList.Add(InternalWinActionsList[i]);
            }
        }

        public virtual void BuildLoseActions(ref List<ITick> loopList)
        {
            for (int i = 0; i < InternalLoseActionsList.Count; i++)
            {
                loopList.Add(InternalLoseActionsList[i]);
            }
        }

        public virtual void BuildPlayOnToGameActions(ref List<ITick> loopList)
        {
            for (int i = 0; i < InternalPlayOnToGameActionsList.Count; i++)
            {
                loopList.Add(InternalPlayOnToGameActionsList[i]);
            }
        }

        private void OnValidate()
        {
            CheckValidateAndInitializeBuilder();
        }

        [Sirenix.OdinInspector.Button]
        public void CheckValidateAndInitializeBuilder()
        {
            if (!ValidateInternalParents())
            {
                Debug.LogError($"On GameLoop : {gameObject.name}, InternalParents are not set correctly! Please check...", gameObject);
                return;
            }

            PopulateInternalLoopList();
            PopulateInternalFTAsList();
            PopulateInternalFieldCreationActionsList();
            PopulateInternalWinActionsList();
            PopulateInternalLoseActionsList();
            PopulateInternalPlayOnToGameActionsList();
        }

        private bool ValidateInternalParents()
        {
            return internalLoopsParent != null
                   && internalFTAsParent != null
                   && internalFieldCreationActionsParent != null
                   && internalWinActionsParent != null
                   && internalLoseActionsParent != null;
        }

        [Sirenix.OdinInspector.Button]
        public void PopulateInternalLoopList()
        {
            try
            {
                if (InternalLoopList == null)
                {
                    InternalLoopList = new List<ITick>();
                }

                InternalLoopList.Clear();

                ITick ChildTick;

                for (int i = 0; i < internalLoopsParent.childCount; i++)
                {
                    ChildTick = internalLoopsParent.GetChild(i).GetComponent<ITick>();
                    InternalLoopList.Add(ChildTick);
                }
            }
            catch (System.Exception e)
            {
                Debug.LogError(e);
            }
        }

        [Sirenix.OdinInspector.Button]
        public void PopulateInternalFTAsList()
        {
            try
            {
                if (InternalFTAList == null)
                {
                    InternalFTAList = new List<ITick>();
                }

                InternalFTAList.Clear();

                ITick ChildTick;

                for (int i = 0; i < internalFTAsParent.childCount; i++)
                {
                    ChildTick = internalFTAsParent.GetChild(i).GetComponent<ITick>();
                    InternalFTAList.Add(ChildTick);
                }
            }
            catch (System.Exception e)
            {
                Debug.LogError(e);
            }
        }

        [Sirenix.OdinInspector.Button]
        public void PopulateInternalFieldCreationActionsList()
        {
            try
            {
                if (InternalFieldCreationActionsList == null)
                {
                    InternalFieldCreationActionsList = new List<ITick>();
                }

                InternalFieldCreationActionsList.Clear();

                ITick ChildTick;

                for (int i = 0; i < internalFieldCreationActionsParent.childCount; i++)
                {
                    ChildTick = internalFieldCreationActionsParent.GetChild(i).GetComponent<ITick>();
                    InternalFieldCreationActionsList.Add(ChildTick);
                }
            }
            catch (System.Exception e)
            {
                Debug.LogError(e);
            }
        }

        [Sirenix.OdinInspector.Button]
        public void PopulateInternalWinActionsList()
        {
            try
            {
                if (InternalWinActionsList == null)
                {
                    InternalWinActionsList = new List<ITick>();
                }

                InternalWinActionsList.Clear();

                ITick ChildTick;

                for (int i = 0; i < internalWinActionsParent.childCount; i++)
                {
                    ChildTick = internalWinActionsParent.GetChild(i).GetComponent<ITick>();
                    InternalWinActionsList.Add(ChildTick);
                }
            }
            catch (System.Exception e)
            {
                Debug.LogError(e);
            }
        }

        [Sirenix.OdinInspector.Button]
        public void PopulateInternalLoseActionsList()
        {
            try
            {
                if (InternalLoseActionsList == null)
                {
                    InternalLoseActionsList = new List<ITick>();
                }

                InternalLoseActionsList.Clear();

                ITick ChildTick;

                for (int i = 0; i < internalLoseActionsParent.childCount; i++)
                {
                    ChildTick = internalLoseActionsParent.GetChild(i).GetComponent<ITick>();
                    InternalLoseActionsList.Add(ChildTick);
                }
            }
            catch (System.Exception e)
            {
                Debug.LogError(e);
            }
        }

        [Sirenix.OdinInspector.Button]
        public void PopulateInternalPlayOnToGameActionsList()
        {
            try
            {
                if (InternalPlayOnToGameActionsList == null)
                {
                    InternalPlayOnToGameActionsList = new List<ITick>();
                }

                InternalPlayOnToGameActionsList.Clear();

                ITick ChildTick;

                for (int i = 0; i < internalPlayOnToGameActionsParent.childCount; i++)
                {
                    ChildTick = internalPlayOnToGameActionsParent.GetChild(i).GetComponent<ITick>();
                    InternalPlayOnToGameActionsList.Add(ChildTick);
                }
            }
            catch (System.Exception e)
            {
                Debug.LogError(e);
            }
        }
    }
}
