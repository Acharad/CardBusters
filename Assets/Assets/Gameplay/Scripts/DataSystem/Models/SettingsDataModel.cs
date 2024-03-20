using Assets.Gameplay.Scripts.DataSystem.Interface;

namespace Assets.Gameplay.Scripts.DataSystem.Models
{
    public class SettingsDataModel : IDataChanged<SettingsDataModel>
    {
        private float _music;
        private float _sound;

        public float Music
        {
            get => _music;
            set
            {
                var data = Copy();
                _music = value;
                OnChanged?.Invoke(this, data);
            }
        }

        public float Sound
        {
            get => _sound;
            set
            {
                var data = Copy();
                _sound = value;
                OnChanged?.Invoke(this, data);
            }
        }

        public event IDataChanged<SettingsDataModel>.OnChangeHandler OnChanged;
        public SettingsDataModel Copy()
        {
            var data = new SettingsDataModel
            {
                _music = Music,
                _sound = Sound,
            };
            
            return data;
        }
    }
}
