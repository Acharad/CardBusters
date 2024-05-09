
namespace Assets.Gameplay.Scripts.Location
{
    public enum LocationType 
    {
        None = 0,
        Random = 1,
        //random card get +1 cost
        IceBox = 2,
        // if only one card card get +5 power
        Atlantis = 3,
        // after turn 4 whoover is winning this location draws 2 card.
        Asgard = 4,
        //ruins not special location
        Ruins = 5,
    }
}
