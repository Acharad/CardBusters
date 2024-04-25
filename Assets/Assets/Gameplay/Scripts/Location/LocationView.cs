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

        public void Init(LocationModel locationModel, int revealCount)
        {
            _locationModel = locationModel;
            _locationModel.RevealTurnCount = revealCount;
            Prepare();
        }

        private void Prepare()
        {
            hideSpriteImage.sprite = _locationModel.HideSprite;
            openedSpriteImage.sprite = _locationModel.OpenedSprite;
            SetDescriptionText();
        }
        
        private void SetDescriptionText()
        {
            descText.text = $"The location revealed in {_locationModel.RevealTurnCount}. turn";
        }

        public void OnRevealFunc()
        {
            
            OnLocationRevealed?.Invoke();
        }

        
    }
}
