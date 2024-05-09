using UnityEngine;
using Zenject;

namespace Assets.Gameplay.Scripts.Card
{
    public class CardFactory : MonoBehaviour
    {
        private CardDataSo _cardDataSo;
        
        [Inject]
        public void Construct(CardDataSo locationDataSo)
        {
            _cardDataSo = locationDataSo;
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

            CardView cardView = null;
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
            var cardView = Instantiate(cardData.cardView, Vector3.zero, Quaternion.identity, parent);
            cardView.Init(cardData.cardModel);
            return cardView;
        }
        
        private CardView CreateMedusaCard(Transform parent)
        {
            if (!_cardDataSo.gameCardViewDictionary.TryGetValue(CardType.Medusa, out var cardData))
            {
                Debug.LogError("Card is NULL");
                return null;
            }
            var cardView = Instantiate(cardData.cardView, Vector3.zero, Quaternion.identity, parent);
            cardView.Init(cardData.cardModel);
            return cardView;
        }
        
        private CardView CreateQuickSilverCard(Transform parent)
        {
            if (!_cardDataSo.gameCardViewDictionary.TryGetValue(CardType.QuickSilver, out var cardData))
            {
                Debug.LogError("Card is NULL");
                return null;
            }
            var cardView = Instantiate(cardData.cardView, Vector3.zero, Quaternion.identity, parent);
            cardView.Init(cardData.cardModel);
            return cardView;
        }
        
        private CardView CreateStarLordCard(Transform parent)
        {
            if (!_cardDataSo.gameCardViewDictionary.TryGetValue(CardType.StarLord, out var cardData))
            {
                Debug.LogError("Card is NULL");
                return null;
            }
            var cardView = Instantiate(cardData.cardView, Vector3.zero, Quaternion.identity, parent);
            cardView.Init(cardData.cardModel);
            return cardView;
        }
    }
}
