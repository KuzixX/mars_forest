using Client.Scripts.ECS_Feature.Common_Сomponents;
using Client.Scripts.ECS_Feature.Common_Сomponents.Tags;
using Client.Scripts.ECS_Feature.ECS_Feature_old.EventCoponents;
using Client.Scripts.ECS_Feature.Resources_Generation.Component;
using Client.Scripts.ECS_Feature.SpawnCellObject.Component;
using Client.Scripts.Models;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Scripts.ECS_Feature.Resources_Generation.System
{
    internal class ResourcesGeneration : IEcsRunSystem, IEcsInitSystem
    {
        private EcsWorld _world;
        private readonly StaticData _staticData;
        private readonly EcsFilter<CellObject>.Exclude<IsFull> _trees;
        private readonly EcsFilter<GameState> _resources;
        private readonly EcsFilter<TempCellObjectData> _spawnTreeData;
        private readonly EcsFilter<OnSetTreeEvent> _setTreeEvent;
        private readonly SceneData _sceneData;

        public void Init()
        {
            _world.NewEntity().Get<GameState>();
            ref var res = ref _resources.Get1(0);
            res.gold = 1000;
            res.diamonds = 1000;
            res.experience = 1000;
        }
        public void Run()
        {
            foreach (var index in _trees)
            {
                ref var tree = ref _trees.GetEntity(index);
                ref var resources = ref _resources.Get1(0);
                ref var treeSpawnData = ref _spawnTreeData.GetEntity(0);

                if (!_spawnTreeData.IsEmpty() && !_setTreeEvent.IsEmpty())
                {
                    resources.experience += treeSpawnData.Get<TempCellObjectData>().ExpAmount;
                    treeSpawnData.Del<TempCellObjectData>();
                }

                for (int i = 0; i < _staticData.TreesData.Length; i++)
                {
                    if (_staticData.TreesData[i].Title == tree.Get<CellObject>().title)
                    {
                        tree.Get<CellObject>().currentCycleState -= Time.deltaTime;
                        if (tree.Get<CellObject>().currentCycleState <= 0)
                        {
                            tree.Get<CellObject>().currentCycleState = _staticData.TreesData[i].ProductionCycleTime;
                            tree.Get<IsFull>();
                        }
                    }
                }
            }
        }
    }
}