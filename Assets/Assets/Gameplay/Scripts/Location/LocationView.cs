using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Assets.Gameplay.Scripts.Location
{
    public class LocationView : MonoBehaviour, IOnRevealLocation
    {
        [SerializeField] private Image hideSpriteImage;
        [SerializeField] private Image openedSpriteImage;
        [SerializeField] private TextMeshProUGUI descText;
        [SerializeField] private Animator animator;
        
        public event Action OnLocationRevealed;
        private LocationModel _locationModel;
        private int _turnCount;
        

        public void Init(LocationModel locationModel, int revealCount)
        {
            _locationModel = new LocationModel
            {
                HideSprite = locationModel.HideSprite,
                OpenedSprite = locationModel.OpenedSprite,
                DescText = locationModel.DescText,
                RevealTurnCount = revealCount
            };
            Prepare();
        }

        private void Prepare()
        {
            hideSpriteImage.sprite = _locationModel.HideSprite;
            openedSpriteImage.sprite = _locationModel.OpenedSprite;
            SetDescriptionText(0);
        }

        public void CheckLocationCanReveal(int turnCount)
        {
            if (_locationModel.IsRevealed) return;
            SetDescriptionText(turnCount);
            if(_locationModel.RevealTurnCount <= turnCount)
                OnRevealFunc();
            _turnCount = turnCount;
        }
        
        private void SetDescriptionText(int turnCount)
        {
            descText.text = $"The location revealed in {_locationModel.RevealTurnCount - turnCount}. turn";
        }

        public void OnRevealFunc()
        {
            _locationModel.IsRevealed = true;
            descText.gameObject.SetActive(false);
            if(animator != null)
                animator.SetTrigger("RevealAnimation");
            OnLocationRevealed?.Invoke();
        }

        
    }
}
