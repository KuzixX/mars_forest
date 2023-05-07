using Client.Scripts.ECS_Feature.Common_Сomponents;
using Leopotam.Ecs;

namespace Client.Scripts.ECS_Feature.ClearSystem.Systems
{
    internal class Clear : IEcsRunSystem
    {
        private readonly EcsFilter<GameStateChange> _gameState;
        public void Run()
        {
            foreach (var idx in _gameState)
            {
                if (!_gameState.IsEmpty())
                {
                    ref var gameState = ref _gameState.GetEntity(idx);
                    gameState.Del<GameStateChange>();
                }
            }
            
        }
    }
}