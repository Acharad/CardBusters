using Unity.VisualScripting;
using UnityEngine;
using Zenject;
namespace Assets.Gameplay.Scripts.Card
{
    public class CardFactory : MonoBehaviour
    {
        private CardDataSo _cardDataSo;
        private IInstantiator _instantiator;
        private int cardCount = 0;
        
        [Inject]
        public void Construct(CardDataSo locationDataSo, IInstantiator instantiator)
        {
            _cardDataSo = locationDataSo;
            _instantiator = instantiator;
        }

        public CardView CreateCard(CardType cardType, Transform parent)
        {
            if (cardType == CardType.None)
            {
                Debug.LogError("Card type can not be none.");
            }

            if (cardType == CardType.Random)
            {
                
            }
            cardCount++;
            CardView cardView = null;
            //todo switch case kalkabilir.
            switch (cardType)
            {
                case CardType.Hulk:
                    cardView = CreateHulkCard(parent);
                    break;
                case CardType.Medusa:
                    cardView = CreateMedusaCard(parent);
                    break;
                case CardType.QuickSilver:
                    cardView = CreateQuickSilverCard(parent);
                    break;
                case CardType.StarLord:
                    cardView = CreateStarLordCard(parent);
                    break;
                case CardType.Angela:
                    cardView = CreateAngelaCard(parent);
                    break;
                case CardType.AntMan:
                    cardView = CreateAntManCard(parent);
                    break;
                default:
                    Debug.LogError("Card doesnt exists");
                    break;
            }
            
            if (cardView != null)
                cardView.GetComponent<RectTransform>().localPosition = Vector3.one;
            
            return cardView;
        }
        
        private CardView CreateHulkCard(Transform parent)
        {
            if (!_cardDataSo.gameCardViewDictionary.TryGetValue(CardType.Hulk, out var cardData))
            {
                Debug.LogError("Card is NULL");
                return null;
            }

            var newCardModel = cardData.cardModel.Clone();

            var cardView = _instantiator.InstantiatePrefab(cardData.cardView, Vector3.zero, Quaternion.identity, parent)
                .GetComponent<CardView>();
            newCardModel.DeckPositionHolder = parent;
            newCardModel.CardCount = cardCount;
            cardView.Init(newCardModel);
            return cardView;
        }
        
        private CardView CreateMedusaCard(Transform parent)
        {
            if (!_cardDataSo.gameCardViewDictionary.TryGetValue(CardType.Medusa, out var cardData))
            {
                Debug.LogError("Card is NULL");
                return null;
            }
            
            var newCardModel = cardData.cardModel.Clone();

            var cardView = _instantiator.InstantiatePrefab(cardData.cardView, Vector3.zero, Quaternion.identity, parent)
                .GetComponent<CardView>();
            newCardModel.DeckPositionHolder = parent;
            newCardModel.CardCount = cardCount;
            cardView.Init(newCardModel);
            return cardView;
        }
        
        private CardView CreateQuickSilverCard(Transform parent)
        {
            if (!_cardDataSo.gameCardViewDictionary.TryGetValue(CardType.QuickSilver, out var cardData))
            {
                Debug.LogError("Card is NULL");
                return null;
            }
            
            var newCardModel = cardData.cardModel.Clone();

            var cardView = _instantiator.InstantiatePrefab(cardData.cardView, Vector3.zero, Quaternion.identity, parent)
                .GetComponent<CardView>();
            newCardModel.DeckPositionHolder = parent;
            newCardModel.CardCount = cardCount;
            cardView.Init(newCardModel);
            return cardView;
        }
        
        private CardView CreateStarLordCard(Transform parent)
        {
            if (!_cardDataSo.gameCardViewDictionary.TryGetValue(CardType.StarLord, out var cardData))
            {
                Debug.LogError("Card is NULL");
                return null;
            }
            
            var newCardModel = cardData.cardModel.Clone();

            var cardView = _instantiator.InstantiatePrefab(cardData.cardView, Vector3.zero, Quaternion.identity, parent)
                .GetComponent<CardView>();
            newCardModel.DeckPositionHolder = parent;
            newCardModel.CardCount = cardCount;
            cardView.Init(newCardModel);
            return cardView;
        }
        
        private CardView CreateAngelaCard(Transform parent)
        {
            if (!_cardDataSo.gameCardViewDictionary.TryGetValue(CardType.Angela, out var cardData))
            {
                Debug.LogError("Card is NULL");
                return null;
            }
            
            var newCardModel = cardData.cardModel.Clone();

            var cardView = _instantiator.InstantiatePrefab(cardData.cardView, Vector3.zero, Quaternion.identity, parent)
                .GetComponent<CardView>();
            newCardModel.DeckPositionHolder = parent;
            newCardModel.CardCount = cardCount;
            cardView.Init(newCardModel);
            return cardView;
        }
        
        private CardView CreateAntManCard(Transform parent)
        {
            if (!_cardDataSo.gameCardViewDictionary.TryGetValue(CardType.AntMan, out var cardData))
            {
                Debug.LogError("Card is NULL");
                return null;
            }
            
            var newCardModel = cardData.cardModel.Clone();

            var cardView = _instantiator.InstantiatePrefab(cardData.cardView, Vector3.zero, Quaternion.identity, parent)
                .GetComponent<CardView>();
            newCardModel.DeckPositionHolder = parent;
            newCardModel.CardCount = cardCount;
            cardView.Init(newCardModel);
            return cardView;
        }
    }
}
