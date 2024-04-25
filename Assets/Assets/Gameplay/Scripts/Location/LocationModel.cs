using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Gameplay.Scripts.Location
{
    [System.Serializable]
    public class LocationModel
    {
        [field:SerializeField] public Sprite HideSprite {get; set;}
        [field:SerializeField] public Sprite OpenedSprite {get; set;}
        [field:SerializeField] public string DescText {get; set;}
        [field:SerializeField] public int RevealTurnCount {get; set;}
        [field:SerializeField] public Animator Animator {get; set;} // ????
        [field:SerializeField] public bool IsRevealed { get;  set; }
    }
}
