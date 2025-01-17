using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Gameplay.Scripts.UI
{
    public class SettingsButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private GameObject settingsScreen;

        private void Start()
        {
            _button.onClick.AddListener(OnSettingsButtonClicked);
        }

        private void OnSettingsButtonClicked()
        {
            settingsScreen.SetActive(true);
        }
    }
}
