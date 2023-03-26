using Client.Scripts.Data;
using Client.Scripts.ECS.Components;
using Client.Scripts.MonoBehaviors.UI;
using Leopotam.Ecs;
using Leopotam.Ecs.Ui.Components;
using UnityEngine;

namespace Client.Scripts.ECS.System
{
    internal class CellObjectDataGenerator : IEcsRunSystem
    {
        private UI _ui;
        private EcsWorld _world;
        private readonly StaticData _staticData;
        private readonly EcsFilter<MainCamera> _mainCamera;
        private readonly EcsFilter<InGameResources> _resources;
        private readonly EcsFilter<SpawnTreeData> _tempTreeData;
        private readonly EcsFilter<EcsUiClickEvent> _clickEvents;
        private readonly EcsFilter<GetCellPositionComponent> _hitCellCenter;

        public void Run()
        {
            if (_clickEvents.IsEmpty()) return;
            
            foreach (var index in _clickEvents)
            {
                ref var clickData = ref _clickEvents.Get1(index);
                ref var resources = ref _resources.Get1(0);
                ref var position = ref _hitCellCenter.Get1(0);
                ref var mainCamera = ref _mainCamera.GetEntity(0);
                ref var tempTreeData = ref _tempTreeData.GetEntity(0);

                for (int i = 0; i < _staticData.TreesData.Length; i++)
                {
                    if (clickData.WidgetName == _staticData.TreesData[i].Title &
                        resources.gold >= _staticData.TreesData[i].Price)
                    {
                        _world.NewEntity().Get<SpawnTreeData>();
                        position.CellPos = Vector3.zero;
                        tempTreeData.Get<SpawnTreeData>().Price = _staticData.TreesData[i].Price;
                        tempTreeData.Get<SpawnTreeData>().TreePrefab = _staticData.TreesData[i].Prefab;
                        tempTreeData.Get<SpawnTreeData>().TreeName = _staticData.TreesData[i].Title;
                        tempTreeData.Get<SpawnTreeData>().ProductionCycleTime = _staticData.TreesData[i].ProductionCycleTime;
                        tempTreeData.Get<SpawnTreeData>().ExpAmount = _staticData.TreesData[i].AmountOfExperience;
                        tempTreeData.Get<SpawnTreeData>().Id = _staticData.TreesData[i].Id;
                        mainCamera.Del<Lock>();
                        _ui.craftScreen.Show(false);
                    }
                }
            }
        }
    }
}