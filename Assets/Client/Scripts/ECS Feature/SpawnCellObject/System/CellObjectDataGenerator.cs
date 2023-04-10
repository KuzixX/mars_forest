using Client.Scripts.Data;
using Client.Scripts.ECS_Feature.Components;
using Client.Scripts.ECS_Feature.Interaction_Features.Component;
using Client.Scripts.ECS.Components;
using Leopotam.Ecs;
using Leopotam.Ecs.Ui.Components;
using UnityEngine;

namespace Client.Scripts.ECS_Feature.SpawnCellObject.System
{
    internal class CellObjectDataGenerator : IEcsRunSystem
    {
        private MonoBehaviors.UI.UI _ui;
        private EcsWorld _world;
        private readonly StaticData _staticData;
        private readonly EcsFilter<MainCamera> _mainCamera;
        private readonly EcsFilter<InGameResources> _resources;
        private readonly EcsFilter<SpawnCellObjectData> _tempTreeData;
        private readonly EcsFilter<EcsUiClickEvent> _clickEvents;
        private readonly EcsFilter<InteractionData> _interaction;

        public void Run()
        {
            if (_clickEvents.IsEmpty()) return;
            
            foreach (var index in _clickEvents)
            {
                ref var clickData = ref _clickEvents.Get1(index);
                ref var resources = ref _resources.Get1(0);
                ref var position = ref _interaction.Get1(0);
                ref var mainCamera = ref _mainCamera.GetEntity(0);
                ref var tempTreeData = ref _tempTreeData.GetEntity(0);

                for (int i = 0; i < _staticData.TreesData.Length; i++)
                {
                    if (clickData.WidgetName == _staticData.TreesData[i].Title &
                        resources.gold >= _staticData.TreesData[i].Price)
                    {
                        _world.NewEntity().Get<SpawnCellObjectData>();
                        position.CellPos = Vector3.zero;
                        tempTreeData.Get<SpawnCellObjectData>().Price = _staticData.TreesData[i].Price;
                        tempTreeData.Get<SpawnCellObjectData>().TreePrefab = _staticData.TreesData[i].Prefab;
                        tempTreeData.Get<SpawnCellObjectData>().TreeName = _staticData.TreesData[i].Title;
                        tempTreeData.Get<SpawnCellObjectData>().ProductionCycleTime = _staticData.TreesData[i].ProductionCycleTime;
                        tempTreeData.Get<SpawnCellObjectData>().ExpAmount = _staticData.TreesData[i].AmountOfExperience;
                        tempTreeData.Get<SpawnCellObjectData>().Id = _staticData.TreesData[i].Id;
                        mainCamera.Del<Lock>();
                        _ui.craftScreen.Show(false);
                    }
                }
            }
        }
    }
}