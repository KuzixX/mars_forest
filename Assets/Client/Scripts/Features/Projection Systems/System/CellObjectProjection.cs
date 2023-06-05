using Client.Scripts.ECS_Feature.Common_Сomponents;
using Client.Scripts.Features.Common_Сomponents;
using Client.Scripts.Features.Resources_Generation.Component;
using Client.Scripts.Models;
using Client.Scripts.Protocols.Interfaces;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Scripts.Features.Projection_Systems.System
{
    internal class CellObjectProjection : IEcsRunSystem
    {
        private ICellObjectCountProtocol _cellObjectCountProtocol;
        private readonly EcsFilter<GameState> _gameState;
        private readonly EcsFilter<GameStateChange> _events;
        public CellObjectProjection(ICellObjectCountProtocol cellObjectCountProtocol)
        {
            _cellObjectCountProtocol = cellObjectCountProtocol;
        }
        public void Run()
        {
            foreach (var idx in _events)
            {
                ref var gameSateEntity = ref _events.Get1(idx);
                ref var gameStateData = ref _gameState.Get1(0);
                switch (gameSateEntity.EventType)
                {
                    case Events.CellObjectAdd:
                        _cellObjectCountProtocol.CellObjectsCount.Value = gameStateData.cellObjectAmount;
                        Debug.Log("Cell Objects was projected");
                        break;
                }
            }
        }
    }
}