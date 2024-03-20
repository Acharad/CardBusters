using System;
using Assets.Gameplay.Scripts.DataSystem.Interface;
using Assets.Gameplay.Scripts.DataSystem.Models;
using UnityEngine;

namespace Assets.Gameplay.Scripts.DataSystem.Views
{
    public class SettingsDataView : IDataHandler<SettingsDataModel>
    {
        private string _filePath;
        public event Action<SettingsDataModel> OnDataSaved;
        public event Action<SettingsDataModel> OnDataLoad;

        public SettingsDataView(string filePath)
        {
            _filePath = $"{Application.persistentDataPath}/{filePath}";
        }
        
        public SettingsDataModel Data { get; }
        public void Load()
        {
            //todo
            
            OnDataLoad?.Invoke(Data);
        }

        public void Save(SettingsDataModel data)
        {
            //todo
            OnDataSaved?.Invoke(Data);
        }
    }
}
