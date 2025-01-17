using System;
using Assets.Gameplay.Scripts.Location;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Zenject;

namespace Assets.Gameplay.Scripts.Card
{
    public class CardView : MonoBehaviour, IOnRevealCard, IOnGoingCard
    {
        [Inject] private DiContainer _container;
        [SerializeField] private RectTransform RectTransform;
        [SerializeField] private Image cardImage;
        [SerializeField] private TextMeshProUGUI cardText;
        [SerializeField] private TextMeshProUGUI cardMana;
        [SerializeField] private TextMeshProUGUI cardDamage;
        [SerializeField] private TextMeshProUGUI cardInfoText;
        
        
        protected LocationView _locationView;
        
        public event Action OnRevealObjectAdded;
        public event Action OnGoingFunctionAdded;
        
        protected CardModel _cardModel;
        
        protected bool _isFromPlayer = true;


        public CardModel GetData()
        {
            return _cardModel;
        }
        
        public void Init(CardModel cardModel)
        {
            _cardModel = cardModel;
            Prepare();
        }

        protected void Prepare()
        {
            // cardImage.sprite = _cardModel.CardSprite;
            //revealSpriteRenderer.sprite = _cardModel.RevealSprite;
            ShowCardText();
            // firstTransformPosition = gameObject.GetComponent<RectTransform>().anchoredPosition;
            // Debug.Log("ahmet " + firstTransformPosition);

            cardInfoText.text = _cardModel.CardInfo;
        }

        public void ShowCardText()
        {
            cardText.text = _cardModel.CardName;
            cardMana.text = _cardModel.ManaCost.ToString();
            cardDamage.text = _cardModel.Power.ToString();
        }

        public void ResetCardView()
        {
            transform.SetParent(_cardModel.DeckPositionHolder);
        }

        public virtual void OnRevealFunc(LocationView locationView, bool isFromPlayer = true)
        {
            _isFromPlayer = isFromPlayer;
            _locationView = locationView;
            OnRevealObjectAdded?.Invoke();
        }

        public virtual void OnGoingFunction()
        {
            OnGoingFunctionAdded?.Invoke();
        }

        public void RemoveCard()
        {
            gameObject.SetActive(false);
            // Destroy(gameObject);
        }

        public void ResetCardScale()
        {
            RectTransform.sizeDelta = new Vector2(150, 200);
        }
    }
}
