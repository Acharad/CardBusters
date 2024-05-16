using System;
using System.Collections.Generic;
using Assets.Gameplay.Scripts.Looper;
using UnityEngine;
using UnityEngine.Serialization;

namespace Assets.Gameplay.Scripts.Looper
{
    public class GameLoopBuilder : MonoBehaviour, ILooperBuilder
    {
        [SerializeField] protected Transform gameEndLoopsParent;
        [SerializeField] protected Transform internalFTAsParent;
        [SerializeField] protected Transform internalFieldCreationActionsParent;
        [SerializeField] protected Transform internalWinActionsParent;
        [SerializeField] protected Transform internalLoseActionsParent;
        [SerializeField] protected Transform internalTurnEndParent;
        [SerializeField] protected Transform internalTurnStartParent;
        
        [Sirenix.OdinInspector.ShowInInspector] 
        protected List<ITick> GameEndLoopList;

        [Sirenix.OdinInspector.ShowInInspector] 
        protected List<ITick> InternalFTAList;
        
        [Sirenix.OdinInspector.ShowInInspector] 
        protected List<ITick> InternalFieldCreationActionsList;

        [Sirenix.OdinInspector.ShowInInspector] 
        protected List<ITick> InternalWinActionsList;

        [Sirenix.OdinInspector.ShowInInspector] 
        protected List<ITick> InternalLoseActionsList;

        [Sirenix.OdinInspector.ShowInInspector]
        protected List<ITick> InternalTurnEndActionsList;
        
        [Sirenix.OdinInspector.ShowInInspector]
        protected List<ITick> InternalTurnStartActionsList;
        

        public virtual void BuildGameEndLooper(ref List<ITick> loopList)
        {
            for (int i = 0; i < GameEndLoopList.Count; i++)
            {
                loopList.Add(GameEndLoopList[i]);
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

        public virtual void BuildTurnEndActions(ref List<ITick> loopList)
        {
            for (int i = 0; i < InternalTurnEndActionsList.Count; i++)
            {
                loopList.Add(InternalTurnEndActionsList[i]);
            }
        }
        
        public virtual void BuildTurnStartActions(ref List<ITick> loopList)
        {
            for (int i = 0; i < InternalTurnStartActionsList.Count; i++)
            {
                loopList.Add(InternalTurnStartActionsList[i]);
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

            PopulateGameEndLoopList();
            PopulateInternalFTAsList();
            PopulateInternalFieldCreationActionsList();
            PopulateInternalWinActionsList();
            PopulateInternalLoseActionsList();
            PopulateInternalTurnEndActionsList();
            PopulateInternalTurnStartActionsList();
        }

        private bool ValidateInternalParents()
        {
            return gameEndLoopsParent != null
                   && internalFTAsParent != null
                   && internalFieldCreationActionsParent != null
                   && internalWinActionsParent != null
                   && internalLoseActionsParent != null;
        }

        [Sirenix.OdinInspector.Button]
        public void PopulateGameEndLoopList()
        {
            try
            {
                if (GameEndLoopList == null)
                {
                    GameEndLoopList = new List<ITick>();
                }

                GameEndLoopList.Clear();

                for (int i = 0; i < gameEndLoopsParent.childCount; i++)
                {
                    var childTick = gameEndLoopsParent.GetChild(i).GetComponent<ITick>();
                    GameEndLoopList.Add(childTick);
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

                for (int i = 0; i < internalLoseActionsParent.childCount; i++)
                {
                    var childTick = internalLoseActionsParent.GetChild(i).GetComponent<ITick>();
                    InternalLoseActionsList.Add(childTick);
                }
            }
            catch (System.Exception e)
            {
                Debug.LogError(e);
            }
        }

        [Sirenix.OdinInspector.ShowInInspector]
        public void PopulateInternalTurnEndActionsList()
        {
            try
            {
                if (InternalTurnEndActionsList == null)
                {
                    InternalTurnEndActionsList = new();
                }
                
                InternalTurnEndActionsList.Clear();

                for (int i = 0; i < internalTurnEndParent.childCount; i++)
                {
                    var childTick = internalTurnEndParent.GetChild(i).GetComponent<ITick>();
                    InternalTurnEndActionsList.Add(childTick);
                }
                
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
        }
        
        [Sirenix.OdinInspector.ShowInInspector]
        public void PopulateInternalTurnStartActionsList()
        {
            try
            {
                if (InternalTurnStartActionsList == null)
                {
                    InternalTurnStartActionsList = new();
                }
                
                InternalTurnStartActionsList.Clear();

                for (int i = 0; i < internalTurnStartParent.childCount; i++)
                {
                    var childTick = internalTurnStartParent.GetChild(i).GetComponent<ITick>();
                    InternalTurnStartActionsList.Add(childTick);
                }
                
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
        }
    }
}
