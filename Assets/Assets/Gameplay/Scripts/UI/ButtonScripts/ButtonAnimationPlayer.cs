using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
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
        [SerializeField] private float startScaleSize;
        [SerializeField] private float animationDuration;
        [SerializeField] private Ease ease;
        [SerializeField] private Transform buttonBackground;
        private TweenerCore<Vector3, Vector3, VectorOptions> _buttonTween;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }
        
        public void OnPointerDown(PointerEventData eventData)
        {
            if (!CheckCanAnimate()) return;
            CheckAndStopTweenIfPlaying();
            _buttonTween = buttonBackground.DOScale(scaleSize, animationDuration).SetEase(ease);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (!CheckCanAnimate()) return;
            CheckAndStopTweenIfPlaying();
            _buttonTween = buttonBackground.DOScale(startScaleSize, animationDuration).SetEase(ease);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (!CheckCanAnimate()) return;
            CheckAndStopTweenIfPlaying();
            _buttonTween= buttonBackground.DOScale(1f, animationDuration).SetEase(ease);
        }

        private bool CheckCanAnimate()
        {
            return _button.interactable;
        }

        private void CheckAndStopTweenIfPlaying()
        {
            _buttonTween?.Kill();
        }
    }
}
