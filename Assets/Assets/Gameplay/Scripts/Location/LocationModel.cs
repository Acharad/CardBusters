using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Gameplay.Scripts.Location
{
    [System.Serializable]
    public class LocationModel
    {
        [field:SerializeField] public Sprite HideSprite {get; set; }
        [field:SerializeField] public Sprite OpenedSprite {get; set; }
        [field:SerializeField] public string DescText {get; set; }
        [field:SerializeField] public string LocationName { get; set; }
        [field:SerializeField] public int LocationMaxCardCount { get; set; } 
        public int RevealTurnCount {get; set; }
        // public Animator Animator {get; set; } // ????
        public bool IsRevealed { get;  set; }
        public int EnemyPower { get; set; }
        public int PreviewEnemyPower { get; set; }
        public int PlayerPower { get; set; }
        public int PreviewPlayerPower { get; set; }
        
    }
}
