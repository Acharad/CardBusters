using UnityEngine;
using Assets.Gameplay.Scripts.Common;

namespace Assets.Gameplay.Scripts.Card
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Card", fileName = "CardDataSo")]
    public class CardDataSo : ScriptableObject
    {
        [System.Serializable]
        public class GameCardViewDictionary : UnitySerializedDictionary<CardType, CardData> { }
        [SerializeField] public GameCardViewDictionary gameCardViewDictionary;
    }
    
    [System.Serializable]
    public class CardData
    {
        public CardView cardView;
        public CardModel cardModel;
    }
}
