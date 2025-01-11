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
        //After you play a card here, +1 Power.
        Angela = 6,
        AntMan = 7,
        //5 mana 9 power
        Abomination = 8,
        // 1 mana -2 power switch sides.
        AcidArrow = 9,
        // set the power of all cards in your deck to 3.
        AgentVenom = 10,
        // give next card +2 power
        AmericaChavez = 11,
        // enemy top card cost 6
        BaronMordo = 12,
        // if this is in your hand after th turn, discard it
        BlackCat = 13,
        // after you paly a card this gains +1 power 3,1
        Bishop = 14,
        // double this card's power.
        BlackPanther = 15,
        // your other cards have +1 power 5,3 (same location)
        BlueMarvel = 16,
        // add 2 broodlings here with the same power. (3,2)
        Brood = 17,
        // discard the card the least from your hand.
        ColleenWing = 18,
        // discard 2 cards from your hand to get +1 max energy.
        CorvusGlaive = 19,
        // each players draws a card
        Crystal = 20,
        // +2 power for each card in your hand ???
        DevilDinosaur = 21, 
        // next turn you get +2 energy
        Djinn = 22,
        // add a 5-power doombot to each other location
        DoctorDoom = 23,
        //6,5
        DoomBot = 24,
        // draw this card second turn
        Domino = 25,
        // if oppenet played card here get +4
        Gamora = 26,
        // discard a card from your hand to destroy a random enemy card.
        Gambit = 27,
        // after each turn you lose 1 max energy and this gains +4 power.
        Havok = 28,
        
    }
}
