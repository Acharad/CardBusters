using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Gameplay.Scripts.Location
{
    public class LocationView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer hideSpriteRenderer;
        [SerializeField] private SpriteRenderer openedSpriteRenderer;
        [SerializeField] private TextMeshProUGUI descText;
        [SerializeField] private int revealTurnCount;
        [SerializeField] private Animator animator;
        
        public bool isRevealed { get; private set; }

        public void PrePareLocation(Sprite openedSprite)
        {
            openedSpriteRenderer.sprite = openedSprite;
        }
        
        public void StartRevealAnimation()
        {
            if (animator != null)
            {
                animator.SetTrigger("RevealAnimation");
            }

            isRevealed = true;
        }
        
        public void ChangeRevealTurnCont(int value)
        {
            revealTurnCount = value;
            SetDescriptionText();
        }

        private void SetDescriptionText()
        {
            descText.text = $"The location revealed in {revealTurnCount}. turn";
        }
        
    }
}
