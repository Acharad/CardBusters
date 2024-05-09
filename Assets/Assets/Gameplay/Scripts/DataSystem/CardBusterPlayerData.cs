using System;
using Assets.Gameplay.Scripts.Card;
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
        

        public PlayerDeckData PlayerDeckData;


        [Inject]
        private void Construct(PlayerDeckData playerDeckData)
        {
            //_settingsDataView = settingsDataView;
            PlayerDeckData = playerDeckData;
            
            PlayerDeckData.PlayerDeck.Add(CardType.Hulk);
            PlayerDeckData.PlayerDeck.Add(CardType.Medusa);
            PlayerDeckData.PlayerDeck.Add(CardType.QuickSilver);
            PlayerDeckData.PlayerDeck.Add(CardType.Hulk);
            PlayerDeckData.PlayerDeck.Add(CardType.Hulk);
            PlayerDeckData.PlayerDeck.Add(CardType.Hulk);
            PlayerDeckData.PlayerDeck.Add(CardType.Hulk);
            PlayerDeckData.PlayerDeck.Add(CardType.Hulk);
            PlayerDeckData.PlayerDeck.Add(CardType.Hulk);
            PlayerDeckData.PlayerDeck.Add(CardType.Hulk);
            PlayerDeckData.PlayerDeck.Add(CardType.Hulk);
            PlayerDeckData.PlayerDeck.Add(CardType.Hulk);

            
            //SettingsDataModel = _settingsDataView.Load();
        }
    }
}
