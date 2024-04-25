namespace Assets.Gameplay.Scripts.DataSystem
{
    public class DataCarrier<T>
    {
        public T Data;

        public void ResetData()
        {
            Data = default(T);
        }

        public void SetData(T data)
        {
            Data = data;
        }
    }
}