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
        

        public GameDeckData GameDeckData;


        [Inject]
        private void Construct(GameDeckData gameDeckData)
        {
            //_settingsDataView = settingsDataView;
            GameDeckData = gameDeckData;
            
            GameDeckData.PlayerDeck.Add(CardType.AntMan);
            GameDeckData.PlayerDeck.Add(CardType.Medusa);
            GameDeckData.PlayerDeck.Add(CardType.Angela);
            GameDeckData.PlayerDeck.Add(CardType.Hulk);
            GameDeckData.PlayerDeck.Add(CardType.Hulk);
            GameDeckData.PlayerDeck.Add(CardType.Hulk);
            GameDeckData.PlayerDeck.Add(CardType.Hulk);
            GameDeckData.PlayerDeck.Add(CardType.Hulk);
            GameDeckData.PlayerDeck.Add(CardType.Hulk);
            GameDeckData.PlayerDeck.Add(CardType.Hulk);
            GameDeckData.PlayerDeck.Add(CardType.QuickSilver);
            GameDeckData.PlayerDeck.Add(CardType.Hulk);

            
            //SettingsDataModel = _settingsDataView.Load();
        }
    }
}
