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


        [Inject]
        private void Construct(SettingsDataView settingsDataView)
        {
            _settingsDataView = settingsDataView;







            SettingsDataModel = _settingsDataView.Load();
        }
    }
}
