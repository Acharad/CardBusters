using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Gameplay.Scripts.Card
{
    public class CardView : MonoBehaviour, IOnRevealCard, IOnGoingCard
    {
        [SerializeField] private SpriteRenderer cardSpriteRenderer;
        [SerializeField] private SpriteRenderer revealSpriteRenderer;
        [SerializeField] private TextMeshProUGUI cardText;
        
        public event Action OnRevealObjectAdded;
        public event Action OnGoingFunctionAdded;
        
        private CardModel _cardModel;
        
        public CardView(CardModel cardModel)
        {
            _cardModel = cardModel;
        }

        public void Prepare()
        {
            cardSpriteRenderer.sprite = _cardModel.CardSprite;
            revealSpriteRenderer.sprite = _cardModel.RevealSprite;
            cardText.text = _cardModel.CardText;
        }

        public virtual void OnRevealFunc()
        {
            OnRevealObjectAdded?.Invoke();
        }

        public virtual void OnGoingFunction()
        {
            OnGoingFunctionAdded?.Invoke();
        }
        
        // public void 

        public void RemoveCard()
        {
            Destroy(gameObject);
        }
    }
}
