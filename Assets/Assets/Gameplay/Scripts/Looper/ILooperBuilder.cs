using System.Collections.Generic;

namespace Assets.Gameplay.Scripts.Looper
{
    public interface ILooperBuilder
    {
        void BuildGameEndLooper(ref List<ITick> loopList);
        
        void BuildFirstTimeActions(ref List<ITick> loopList);
    }
}
