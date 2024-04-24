using UnityEngine;

namespace Assets.Gameplay.Scripts.DataSystem.Interface
{
    public interface IConsumableData<T> : IDataChanged<T> where T : IConsumableData<T>
    {
        public void Add(T other);
        public void Remove(T other);
        public void Set(T other);
        public bool IsValid { get; }
    }
}
