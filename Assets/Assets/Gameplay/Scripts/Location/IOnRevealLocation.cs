using System;

namespace Assets.Gameplay.Scripts.Location
{
    public interface IOnRevealLocation 
    {
        void OnRevealFunc();
        event Action OnLocationRevealed;
    }
}
