using System;
using Assets.Gameplay.Scripts.DataSystem.Models;
using Assets.Gameplay.Scripts.Events;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Gameplay.Scripts.GamePlay
{
    public class PlayerUIInfoHolder : MonoBehaviour
    {
        [SerializeField] public TextMeshProUGUI manaText;
        [SerializeField] public Button turnEndButton;

        private SignalBus _signalBus;
        [Inject]
        private void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
            _signalBus.Subscribe<IGameplayEvents.OnPlayerManaChanged>(SetMana);
        }
        

        private void OnDisable()
        {
            _signalBus.Unsubscribe<IGameplayEvents.OnPlayerManaChanged>(SetMana);
        }

        private void SetMana(IGameplayEvents.OnPlayerManaChanged obj)
        {
            manaText.text = obj.Value.ToString();
        }
    }
}
