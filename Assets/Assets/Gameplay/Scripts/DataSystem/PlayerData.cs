using Assets.Gameplay.Scripts.DataSystem.Interface;
using System;
using UnityEngine;
using Assets.Gameplay.Scripts.DataSystem.Consumable;


namespace Assets.Gameplay.Scripts.DataSystem
{
    [Serializable]
    public class PlayerData : IDataChanged<PlayerData>
    {
        public event IDataChanged<PlayerData>.OnChangeHandler OnChanged;
        [SerializeField] private Consumable.ConsumableData _consumableData;

        public PlayerData()
        {
            _consumableData = new Consumable.ConsumableData();
        }
        
        
        public PlayerData Copy()
        {
            PlayerData copiedData = new PlayerData
            {
                _consumableData = _consumableData.Copy(),
            };
            return copiedData;
        }

        public void CopyInto(PlayerData target)
        {
            PlayerData backup = Copy();

            target._consumableData = _consumableData.Copy();

            target.OnChanged?.Invoke(this, backup);
        }
    }
}
