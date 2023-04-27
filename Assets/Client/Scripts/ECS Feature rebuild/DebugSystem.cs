using Client.Scripts.ECS_Feature_rebuild.Resources_Generation;
using Leopotam.Ecs;

namespace Client.Scripts.ECS_Feature_rebuild
{
    internal class DebugSystem : IEcsInitSystem
    {
        private readonly EcsFilter<InGameResources> _res;

        public void Init()
        {
        }
    }
}