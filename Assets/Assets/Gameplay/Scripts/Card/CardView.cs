using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Gameplay.Scripts.Card
{
    public class CardView : MonoBehaviour
    {
        [SerializeField] private Image cardImage;
        [SerializeField] private Image revealImage;
        [SerializeField] private TextMeshProUGUI cardText;
    }
}
