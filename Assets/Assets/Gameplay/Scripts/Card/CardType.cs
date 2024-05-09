namespace Assets.Gameplay.Scripts.Card
{
    public enum CardType
    {
        None = 0,
        Random = 1,
        //start in your opening hand. 1,2
        QuickSilver = 2,
        //on reveal: if this is at the middile location +3 power. 2,3
        Medusa = 3,
        //6,12
        Hulk = 4,
        //on reveal if your opponent played a card here this turn +4 2,2
        StarLord = 5,
    }
}
