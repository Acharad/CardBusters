using Assets.Gameplay.Scripts.Location;
using TMPro;
using UnityEngine;

namespace Assets.Gameplay.Scripts.Card
{
    [System.Serializable]
    public class CardModel
    {
        [field:SerializeField] public Sprite CardSprite { get; set; }
        [field:SerializeField] public Sprite RevealSprite { get; set; }
        [field:SerializeField] public string CardName { get; set; }
        
        [field:SerializeField] public int ManaCost { get; set; }
        [field:SerializeField] public int Power { get; set; }

        [field:SerializeField] public LocationView CurrentLocation { get; set; }
        
        [field:SerializeField] public Transform DeckPositionHolder { get; set; }
        
        [field:SerializeField] public int CardCount { get; set; }
        [field:SerializeField] public string CardInfo { get; set; }

        private bool _isCardLocked;

        public bool GetIsCardLocked()
        {
            return _isCardLocked;
        }

        public void SetIsCardLocked(bool isLocked)
        {
            _isCardLocked = isLocked;
        }
        
        
        public CardModel Clone()
        {
            return new CardModel
            {
                CardSprite = this.CardSprite, 
                RevealSprite = this.RevealSprite, 
                CardName = this.CardName,
                ManaCost = this.ManaCost,
                Power = this.Power,
                CurrentLocation = this.CurrentLocation, 
                DeckPositionHolder = this.DeckPositionHolder, 
                CardCount = this.CardCount,
                CardInfo = this.CardInfo,
                _isCardLocked = this._isCardLocked 
            };
        }

    }
}
