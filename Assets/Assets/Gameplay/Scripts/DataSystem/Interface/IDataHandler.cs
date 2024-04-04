using System;

namespace Assets.Gameplay.Scripts.DataSystem.Interface
{
    public interface IDataHandler<T>  where T : IDataChanged<T>
    {
        public event Action<T> OnDataSaved;
        public event Action<T> OnDataLoad;

        public T Data { get; }

        T Load();
        void Save(T data);
    }
}
