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

        public class OnGameEnd
        {
            
        }
    }
}
