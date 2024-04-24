using System.Collections.Generic;
using System.Linq;
using Assets.Gameplay.Scripts.DataSystem.ConsumableData;
using Assets.Gameplay.Scripts.DataSystem.Interface;
using JetBrains.Annotations;

namespace Assets.Gameplay.Scripts.DataSystem.Consumable
{
    [System.Serializable]
    public class ConsumableData : IConsumableData<ConsumableData>
    {
        public List<ConsumableItem> consumableItems = new List<ConsumableItem>();
        
        public event IDataChanged<ConsumableData>.OnChangeHandler OnChanged;
        
        public bool IsValid => Validate();
        private bool _isEventInProgress;

        protected bool Validate()
        {
            foreach (var consumableItem in consumableItems)
            {
                if (consumableItem.Amount < 0)
                    return false;
            }

            return true;
        }
        
        [CanBeNull]
        public ConsumableItem this[string consumableName] => FindConsumableIndex(consumableName);

        [CanBeNull]
        private ConsumableItem FindConsumableIndex(string consumableName)
        {
            return consumableItems.FirstOrDefault(consumableItem => consumableItem.Name == consumableName);
        }

        public void Add(ConsumableData other)
        {
            var oldData = Copy();
            foreach (var otherItem in other.consumableItems)
            {
                var consumableItem = FindConsumableIndex(otherItem.Name);
                if (consumableItem != null)
                {
                    consumableItem.Add(otherItem.Amount);
                }
                else
                {
                    consumableItems.Add(new ConsumableItem(otherItem.Name, otherItem.Amount));
                }
            }
            
            InvokeOnChanged(oldData);
        }

        public void Remove(ConsumableData other)
        {
            var oldData = Copy();
            
            foreach (var otherItem in other.consumableItems)
            {
                foreach (var consumableItem in consumableItems.Where(consumableItem => otherItem.Name == consumableItem.Name))
                {
                    consumableItem.Remove(otherItem.Amount);
                    break;
                }
            }
            
            InvokeOnChanged(oldData);
        }

        public void Set(ConsumableData other)
        {
            var oldData = Copy();

            foreach (var otherItem in other.consumableItems)
            {
                foreach (var consumableItem in consumableItems.Where(consumableItem => otherItem.Name == consumableItem.Name))
                {
                    consumableItem.Set(otherItem.Amount);
                    break;
                }
            }
            
            InvokeOnChanged(oldData);
        }

        public ConsumableData Copy()
        {
            var copiedConsumableData = new ConsumableData()
            {
                consumableItems = consumableItems.Select(i => i.Copy()).ToList()
            };
            return copiedConsumableData;
        }

        private void InvokeOnChanged(ConsumableData oldData)
        {
            if (_isEventInProgress)
                return;
            _isEventInProgress = true;
            OnChanged?.Invoke(this, oldData);
            _isEventInProgress = false;
        }
    }
}
