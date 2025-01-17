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

        public CardView CreateCard(CardType cardType, Transform playerParent, Transform enemyParent, bool isForPlayer)
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
            
            cardView = CreateCard(playerParent, cardType, enemyParent, isForPlayer);
            
            if (cardView != null)
                cardView.GetComponent<RectTransform>().localPosition = Vector3.one;
            
            return cardView;
        }

        private CardView CreateCard(Transform playerParent, CardType cardType, Transform enemyParent, bool isForPlayer)
        {
            if (!_cardDataSo.gameCardViewDictionary.TryGetValue(cardType, out var cardData))
            {
                Debug.LogError("Card is NULL");
                return null;
            }
            var newCardModel = cardData.cardModel.Clone();

            CardView cardView;
            
            if (isForPlayer)
            {
                cardView = _instantiator.InstantiatePrefab(cardData.cardView, Vector3.zero, Quaternion.identity, playerParent)
                    .GetComponent<CardView>();
                newCardModel.DeckPositionHolder = playerParent;
            }
            else
            {
                cardView = _instantiator.InstantiatePrefab(cardData.cardView, Vector3.zero, Quaternion.identity, enemyParent)
                    .GetComponent<CardView>();
                newCardModel.DeckPositionHolder = enemyParent;
            }
            
            newCardModel.CardCount = cardCount;
            cardView.Init(newCardModel);
            return cardView;
        }
        
        
    }
}
