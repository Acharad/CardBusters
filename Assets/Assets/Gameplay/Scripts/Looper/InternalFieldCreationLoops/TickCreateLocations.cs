using System.Collections;
using Assets.Gameplay.Scripts.DataSystem.Turn;
using Assets.Gameplay.Scripts.Location;
using Zenject;

namespace Assets.Gameplay.Scripts.Looper.InternalFieldCreationLoops
{
    public class TickCreateLocations : TickBase
    {
        private LocationFactory _locationFactory;
        private LocationPositionHolder _locationPositionHolder;
        private GameData _gameData;

        [Inject]
        private void Construct(LocationFactory locationFactory, LocationPositionHolder locationPositionHolder, GameData gameData)
        {
            _locationFactory = locationFactory;
            _locationPositionHolder = locationPositionHolder;
            _gameData = gameData;
        }
        
        public override IEnumerator Tick()
        {
            for (var i = 0; i < _locationPositionHolder.locationTransforms.Count; i++)
            {
                var locationView = _locationFactory.CreateLocation(LocationType.Random, 
                    _locationPositionHolder.locationTransforms[i],
                    i + 1);
                
                _gameData.GameLocations.Add(locationView);
            }
            
            yield break;
        }
    }
}
