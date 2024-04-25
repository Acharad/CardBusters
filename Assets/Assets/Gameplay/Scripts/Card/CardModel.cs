using TMPro;
using UnityEngine;

namespace Assets.Gameplay.Scripts.Card
{
    public class CardModel
    {
        public Sprite CardSprite { get; set; }
        public Sprite RevealSprite { get; set; }
        public string CardText { get; set; }
        
        public int ManaCost { get; set; }
        public int Power { get; set; }
    }
}
