using Assets.Gameplay.Scripts.Card;
using Assets.Gameplay.Scripts.Location;

namespace Assets.Gameplay.Scripts.GamePlay
{
    public class PlayerMoveData
    {
        private CardModel _playedCard;
        private LocationModel _playedLocation;

        public PlayerMoveData(CardModel playedCard, LocationModel playedLocation)
        {
            _playedCard = playedCard;
            _playedLocation = playedLocation;
        }
    }
}
