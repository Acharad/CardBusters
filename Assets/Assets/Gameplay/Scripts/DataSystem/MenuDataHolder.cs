using System;
using Zenject;

namespace Assets.Gameplay.Scripts.DataSystem
{
    public class MenuDataHolder
    {
        private SignalBus _signalBus;

        [Inject]
        public MenuDataHolder(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }
    }
}
