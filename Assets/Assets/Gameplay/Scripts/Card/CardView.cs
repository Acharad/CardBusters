using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Gameplay.Scripts.Card
{
    public class CardView : MonoBehaviour, IOnRevealCard, IOnGoingCard
    {
        [SerializeField] private Image cardImage;
        [SerializeField] private TextMeshProUGUI cardText;
        [SerializeField] private TextMeshProUGUI cardMana;
        [SerializeField] private TextMeshProUGUI cardDamage;
        
        public event Action OnRevealObjectAdded;
        public event Action OnGoingFunctionAdded;
        
        private CardModel _cardModel;
        
        public void Init(CardModel cardModel)
        {
            _cardModel = cardModel;
            Prepare();
        }

        private void Prepare()
        {
            cardImage.sprite = _cardModel.CardSprite;
            //revealSpriteRenderer.sprite = _cardModel.RevealSprite;
            cardText.text = _cardModel.CardName;
            cardMana.text = _cardModel.ManaCost.ToString();
            cardDamage.text = _cardModel.Power.ToString();
        }

        public virtual void OnRevealFunc()
        {
            OnRevealObjectAdded?.Invoke();
        }

        public virtual void OnGoingFunction()
        {
            OnGoingFunctionAdded?.Invoke();
        }

        public void RemoveCard()
        {
            Destroy(gameObject);
        }
    }
}
