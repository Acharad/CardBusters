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
    }
}
