using Client.Scripts.ECS_Feature.Resources_Generation.Component;
using Leopotam.Ecs;

namespace Client.Scripts.ECS_Feature
{
    internal class DebugSystem : IEcsInitSystem
    {
        private readonly EcsFilter<GameState> _res;

        public void Init()
        {
        }
    }
}