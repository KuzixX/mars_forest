using Client.Scripts.ECS_Feature.Resources_Generation.Component;
using Client.Scripts.Protocols.Interface;
using Leopotam.Ecs;

namespace Client.Scripts.ECS_Feature.Projection_Systems.System
{
    internal class GameStateProjection : IEcsRunSystem
    { 
        private readonly EcsFilter<GameState> _filter;
        private IGameStateProtocol _gameStateProtocol;
        public void Run()
        {
            ref var gameStateData = ref _filter.Get1(0);
            _gameStateProtocol.Gold.Value = gameStateData.gold;
            _gameStateProtocol.Diamonds.Value = gameStateData.diamonds;
            _gameStateProtocol.Experience.Value = gameStateData.experience;
            _gameStateProtocol.CellObjectsCount.Value = gameStateData.cellObjectAmount;
        }
    }
}