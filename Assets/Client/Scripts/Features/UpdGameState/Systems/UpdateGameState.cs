using Client.Scripts.Features.Common_Сomponents;
using Client.Scripts.Features.Resources_Generation.Component;
using Client.Scripts.Models;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Scripts.Features.UpdGameState.Systems
{
    internal class UpdateGameState : IEcsRunSystem
    {
        private readonly EcsFilter<GameState> _gameState;
        private readonly EcsFilter<GameStateChange> _stateChange;

        public void Run()
        {
            ref var gameStateData = ref _gameState.Get1(0);

            foreach (var idx in _stateChange)
            {
                ref var gameStateEventData = ref _stateChange.Get1(idx);

                switch (gameStateEventData.EventType)
                {
                    case Events.GoldAdd:
                        gameStateData.gold += gameStateEventData.Value;
                        Debug.Log("GoldAdd");
                        break;
                    case Events.GoldSubtract:
                        gameStateData.gold -= gameStateEventData.Value;
                        Debug.Log("GoldSubtract");
                        break;
                    // Experience cases
                    case Events.ExperienceAdd:
                        gameStateData.experience += gameStateEventData.Value;
                        Debug.Log("ExperienceAdd");
                        break;
                    case Events.ExperienceSubtract:
                        gameStateData.experience -= gameStateEventData.Value;
                        Debug.Log("ExperienceSubtract");
                        break;
                    // Diamonds cases
                    case Events.DiamondsAdd:
                        gameStateData.diamonds += gameStateEventData.Value;
                        Debug.Log("DiamondsAdd");
                        break;
                    case Events.DiamondsSubtract:
                        gameStateData.diamonds -= gameStateEventData.Value;
                        Debug.Log("DiamondsSubtract");
                        break;
                    // Cell objects cases
                    case Events.CellObjectAdd:
                        gameStateData.cellObjectAmount += gameStateEventData.Value;
                        break;
                }
            }
        }
    }
}