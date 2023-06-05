using Client.Scripts.Features.Common_Сomponents;
using Client.Scripts.Features.Resources_Generation.Component;
using Client.Scripts.Models;
using Client.Scripts.Protocols.Interfaces;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Scripts.Features.Projection_Systems.System
{
    internal class GoldProjection : IEcsRunSystem
    {
        private IGoldProtocol _goldProtocol;
        private readonly EcsFilter<GameState> _gameState;
        private readonly EcsFilter<GameStateChange> _events;
        public GoldProjection(IGoldProtocol goldProtocol)
        {
            _goldProtocol = goldProtocol;
        }
        public void Run()
        {
            foreach (var idx in _events)
            {
                ref var gameSateEntity = ref _events.Get1(idx);
                ref var gameStateData = ref _gameState.Get1(0);
                switch (gameSateEntity.EventType)
                {
                    case Events.GoldAdd or Events.GoldSubtract:
                        _goldProtocol.Gold.Value = gameStateData.gold;
                        Debug.Log("Gold was projected");
                        break;
                }
            }
        }
    }
}