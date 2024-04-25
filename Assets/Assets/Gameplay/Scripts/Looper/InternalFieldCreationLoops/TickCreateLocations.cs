using System.Collections;
using Assets.Gameplay.Scripts.Location;
using Zenject;

namespace Assets.Gameplay.Scripts.Looper.InternalFieldCreationLoops
{
    public class TickCreateLocations : TickBase
    {
        [Inject] private LocationFactory _locationFactory;
        [Inject] private LocationPositionHolder _locationPositionHolder;
        public override IEnumerator Tick()
        {
            for (var i = 0; i < _locationPositionHolder.locationTransforms.Count; i++)
            {
                _locationFactory.CreateLocation(LocationType.Random, 
                    _locationPositionHolder.locationTransforms[i],
                    i + 1);
            }
            
            yield break;
        }
    }
}
