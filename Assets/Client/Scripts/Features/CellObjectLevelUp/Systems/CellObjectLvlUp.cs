using Client.Scripts.Features.Common_Сomponents;
using Client.Scripts.Features.Resources_Generation.Component;
using Client.Scripts.Models;
using Client.Scripts.Services.SQL;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Scripts.Features.CellObjectLevelUp.Systems
{
    internal class CellObjectLvlUp : IEcsInitSystem
    {
        //private Scripts.UI.UI _ui;
        private SqlLiteDB _sqlDB;
        private EcsWorld _world;
        private readonly EcsFilter<CellObject> _cellObjects;
        private readonly EcsFilter<GameState> _resources;

        public void Init()
        {
            if(true)
            {
                ref var gameStateData = ref _resources.Get1(0);
                ref var tree = ref _cellObjects.GetEntity(Random.Range(0, _cellObjects.GetEntitiesCount()));
                
                if (_cellObjects.IsEmpty() || gameStateData.gold < tree.Get<CellObject>().upgradePrice) return;
                // Game state event
                var gameStateEvent = _world.NewEntity();
                gameStateEvent.Get<GameStateChange>().EventType = Events.GoldSubtract;
                gameStateEvent.Get<GameStateChange>().Value = tree.Get<CellObject>().upgradePrice;
                // Update level
                tree.Get<CellObject>().upgradePrice += 10;
                tree.Get<CellObject>().level += 1;
                tree.Get<CellObject>().levelUpTitle.SetActive(false);
                tree.Get<CellObject>().levelUpTitle.SetActive(true);
                // Update DB and UI. Should be removed from here
                _sqlDB.UpdateCellObjectData("WorldElements", "Level", tree.Get<CellObject>().level,tree.Get<CellObject>().id);
            }
        }
    }
}