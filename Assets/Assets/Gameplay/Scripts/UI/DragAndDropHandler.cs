using Assets.Gameplay.Scripts.Card;
using Assets.Gameplay.Scripts.DataSystem.Turn;
using Assets.Gameplay.Scripts.Events;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Assets.Gameplay.Scripts.UI
{
    public class DragAndDropHandler : MonoBehaviour, IPointerDownHandler, IPointerExitHandler, IPointerEnterHandler, IPointerUpHandler, IBeginDragHandler
    {
        private bool _cardCanMove = false;
        private bool _isLocated = false;
        private bool IsCardLocked => cardView.GetData().GetIsCardLocked();

        [SerializeField] private CardView cardView;

        private GameData _gameData;
        private SignalBus _signalBus;
        [Inject]
        public void Construct(GameData gameData, SignalBus signalBus)
        {
            _gameData = gameData;
            _signalBus = signalBus;
            _firstTransformPosition = transform.position;
            
        }

        private Vector3 _firstTransformPosition;
        private void Update()
        {
            if (!_cardCanMove) return;
            var mousePosition = Input.mousePosition;
            mousePosition.z = 10;
            transform.position = mousePosition;
            
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                if (_isLocated && !cardView.GetData().GetIsCardLocked()) return;
                _firstTransformPosition = transform.position;
            
                _cardCanMove = true;
            }
            else if (eventData.button == PointerEventData.InputButton.Right)
            {
                //todo add card can move
                if (!IsCardLocked)
                {
                    _isLocated = false;
                    cardView.GetData().CurrentLocation.TryRemoveCard(cardView);
                    cardView.ResetCardView();
                }
            }
            
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
           
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (_isLocated) return;
            _cardCanMove = false;
            float minDif = 99999f;
            GameLocationData minLocationData = null;
            foreach (var gameLocationData in _gameData.GameLocationDataList)
            {
                var currentDif = Vector2.Distance(gameLocationData.LocationView.transform.position, transform.position);
                Debug.Log("ahmet currentDif  = " + currentDif);
                if (!(currentDif < minDif)) continue;
                minDif = currentDif;
                if(minDif < 350f)
                    minLocationData = gameLocationData;
            }
            if (minLocationData == null || !minLocationData.LocationView.CheckCanLocateCard())
            {
                transform.position = _firstTransformPosition;
                Debug.Log("ahmet transform position" + _firstTransformPosition);
            }
            else
            {
                _isLocated = true;
                _signalBus.Fire(new IGameplayEvents.OnCardAddedToLocation()
                {
                    CardView = cardView,
                    LocationView = minLocationData.LocationView,
                    IsFromPlayer = true,
                });
                minLocationData.LocationView.TryLocateCard(cardView);
            }
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
        }
    }
}
