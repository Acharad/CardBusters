using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Gameplay.Scripts.SceneSystem;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Gameplay.Scripts.UI
{
    public class SettingsGameScreen : MonoBehaviour
    {
        [SerializeField] private Button LeaveButton;

        [SerializeField] private Button ScreenButton;

        [SerializeField] private GameObject leaveScreen;


        private void Start()
        {
            LeaveButton.onClick.AddListener(OnLeaveButtonClicked);
            ScreenButton.onClick.AddListener(OnScreenButtonClicked);
        }

        private void OnDestroy()
        {
            LeaveButton.onClick.RemoveAllListeners();
            ScreenButton.onClick.RemoveAllListeners();
        }

        private void OnLeaveButtonClicked()
        {
            leaveScreen.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }

        private void OnScreenButtonClicked()
        {
            gameObject.SetActive(false);
        }
        
        
        
        
    }
}
