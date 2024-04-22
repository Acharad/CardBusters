using UnityEngine;
using UnityEngine.UI;

namespace Assets.Gameplay.Scripts.UI.ButtonScripts
{
    [RequireComponent(typeof(Button))]
    public abstract class AbstractButton : MonoBehaviour
    {
        private Button _button;

        protected Button Button => _button ??= GetComponent<Button>();
        
        protected virtual void Awake()
        {
            Button.onClick.AddListener(OnClickListener);
            // todo button sound
            // Button.onClick.AddListener(()=>_audioManager.PlayOneShot(_gameAudio.UISounds.buttonSound));
        }
        
        protected abstract void OnClickListener();

        public virtual void TryActivateButton()
        {
            Button.interactable = true;
        }
        public virtual void TryDeActivateButton()
        {
            Button.interactable = false;
        }

        public bool GetInteractable()
        {
            return Button.interactable;
        }
    }
}
