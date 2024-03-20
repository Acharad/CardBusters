namespace Assets.Gameplay.Scripts.DataSystem.Interface
{
    public interface IDataChanged<T>
    {
        delegate void OnChangeHandler(T updatedData, T oldData);

        public event OnChangeHandler OnChanged;

        public T Copy();
    }
}
