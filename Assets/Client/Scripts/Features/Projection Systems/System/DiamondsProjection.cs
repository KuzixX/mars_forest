using Client.Scripts.Features.Common_Сomponents;
using Client.Scripts.Features.Resources_Generation.Component;
using Client.Scripts.Models;
using Client.Scripts.Protocols.Interfaces;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Scripts.Features.Projection_Systems.System
{
    internal class DiamondsProjection : IEcsRunSystem
    {
        private IDiamondsProtocol _diamondsProtocol;
        private readonly EcsFilter<GameState> _gameState;
        private readonly EcsFilter<GameStateChange> _events;
        public DiamondsProjection(IDiamondsProtocol diamondsProtocol)
        {
            _diamondsProtocol = diamondsProtocol;
        }
        public void Run()
        {
            foreach (var idx in _events)
            {
                ref var gameSateEntity = ref _events.Get1(idx);
                ref var gameStateData = ref _gameState.Get1(0);
                switch (gameSateEntity.EventType)
                {
                    case Events.DiamondsAdd or Events.DiamondsSubtract:
                        _diamondsProtocol.Diamonds.Value = gameStateData.diamonds;
                        Debug.Log("Diamonds was projected");
                        break;
                }
            }
        }
    }
}