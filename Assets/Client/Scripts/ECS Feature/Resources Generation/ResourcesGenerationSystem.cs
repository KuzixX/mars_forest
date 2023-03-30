using Client.Scripts.Data;
using Client.Scripts.ECS_Feature.Components;
using Client.Scripts.ECS.Components;
using Client.Scripts.ECS.Components.EventCoponents;
using Client.Scripts.MonoBehaviors.UI;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Scripts.ECS_Feature.Resources_Generation
{
    internal class ResourcesGenerationSystem : IEcsRunSystem
    {
        private readonly UI _ui;
        private readonly StaticData _staticData;
        private readonly EcsFilter<CellObject>.Exclude<IsFull> _trees;
        private readonly EcsFilter<InGameResources> _resources;
        private readonly EcsFilter<SpawnCellObjectData> _spawnTreeData;
        private readonly EcsFilter<OnSetTreeEvent> _setTreeEvent;
        private readonly SceneData _sceneData;

        public void Run()
        {
            foreach (var index in _trees)
            {
                ref var tree = ref _trees.GetEntity(index);
                ref var resources = ref _resources.Get1(0);
                ref var treeSpawnData = ref _spawnTreeData.GetEntity(0);

                if (!_spawnTreeData.IsEmpty() && !_setTreeEvent.IsEmpty())
                {
                    resources.experience += treeSpawnData.Get<SpawnCellObjectData>().ExpAmount;
                    _ui.mainScreen.expAmountText.text = resources.experience.ToString();
                    treeSpawnData.Del<SpawnCellObjectData>();
                }

                for (int i = 0; i < _staticData.TreesData.Length; i++)
                {
                    if (_staticData.TreesData[i].Title == tree.Get<CellObject>().title)
                    {
                        tree.Get<CellObject>().currentCycleState -= Time.deltaTime;
                        if (tree.Get<CellObject>().currentCycleState <= 0)
                        {
                            tree.Get<CellObject>().currentCycleState = _staticData.TreesData[i].ProductionCycleTime;
                            // tree.Get<Tree>().isFullIcon.SetActive(true);
                            tree.Get<IsFull>();
                        }
                    }
                }
            }
        }
    }
}