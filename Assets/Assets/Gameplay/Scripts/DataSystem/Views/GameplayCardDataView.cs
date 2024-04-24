using System;
using System.IO;
using Assets.Gameplay.Scripts.DataSystem.Interface;
using Assets.Gameplay.Scripts.DataSystem.Models;
using UnityEngine;

namespace Assets.Gameplay.Scripts.DataSystem.Views
{
    public class GameplayCardDataView : IDataHandler<GameplayCardDataModel>
    {
        private string _filePath;
        public event Action<GameplayCardDataModel> OnDataSaved;
        public event Action<GameplayCardDataModel> OnDataLoad;
        public GameplayCardDataModel Data { get; private set; }

        public GameplayCardDataView(string filePath)
        {
            _filePath = $"{Application.persistentDataPath}/{filePath}";
        }
        

        public GameplayCardDataModel Load()
        {
            if (Data != null)
            {
                return Data;
            }

            if (!File.Exists(_filePath))
            {
                Data = new GameplayCardDataModel()
                {
                    PlayerCardsInDeck = null,
                    PlayerCardsInHand = null,
                    ManaCount = 3,
                    MaxManaCount = 3,
                };
            }
            else
            {
                var fileContent = File.ReadAllText(_filePath);
                Data = JsonUtility.FromJson<GameplayCardDataModel>(fileContent);
            }
            
            Data.OnChanged += (newData, _) => Save(newData);
            OnDataLoad?.Invoke(Data);
            return Data;

        }

        public void Save(GameplayCardDataModel data)
        {
            var backup = Data;
            try
            {
                var json = JsonUtility.ToJson(data);
                File.WriteAllText(_filePath, json);

                Data = data;
                OnDataSaved?.Invoke(Data);
            }
            catch (Exception e)
            {
                Debug.LogError(e);
                Data = backup;
                throw;
            }
            OnDataSaved?.Invoke(Data);
        }
    }
}
