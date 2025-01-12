using System.Collections;
using System.Collections.Generic;
using Assets.Gameplay.Scripts.DataSystem.Turn;
using Assets.Gameplay.Scripts.Location;
using Zenject;

namespace Assets.Gameplay.Scripts.Looper.InternalGameEndLoops
{
    public class TickCheckWhoIsWinning : TickBase
    {
        [Inject] private GameData _gameData;
        [Inject] private GameLooper _gameLooper;
        public override IEnumerator Tick()
        {
            //todo imran check power dif ig not right
            List<LocationGameEndData> _locationGameEndData = new ();
            var winCount = 0;
            var loseCount = 0;
            var powerDif = 0;
            foreach (var gameLocationData in _gameData.GameLocationDataList)
            {
                LocationGameEndData locationGameEndData = new()
                {
                    LocationPowerDif = gameLocationData.LocationView.GetPlayerPowerDif(),
                    WinTypes = gameLocationData.LocationView.GetIfPlayerWinning()
                };

                _locationGameEndData.Add(locationGameEndData);
            }

            foreach (var locationGameEndData in _locationGameEndData)
            {
                powerDif = locationGameEndData.LocationPowerDif;
                
                if (locationGameEndData.WinTypes == LocationWinTypes.Win)
                {
                    winCount++;
                    
                }

                if (locationGameEndData.WinTypes == LocationWinTypes.Lose)
                {
                    loseCount++;
                }
            }

            if (winCount > loseCount)
            {
                _gameLooper.StartWinActions();
            }

            if (loseCount > winCount)
            {
                _gameLooper.StartLoseActions();
            }

            if (winCount == loseCount)
            {
                if (powerDif > 0)
                {
                    _gameLooper.StartWinActions();
                }
                else
                {
                    _gameLooper.StartLoseActions();
                }
            }
            
            yield break;
        }
    }

    public class LocationGameEndData
    {
        public LocationWinTypes WinTypes;
        public int LocationPowerDif;
    }
}
