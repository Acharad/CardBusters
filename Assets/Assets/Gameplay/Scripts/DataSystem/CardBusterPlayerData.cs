using System;
using Assets.Gameplay.Scripts.DataSystem.Models;
using Assets.Gameplay.Scripts.DataSystem.Views;
using UnityEngine;
using Zenject;

namespace Assets.Gameplay.Scripts.DataSystem
{
    public class CardBusterPlayerData : PlayerData
    {
        [NonSerialized] public SettingsDataModel SettingsDataModel;
        private SettingsDataView _settingsDataView;

        [NonSerialized] public GameplayCardDataModel GameplayCardDataModel;
        private GameplayCardDataView _gameplayCardDataView;


        [Inject]
        private void Construct(SettingsDataView settingsDataView, GameplayCardDataView gameplayCardDataView)
        {
            _settingsDataView = settingsDataView;
            _gameplayCardDataView = gameplayCardDataView;

            
            GameplayCardDataModel = _gameplayCardDataView.Load();
            SettingsDataModel = _settingsDataView.Load();
        }
    }
}
