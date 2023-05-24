using Client.Scripts.ECS_Feature.Common_Сomponents;
using Client.Scripts.Models;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Scripts.ECS_Feature.UpdGameState.Systems
{
    internal class UpdateGameState : IEcsRunSystem
    {
        private readonly EcsFilter<Resources_Generation.Component.GameState> _gameState;
        private readonly EcsFilter<GameStateChange> _stateChange;

        public void Run()
        {
            ref var gameStateData = ref _gameState.Get1(0);

            foreach (var idx in _stateChange)
            {
                ref var gameStateEventData = ref _stateChange.Get1(idx);

                switch (gameStateEventData.EventType)
                {
                    case GameStateEvents.GoldAdd:
                        gameStateData.gold += gameStateEventData.Value;
                        Debug.Log("GoldAdd");
                        break;
                    case GameStateEvents.GoldSubtract:
                        gameStateData.gold -= gameStateEventData.Value;
                        Debug.Log("GoldSubtract");
                        break;
                    // Experience cases
                    case GameStateEvents.ExperienceAdd:
                        gameStateData.experience += gameStateEventData.Value;
                        Debug.Log("ExperienceAdd");
                        break;
                    case GameStateEvents.ExperienceSubtract:
                        gameStateData.experience -= gameStateEventData.Value;
                        Debug.Log("ExperienceSubtract");
                        break;
                    // Diamonds cases
                    case GameStateEvents.DiamondsAdd:
                        gameStateData.diamonds += gameStateEventData.Value;
                        Debug.Log("DiamondsAdd");
                        break;
                    case GameStateEvents.DiamondsSubtract:
                        gameStateData.diamonds -= gameStateEventData.Value;
                        Debug.Log("DiamondsSubtract");
                        break;
                    // Cell objects cases
                    case GameStateEvents.CellObjectAdd:
                        gameStateData.cellObjectAmount += gameStateEventData.Value;
                        break;
                }
            }
        }
    }
}