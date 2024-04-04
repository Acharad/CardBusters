using System;
using System.Collections.Generic;
using Assets.Gameplay.Scripts.DataSystem.Interface;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Gameplay.Scripts.DataSystem.ConsumableData
{
    [System.Serializable]
    public class ConsumableItem : IDataChanged<ConsumableItem>
    {
        public event IDataChanged<ConsumableItem>.OnChangeHandler OnChanged;
        // [ValueDropdown(nameof(ConsumableNames))]
        [SerializeField] private string _name;

        [SerializeField] private long _amount;

        [HideInInspector][SerializeField] private bool _isUnlimited;
        
        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public long Amount
        {
            get => _amount;
            set => _amount = value;
        }

        public bool IsUnlimited
        {
            get => _isUnlimited;
            set => _isUnlimited = value;
        }

        public ConsumableItem(string name, long amount)
        {
            _name = name;
            _amount = amount;
        }
        
        
        public virtual void Add(long amount)
        {
            var oldData = Copy();

            if (IsUnlimited)
            {
                AddUnlimited(amount);
                return;
            }

            _amount += amount;
            OnChanged?.Invoke(this, oldData);
        }

        public virtual void Remove(long amount)
        {
            var oldData = Copy();

            _amount -= amount;
            OnChanged?.Invoke(this, oldData);
        }

        public virtual void Set(long amount)
        {
            var oldData = Copy();

            if (_amount == amount) return;
        
            _amount = amount;
            OnChanged?.Invoke(this, oldData);
        }

        public void AddUnlimited(long amount)
        {
            if (amount <= 0)
                return;

            long newUnlimitedExpireTime = 0;

            // var unixTimeSeconds = DefaultDateTimeNowProvider.Instance.UtcNow.ToUnixTimeSeconds();
            var unixTimeSeconds = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

            if (_amount < unixTimeSeconds)
                newUnlimitedExpireTime = unixTimeSeconds + amount;
            else
                newUnlimitedExpireTime = _amount + amount;

            _amount = newUnlimitedExpireTime;
        }
    
        public long GetNormalizedCount()
        {
            var amount = _isUnlimited ? _amount - DateTimeOffset.UtcNow.ToUnixTimeSeconds() : _amount;
            return amount;
        } 
        public long GetNormalizedCountForEvent()
        {
            var amount = _isUnlimited ? _amount - DateTimeOffset.UtcNow.ToUnixTimeSeconds(): _amount;
            if (amount < 0)
            {
                amount = 0;
            }
            return amount;
        }

        public ConsumableItem Copy()
        {
            ConsumableItem copiedData = new ConsumableItem(Name, Amount)
            {
                IsUnlimited = IsUnlimited
            };

            return copiedData;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
