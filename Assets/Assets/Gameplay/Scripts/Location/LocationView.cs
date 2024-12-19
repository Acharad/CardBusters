using System;
using System.Collections.Generic;
using Assets.Gameplay.Scripts.Card;
using Assets.Gameplay.Scripts.DataSystem.Turn;
using Assets.Gameplay.Scripts.Events;
using TMPro;
using UnityEngine;

using UnityEngine.UI;
using Zenject;

namespace Assets.Gameplay.Scripts.Location
{
    public class LocationView : MonoBehaviour, IOnRevealLocation
    {
        [SerializeField] private Image hideSpriteImage;
        [SerializeField] private Image openedSpriteImage;
        [SerializeField] private Animator animator;

        [SerializeField] public LocationCardHolder enemyCardHolder; 
        [SerializeField] public LocationCardHolder playerCardHolder; 
        
        [SerializeField] private TextMeshProUGUI descText;
        [SerializeField] private TextMeshProUGUI enemyPower;
        [SerializeField] private TextMeshProUGUI playerPower;
        [SerializeField] private TextMeshProUGUI locationName;
        
        public event Action OnLocationRevealed;
        public event Action OnCardAddedToThisLocation;
        public event Action OnCardAddedAfterTurnEnd;
        private LocationModel _locationModel;
        private int _turnCount;

        private SignalBus _signalBus;

        public LinkedList<CardView> PlayedCards = new ();
        
        public LinkedList<CardView> PlayedCardsThisTurn = new ();
        
        [Inject] private CurrentTurnData _turnData;
        

        public void Init(LocationModel locationModel, int revealCount)
        {
            _locationModel = new LocationModel
            {
                HideSprite = locationModel.HideSprite,
                OpenedSprite = locationModel.OpenedSprite,
                DescText = locationModel.DescText,
                RevealTurnCount = revealCount,
                LocationName = locationModel.LocationName,
                LocationMaxCardCount = locationModel.LocationMaxCardCount
            };
            
            enemyCardHolder.Init(_locationModel.LocationMaxCardCount);
            playerCardHolder.Init(_locationModel.LocationMaxCardCount);

            Prepare();
        }

        public LocationModel GetModel()
        {
            return _locationModel;
        }
        private void Prepare()
        {
            hideSpriteImage.sprite = _locationModel.HideSprite;
            openedSpriteImage.sprite = _locationModel.OpenedSprite;
            locationName.text = _locationModel.LocationName;
            enemyPower.text = "0";
            playerPower.text = "0";
            SetDescriptionText(0);
        }

        public bool CheckCanLocateCard(bool isFromPlayer = true)
        {
            return isFromPlayer ? playerCardHolder.CanLocateCard() : enemyCardHolder.CanLocateCard();
        }


        public void TryLocateCard(CardView cardView, bool isFromPlayer = true)
        {
            if (isFromPlayer && playerCardHolder.CanLocateCard())
            {
                _locationModel.PreviewPlayerPower += cardView.GetData().Power;
                playerPower.text = (_locationModel.PlayerPower + _locationModel.PreviewPlayerPower).ToString();
                playerCardHolder.LocateCardToThisLocation(cardView);
                cardView.GetData().CurrentLocation = this;
                _turnData.PlayedCardsLinkedList.AddLast(cardView);
                OnCardAddedToThisLocation?.Invoke();
                // ActivateOnRevealFunc(cardView);
                
                PlayedCardsThisTurn.AddLast(cardView);
                PlayedCards.AddLast(cardView);
            }
            else if (enemyCardHolder.CanLocateCard())
            {
                _locationModel.PreviewEnemyPower += cardView.GetData().Power;
                playerPower.text = (_locationModel.EnemyPower + _locationModel.PreviewEnemyPower).ToString();
                enemyCardHolder.LocateCardToThisLocation(cardView);
                cardView.GetData().CurrentLocation = this;
                _turnData.PlayedCardsLinkedList.AddLast(cardView);
                OnCardAddedToThisLocation?.Invoke();
                // ActivateOnRevealFunc(cardView);
                
                PlayedCardsThisTurn.AddLast(cardView);
                PlayedCards.AddLast(cardView);
            }
            else
            {
                Debug.Log("Location View | Card could not locate");
            }
        }


        private void CalculateLocationValues(CardView cardView, bool isFromPlayer = true)
        {
            if (isFromPlayer && playerCardHolder.CanLocateCard())
            {
                _locationModel.PlayerPower += cardView.GetData().Power;
                playerPower.text = _locationModel.PlayerPower.ToString();
            }
            else if (enemyCardHolder.CanLocateCard())
            {
                _locationModel.EnemyPower += cardView.GetData().Power;
                enemyPower.text = _locationModel.PlayerPower.ToString();
            }
        }

        private void ResetLocationValues()
        {
            _locationModel.PreviewPlayerPower = 0;
            playerPower.text = _locationModel.PlayerPower.ToString();
            
            _locationModel.PreviewEnemyPower = 0;
            enemyPower.text = _locationModel.EnemyPower.ToString();
        }

        public void TryRemoveCard(CardView cardView, bool isFromPlayer = true)
        {
            _locationModel.PlayerPower -= cardView.GetData().Power;
            playerPower.text = _locationModel.PlayerPower.ToString();
            playerCardHolder.RemoveCardToThisLocation(cardView);
            _turnData.PlayedCardsLinkedList.Remove(cardView);
        }

        public void CheckLocationCanReveal(int turnCount)
        {
            if (_locationModel.IsRevealed) return;
            SetDescriptionText(turnCount);
            if(_locationModel.RevealTurnCount <= turnCount)
                OnRevealFunc();
            _turnCount = turnCount;
        }
        
        private void SetDescriptionText(int turnCount)
        {
            descText.text = $"The location revealed in {_locationModel.RevealTurnCount - turnCount}. turn";
        }

        public void OnRevealFunc()
        {
            _locationModel.IsRevealed = true;
            descText.gameObject.SetActive(false);
            if(animator != null)
                animator.SetTrigger("RevealAnimation");
            OnLocationRevealed?.Invoke();
        }

        public void ActivateOnRevealFunc()
        {
            //todo maybe
            var head = PlayedCardsThisTurn.First;
            ResetLocationValues();
            while (head != null)
            {
                OnCardAddedAfterTurnEnd?.Invoke();
                head.Value.OnRevealFunc(this);
                CalculateLocationValues(head.Value);
                head = head.Next;
            }
            PlayedCardsThisTurn?.First?.List.Clear();
        }
    }
}
