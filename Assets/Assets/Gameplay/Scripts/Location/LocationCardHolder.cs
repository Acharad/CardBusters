using Assets.Gameplay.Scripts.Card;
using UnityEngine;

namespace Assets.Gameplay.Scripts.Location
{
    public class LocationCardHolder : MonoBehaviour
    {
        private int _maxCardCount;
        private int _currentCardCount = 0;


        public void Init(int maxCardCount)
        {
            _maxCardCount = maxCardCount;
        }
        
        public void LocateCardToThisLocation(CardView cardView)
        {
            if (_currentCardCount < _maxCardCount)
            {
                _currentCardCount++;
                cardView.gameObject.transform.SetParent(transform);
               
            }
        }

        public void RemoveCardToThisLocation(CardView cardView)
        {
            _currentCardCount--;
            cardView.gameObject.transform.SetParent(null);
        }

        public bool CanLocateCard()
        {
            return _currentCardCount < _maxCardCount;
        }
    }
}
