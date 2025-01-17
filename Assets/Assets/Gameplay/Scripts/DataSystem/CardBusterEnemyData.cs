using System;
using Assets.Gameplay.Scripts.Card;
using Assets.Gameplay.Scripts.DataSystem.Models;
using Assets.Gameplay.Scripts.DataSystem.Views;
using Zenject;

namespace Assets.Gameplay.Scripts.DataSystem
{
    public class CardBusterEnemyData : PlayerData
    {
        [NonSerialized] public SettingsDataModel SettingsDataModel;
        private SettingsDataView _settingsDataView;
        

        public GameDeckData GameDeckData;


        [Inject]
        private void Construct(GameDeckData gameDeckData)
        {
            //_settingsDataView = settingsDataView;
            GameDeckData = gameDeckData;
            
            GameDeckData.EnemyDeck.Add(CardType.AntMan);
            GameDeckData.EnemyDeck.Add(CardType.Medusa);
            GameDeckData.EnemyDeck.Add(CardType.Angela);
            GameDeckData.EnemyDeck.Add(CardType.Abomination);
            GameDeckData.EnemyDeck.Add(CardType.AgentVenom);
            GameDeckData.EnemyDeck.Add(CardType.AmericaChavez);
            GameDeckData.EnemyDeck.Add(CardType.Bishop);
            GameDeckData.EnemyDeck.Add(CardType.BlackPanther);
            GameDeckData.EnemyDeck.Add(CardType.ColleenWing);
            GameDeckData.EnemyDeck.Add(CardType.Hulk);
            GameDeckData.EnemyDeck.Add(CardType.QuickSilver);
            GameDeckData.EnemyDeck.Add(CardType.Crystal);

            
            //SettingsDataModel = _settingsDataView.Load();
        }
    }
}
