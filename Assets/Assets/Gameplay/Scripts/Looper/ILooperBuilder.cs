using System.Collections.Generic;

namespace Assets.Gameplay.Scripts.Looper
{
    public interface ILooperBuilder
    {
        void BuildLooper(ref List<ITick> loopList);
        
        void BuildFirstTimeActions(ref List<ITick> loopList);
    }
}
