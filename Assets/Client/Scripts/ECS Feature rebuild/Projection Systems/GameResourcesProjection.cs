using Client.Scripts.ECS_Feature_rebuild.Resources_Generation;
using Leopotam.Ecs;

namespace Client.Scripts.ECS_Feature_rebuild.Projection_Systems
{
    internal class GameResourcesProjection : IEcsRunSystem
    { 
        private readonly EcsFilter<InGameResources> _resources;
        private IResourcesProtocol _resourcesProtocol;
        public void Run()
        {
            ref var resources = ref _resources.Get1(0);
            _resourcesProtocol.Gold = resources.gold;
            _resourcesProtocol.Diamonds = resources.diamonds;
            _resourcesProtocol.Experience = resources.gold;
        }
    }
}