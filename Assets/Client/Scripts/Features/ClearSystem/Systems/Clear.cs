using Client.Scripts.ECS_Feature.Common_Сomponents;
using Leopotam.Ecs;

namespace Client.Scripts.ECS_Feature.ClearSystem.Systems
{
    internal class Clear : IEcsRunSystem
    {
        private readonly EcsFilter<GameStateChange> _gameState;
        private readonly EcsFilter<EcsCommand> _command;
        public void Run()
        {
            foreach (var idx in _gameState)
            {
                if (_gameState.IsEmpty()) continue;
                ref var gameState = ref _gameState.GetEntity(idx);
                gameState.Del<GameStateChange>();
            }
            foreach (var idx in _command)
            {
                if (_command.IsEmpty()) continue;
                ref var command = ref _command.GetEntity(idx);
                command.Del<EcsCommand>();
            }
            
        }
    }
}