using Client.Scripts.ECS_Feature.Common_Сomponents;
using Client.Scripts.ECS_Feature.Resources_Generation.Component;
using Client.Scripts.Models;
using Client.Scripts.Protocols.Interface;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Scripts.ECS_Feature.Projection_Systems.System
{
    internal class GameStateProjection : IEcsRunSystem
    {
        private readonly EcsFilter<GameState> _filter;
        private readonly EcsFilter<GameStateChange> _event;
        private IGameStateProtocol _gameStateProtocol;

        public GameStateProjection(IGameStateProtocol gameStateProtocol)
        {
            _gameStateProtocol = gameStateProtocol;
        }
        public void Run()
        {
            foreach (var idx in _event)
            {
                ref var gameSateEntity = ref _event.Get1(idx);
                ref var gameStateData = ref _filter.Get1(0);

                switch (gameSateEntity.EventType)
                {
                    case GameStateEvents.GoldAdd or GameStateEvents.GoldSubtract:
                        _gameStateProtocol.Gold.Value = gameStateData.gold;
                        Debug.Log("Gold was projected");
                        break;
                    case GameStateEvents.ExperienceAdd
                        or GameStateEvents.ExperienceSubtract:
                        Debug.Log("Experience was projected");
                        _gameStateProtocol.Experience.Value = gameStateData.experience;
                        break;
                    case GameStateEvents.DiamondsAdd or GameStateEvents.DiamondsSubtract:
                        _gameStateProtocol.Diamonds.Value = gameStateData.diamonds;
                        Debug.Log("Diamonds was projected");
                        break;
                    case GameStateEvents.CellObjectAdd:
                        _gameStateProtocol.CellObjectsCount.Value = gameStateData.cellObjectAmount;
                        Debug.Log("CellObject was projected");
                        break;
                }
            }
        }
    }
}