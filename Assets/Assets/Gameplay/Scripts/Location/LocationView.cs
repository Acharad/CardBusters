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

        [SerializeField] private TextMeshProUGUI descTextAfterReveal;
        [SerializeField] private TextMeshProUGUI descText;
        [SerializeField] private TextMeshProUGUI enemyPower;
        [SerializeField] private TextMeshProUGUI playerPower;
        [SerializeField] private TextMeshProUGUI locationName;
        
        [SerializeField] private Animator EnemyAnimator;
        [SerializeField] private Animator PlayerAnimator;

        [SerializeField] private bool _isPlayerWinning = false;
        [SerializeField] private bool _isEnemyWinning = false;
        
        
        public event Action OnLocationRevealed;
        public event Action OnCardAddedToThisLocation;
        public event Action OnCardAddedAfterTurnEnd;
        protected LocationModel _locationModel;
        private int _turnCount;
        protected bool _isLocationRevealed;


        public LinkedList<CardView> PlayedCards = new ();
        
        public LinkedList<CardView> EnemyCards = new ();
        
        public LinkedList<CardView> PlayedCardsThisTurn = new ();
        
        public LinkedList<CardView> PlayedCardsThisTurnEnemy = new ();
        
        [Inject] private CurrentTurnData _turnData;
        [Inject] protected SignalBus _signalBus;
        

        public void Init(LocationModel locationModel, int revealCount)
        {
            _locationModel = new LocationModel
            {
                HideSprite = locationModel.HideSprite,
                OpenedSprite = locationModel.OpenedSprite,
                DescText = locationModel.DescText,
                DescTextAfterReveal = locationModel.DescTextAfterReveal,
                RevealTurnCount = revealCount,
                LocationName = locationModel.LocationName,
                LocationMaxCardCount = locationModel.LocationMaxCardCount
            };

            descTextAfterReveal.text = _locationModel.DescTextAfterReveal;
            
            enemyCardHolder.Init(_locationModel.LocationMaxCardCount);
            playerCardHolder.Init(_locationModel.LocationMaxCardCount);

            Prepare();
            
            _signalBus.Subscribe<IGameplayEvents.OnTurnEnd>(TurnEndAction);
        }

        protected virtual void TurnEndAction()
        {
            
        }

        public LocationModel GetModel()
        {
            return _locationModel;
        }
        private void Prepare()
        {
            hideSpriteImage.sprite = _locationModel.HideSprite;
            // openedSpriteImage.sprite = _locationModel.OpenedSprite;
            locationName.text = _locationModel.LocationName;
            locationName.gameObject.SetActive(false);
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
                enemyPower.text = (_locationModel.EnemyPower + _locationModel.PreviewEnemyPower).ToString();
                enemyCardHolder.LocateCardToThisLocation(cardView);
                cardView.GetData().CurrentLocation = this;
                OnCardAddedToThisLocation?.Invoke();
                // ActivateOnRevealFunc(cardView);
                
                PlayedCardsThisTurnEnemy.AddLast(cardView);
                //PlayedCards.AddLast(cardView);
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
                SetLocationValues();
            }
            else if (enemyCardHolder.CanLocateCard())
            {
                _locationModel.EnemyPower += cardView.GetData().Power;
                SetLocationValues();
            }
        }

        private void ResetLocationValues()
        {
            _locationModel.PreviewPlayerPower = 0;
            playerPower.text = _locationModel.PlayerPower.ToString();
            
            _locationModel.PreviewEnemyPower = 0;
            enemyPower.text = _locationModel.EnemyPower.ToString();
        }

        protected void SetLocationValues()
        {
            playerPower.text = _locationModel.PlayerPower.ToString();
            enemyPower.text = _locationModel.EnemyPower.ToString();
        }

        public void TryRemoveCard(CardView cardView, bool isFromPlayer = true)
        {
            PlayedCardsThisTurn.Remove(cardView);
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
            _isLocationRevealed = true;
            TurnEndAction();
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
            
            var headEnemy = PlayedCardsThisTurnEnemy.First;
            while (headEnemy != null)
            {
                OnCardAddedAfterTurnEnd?.Invoke();
                headEnemy.Value.OnRevealFunc(this);
                CalculateLocationValues(headEnemy.Value, false);
                
                headEnemy = headEnemy.Next;
            }
            
            if (_locationModel.PlayerPower > _locationModel.EnemyPower)
            {
                if(!_isPlayerWinning)
                    PlayerAnimator.SetTrigger("OnMostPower");
                if (_isEnemyWinning)
                {
                    EnemyAnimator.SetTrigger("OnLoseMostPower");
                    _isEnemyWinning = false;
                }
                _isPlayerWinning = true;
            }
            else if (_locationModel.EnemyPower > _locationModel.PlayerPower)
            {
                if(!_isEnemyWinning)
                    EnemyAnimator.SetTrigger("OnMostPower");
                if (_isPlayerWinning)
                {
                    PlayerAnimator.SetTrigger("OnLoseMostPower");
                    _isPlayerWinning = false;
                }
                _isEnemyWinning = true;
            }
            else
            {
                if (_isPlayerWinning)
                {
                    PlayerAnimator.SetTrigger("OnLoseMostPower");
                    _isPlayerWinning = false;
                }

                if (_isEnemyWinning)
                {
                    EnemyAnimator.SetTrigger("OnLoseMostPower");
                    _isEnemyWinning = false;
                }
            }
            
            PlayedCardsThisTurnEnemy?.First?.List.Clear();
        }

        public LocationWinTypes GetIfPlayerWinning()
        {
            if (_locationModel.PlayerPower > _locationModel.EnemyPower)
            {
                return LocationWinTypes.Win;
            }
            if (_locationModel.EnemyPower > _locationModel.PlayerPower)
            {
                return LocationWinTypes.Lose;
            }
            if (_locationModel.PlayerPower == _locationModel.EnemyPower)
            {
                return LocationWinTypes.Draw;
            }

            return LocationWinTypes.Win;
        }

        public int GetPlayerPowerDif()
        {
            return _locationModel.PlayerPower - _locationModel.EnemyPower;
        }
    }
}
