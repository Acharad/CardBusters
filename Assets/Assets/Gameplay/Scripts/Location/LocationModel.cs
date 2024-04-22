using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Gameplay.Scripts.Location
{
    public class LocationModel : MonoBehaviour
    {
        [SerializeField] private Image hideImage;
        [SerializeField] private Image openedImage;
        [SerializeField] private TextMeshProUGUI descText;
        [SerializeField] private TextMeshProUGUI revealTurnCount;
        [SerializeField] private Animator animator;


        public bool isRevealed { get; private set; }



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
            revealTurnCount.text = value.ToString();
        }
    }
}
