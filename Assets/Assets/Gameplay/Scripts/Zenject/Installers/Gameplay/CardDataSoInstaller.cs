using Assets.Gameplay.Scripts.Card;
using UnityEngine;
using Zenject;

namespace Assets.Gameplay.Scripts.Zenject.Installers.Gameplay
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Installers/CardDataSOInstaller", fileName = "CardDataSOInstaller")]
    public class CardDataSoInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private CardDataSo cardDataSo;
        
        public override void InstallBindings()
        {
            Container.BindInstance(cardDataSo).AsSingle();
        }
    }
}
