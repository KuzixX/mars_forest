using Client.Scripts.Protocols;
using Client.Scripts.Protocols.Interfaces;
using UnityEngine;
using Zenject;

namespace Client.Scripts.Zenject_Installers
{
    public class CraftUiTransformInstaller : MonoInstaller<CraftUiTransformInstaller>
    {
        [SerializeField] private CraftTreesContainer treesContainer;
        [SerializeField] private CraftDecorContainer decorContainer;
        [SerializeField] private CraftHousesContainer housesContainer;
        public override void InstallBindings()
        {
            Container.Bind<ICraftItemTransform>().WithId("TreesContainer").To<CraftTreesContainer>()
                .FromInstance(treesContainer)
                .AsSingle()
                .NonLazy();
            Container.Bind<ICraftItemTransform>().WithId("DecorContainer").To<CraftHousesContainer>()
                .FromInstance(housesContainer)
                .AsSingle()
                .NonLazy();
            Container.Bind<ICraftItemTransform>().WithId("HousesContainer").To<CraftDecorContainer>()
                .FromInstance(decorContainer)
                .AsSingle()
                .NonLazy();
        }
    }
}
