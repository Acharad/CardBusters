using System.Collections.Generic;
using Assets.Gameplay.Scripts.DataSystem.ConsumableData;
using Assets.Gameplay.Scripts.DataSystem.Interface;

namespace Assets.Gameplay.Scripts.DataSystem.Consumable
{
    [System.Serializable]
    public class ConsumableData : IConsumableData<ConsumableData>
    {
        public List<ConsumableItem> consumableItems = new List<ConsumableItem>();
        
        public event IDataChanged<ConsumableData>.OnChangeHandler OnChanged;
        
        public bool IsValid => Validate();

        protected bool Validate()
        {
            foreach (var consumableItem in consumableItems)
            {
                if (consumableItem.Amount < 0)
                    return false;
            }

            return true;
        }

        public void Add(ConsumableData other)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(ConsumableData other)
        {
            throw new System.NotImplementedException();
        }

        public void Set(ConsumableData other)
        {
            throw new System.NotImplementedException();
        }

        public ConsumableData Copy()
        {
            throw new System.NotImplementedException();
        }

        private void InvokeOnChanged(ConsumableData oldData)
        {
            throw new System.NotImplementedException();
        }
    }
}
