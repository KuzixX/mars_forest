using Client.Scripts.Features.Common_Сomponents;
using Leopotam.Ecs;

namespace Client.Scripts.Features.ClearSystem.Systems
{
    internal class Clear : IEcsRunSystem
    {
        private readonly EcsFilter<GameStateChange> _gameState;
        private readonly EcsFilter<EcsStringCommand> _command;
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
                command.Del<EcsStringCommand>();
            }
            
        }
    }
}