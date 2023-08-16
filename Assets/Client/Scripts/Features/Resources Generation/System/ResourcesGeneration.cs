using Client.Scripts.Features.Common_Сomponents;
using Client.Scripts.Features.Common_Сomponents.Tags;
using Client.Scripts.Features.Resources_Generation.Component;
using Client.Scripts.Models;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Scripts.Features.Resources_Generation.System
{
    internal class ResourcesGeneration : IEcsRunSystem, IEcsInitSystem
    {
        private EcsWorld _world;
        private readonly StaticData _staticData;
        private readonly EcsFilter<CellObject>.Exclude<IsFull> _cellObjects;

        public void Init()
        {
            _world.NewEntity().Get<GameState>();
            var gameStateEvent00 = _world.NewEntity();
            gameStateEvent00.Get<GameStateChange>().EventType = Events.GoldAdd;
            gameStateEvent00.Get<GameStateChange>().Value = 10000;
            var gameStateEvent01 = _world.NewEntity();
            gameStateEvent01.Get<GameStateChange>().EventType = Events.ExperienceAdd;
            gameStateEvent01.Get<GameStateChange>().Value = 10000;
            var gameStateEvent03 = _world.NewEntity();
            gameStateEvent03.Get<GameStateChange>().EventType = Events.DiamondsAdd;
            gameStateEvent03.Get<GameStateChange>().Value = 10000;
        }
        public void Run()
        {
            foreach (var index in _cellObjects)
            {
                ref var cell = ref _cellObjects.GetEntity(index);

                foreach (var t in _staticData.TreesData)
                {
                    if (!cell.Get<CellObject>().isExpGot && t.Title == cell.Get<CellObject>().title)
                    {
                        var stateEvent = _world.NewEntity();
                        stateEvent.Get<GameStateChange>().EventType = Events.ExperienceAdd;
                        stateEvent.Get<GameStateChange>().Value = cell.Get<CellObject>().expAmount;
                        cell.Get<CellObject>().isExpGot = true;
                    }
                    if (t.Title != cell.Get<CellObject>().title) continue;
                    cell.Get<CellObject>().currentCycleState -= Time.deltaTime;
                    if (!(cell.Get<CellObject>().currentCycleState <= 0)) continue;
                    cell.Get<CellObject>().currentCycleState = t.ProductionCycleTime;
                    cell.Get<IsFull>();
                }
            }
        }
    }
}