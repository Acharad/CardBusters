using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Gameplay.Scripts.UI.ButtonScripts
{
    [RequireComponent(typeof(Button))]
    public class ButtonAnimationPlayer : MonoBehaviour, IPointerDownHandler, IPointerExitHandler, IPointerEnterHandler
    {
        private Button _button;
        [SerializeField] private float scaleSize;
        [SerializeField] private float animationDuration;
        // [SerializeField] private ease ease;
        [SerializeField] private Transform buttonBackground;
        
        
        
        public void OnPointerDown(PointerEventData eventData)
        {
            throw new System.NotImplementedException();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            throw new System.NotImplementedException();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            throw new System.NotImplementedException();
        }
    }
}
