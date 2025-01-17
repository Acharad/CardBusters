using UnityEngine;

namespace Assets.Gameplay.Scripts.UI.ButtonScripts
{
    public class QuitGameButton : AbstractButton
    {
        protected override void OnClickListener()
        {
            Application.Quit();
        }
    }
}
