using Client.Scripts.ECS_Feature.Camera_Control.Component;
using Client.Scripts.ECS_Feature.Common_Сomponents;
using Client.Scripts.ECS_Feature.Common_Сomponents.Tags;
using Client.Scripts.ECS_Feature.ECS_Feature_old.EventCoponents;
using Client.Scripts.ECS_Feature.ECS_Feature_old.UI.Component;
using Client.Scripts.ECS_Feature.Interaction_Feature.Component;
using Client.Scripts.ECS_Feature.Resources_Generation.Component;
using Client.Scripts.ECS_Feature.SpawnCellObject.Component;
using Client.Scripts.Models;
using Client.Scripts.Services;
using Leopotam.Ecs;
using Leopotam.Ecs.Ui.Components;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Client.Scripts.ECS_Feature.SpawnCellObject.System
{
    internal class SpawnCellObjects : IEcsRunSystem
    {
        private Scripts.UI.UI _ui;
        private EcsWorld _world;
        private readonly SceneData _sceneData;
        private readonly StaticData _staticData;
        private readonly EcsFilter<CameraTag> _mainCamera;
        private readonly EcsFilter<Cell, Position> _cells;
        private readonly EcsFilter<GameState> _resources;
        private readonly EcsFilter<TempCellObjectData> _tempSpawnData;
        private readonly EcsFilter<EcsUiClickEvent> _clickEvents;
        private readonly EcsFilter<InteractionData> _interaction;
        private readonly EcsFilter<CellObject> _trees;
        private readonly EcsFilter<EventEntityTag> _eventEntity;
        private readonly EcsFilter<OnSetTreeEvent> _setTreeEvent;

        public void Run()
        {
            if (!_clickEvents.IsEmpty())
            {
                ref var clickData = ref _clickEvents.Get1(0);
                ref var resources = ref _resources.Get1(0);
                ref var position = ref _interaction.Get1(0);
                ref var mainCamera = ref _mainCamera.GetEntity(0);

                foreach (var t in _staticData.TreesData)
                {
                    if (!(clickData.WidgetName == t.Title & resources.gold >= t.Price)) continue;
                    if(!_tempSpawnData.IsEmpty()) return;
                    var tempCellData = _world.NewEntity();
                    position.CellPos = Vector3.zero;
                    tempCellData.Get<TempCellObjectData>().Price = t.Price;
                    tempCellData.Get<TempCellObjectData>().TreePrefab = t.Prefab;
                    tempCellData.Get<TempCellObjectData>().TreeName = t.Title;
                    tempCellData.Get<TempCellObjectData>().ProductionCycleTime = t.ProductionCycleTime;
                    tempCellData.Get<TempCellObjectData>().ExpAmount = t.AmountOfExperience;
                    tempCellData.Get<TempCellObjectData>().Id = t.Id;
                    mainCamera.Del<Lock>();
                    _ui.craftScreen.Show(false);
                }
            }
            
            foreach (var index in _cells)
            {
                ref var cell = ref _cells.GetEntity(index);

                foreach (var t in _staticData.TreesData)
                {
                    if (!cell.Has<TakenCell>() && !_tempSpawnData.IsEmpty())
                    {
                        cell.Get<Cell>().lightingCell.SetActive(true);
                    }
                    else if (!_setTreeEvent.IsEmpty())
                    {
                        cell.Get<Cell>().lightingCell.SetActive(false);
                    }
                }
            }
            
            foreach (var index in _cells)
            {
                ref var cell = ref _cells.GetEntity(index);
                ref var interactionData = ref _interaction.Get1(0);
                ref var tempTreeData = ref _tempSpawnData.GetEntity(0);

                if ( _tempSpawnData.IsEmpty() || cell.Get<Position>().transform.position != interactionData.CellPos || cell.Has<TakenCell>()) continue;
                
                ref var spawnData = ref _tempSpawnData.GetEntity(0);
                
                // Instantiate tree prefab
                var newCellObject = Object.Instantiate(spawnData.Get<TempCellObjectData>().TreePrefab, cell.Get<Position>().transform.position, Quaternion.identity);
                var isFullIconObject = Object.Instantiate(_staticData.GoldSprite, _ui.mainScreen.transform);
                var levelUpTitleObject = Object.Instantiate(_staticData.LevelUpTitle, _ui.mainScreen.transform);
                
                // Create  tree entity
                var tree = _world.NewEntity();
                tree.Get<CellObject>().treePrefab = newCellObject;
                tree.Get<CellObject>().id = _trees.GetEntitiesCount();
                tree.Get<CellObject>().title = spawnData.Get<TempCellObjectData>().TreeName;
                tree.Get<CellObject>().currentCycleState = spawnData.Get<TempCellObjectData>().ProductionCycleTime;
                tree.Get<CellObject>().isFullIcon = isFullIconObject;
                tree.Get<CellObject>().expAmount = tempTreeData.Get<TempCellObjectData>().ExpAmount;
                tree.Get<CellObject>().isExpGot = false;
                tree.Get<CellObject>().levelUpTitle = levelUpTitleObject;
                tree.Get<CellObject>().isSelected = newCellObject.transform.GetChild(1).gameObject;
                tree.Get<CellObject>().spawnPoint = newCellObject.transform.GetChild(2).gameObject.transform;
                tree.Get<CellObject>().levelUpTitleRectPos = levelUpTitleObject.GetComponent<RectTransform>();
                tree.Get<CellObject>().isFullIconRectPos = isFullIconObject.GetComponent<RectTransform>();
                tree.Get<CellObject>().level = 1;
                tree.Get<CellObject>().lifeTimeLvlUpTitle = 2;
                tree.Get<CellObject>().upgradePrice = 10;
                tree.Get<Position>().transform = newCellObject.transform;
                tree.Get<OnSetTreeEvent>().TypeOfTree = spawnData.Get<TempCellObjectData>().TreeName;

                // Game state event
                var stateEvent01 = _world.NewEntity();
                stateEvent01.Get<GameStateChange>().EventType = GameStateEvents.GoldSubtract;
                stateEvent01.Get<GameStateChange>().Value = spawnData.Get<TempCellObjectData>().Price;

                // Update UI. Should be removed from here
                _ui.expUIParticleSystem.GetComponent<RectTransform>().anchoredPosition = WorldToScreenConvertor.WorldToCanvasSpace(_ui.mainCanvasRect, _sceneData.MainCamera, tree.Get<CellObject>().spawnPoint.position);
                _ui.expUIParticleSystem.Play();

                // Take cell
                cell.Get<TakenCell>();
                      
                // Delete temp data
                spawnData.Del<TempCellObjectData>();
            }
        }
    }
}