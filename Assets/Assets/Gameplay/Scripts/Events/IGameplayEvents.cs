using Assets.Gameplay.Scripts.Card;
using Assets.Gameplay.Scripts.Location;

namespace Assets.Gameplay.Scripts.Events
{
    public interface IGameplayEvents
    {
        public class OnGameWin
        {
        }

        public class OnGameLose
        {
        }

        public class OnGameStart
        {
        }

        public class OnPlayerPlayed
        {
        }

        public class OnTurnEnd
        {
        }

        public class OnTurnStart
        {
        }

        public class OnPlayerManaChanged
        {
            public int Value;
        }

        public class OnEnemyManaChanged
        {
            public int Value;
        }

        public class OnGameEnd
        {
            
        }

        public class OnCardAddedToLocation
        {
            public LocationView LocationView;
            public CardView CardView;
            public bool IsFromPlayer;
        }
    }
}
