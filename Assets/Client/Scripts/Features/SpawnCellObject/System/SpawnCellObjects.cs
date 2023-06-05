using Client.Scripts.ECS_Feature.Camera_Control.Component;
using Client.Scripts.ECS_Feature.Common_Сomponents;
using Client.Scripts.ECS_Feature.Common_Сomponents.Tags;
using Client.Scripts.ECS_Feature.ECS_Feature_old.EventCoponents;
using Client.Scripts.ECS_Feature.ECS_Feature_old.UI.Component;
using Client.Scripts.ECS_Feature.Interaction_Feature.Component;
using Client.Scripts.ECS_Feature.SpawnCellObject.Component;
using Client.Scripts.Features.Common_Сomponents;
using Client.Scripts.Features.Resources_Generation.Component;
using Client.Scripts.Models;
using Client.Scripts.Protocols;
using Client.Scripts.Services;
using Leopotam.Ecs;
using Leopotam.Ecs.Ui.Components;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Client.Scripts.ECS_Feature.SpawnCellObject.System
{
    internal class SpawnCellObjects : IEcsRunSystem
    {
        //private Scripts.UI.UI _ui;
        private FX _fx;
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
            // Create temp data for spawn cell object;
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
                    //_ui.craftScreen.Show(false);
                }

            // Light free zone
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
            
            // Spawn cell object
            foreach (var index in _cells)
            {
                ref var cell = ref _cells.GetEntity(index);
                ref var interactionData = ref _interaction.Get1(0);
                ref var tempTreeData = ref _tempSpawnData.GetEntity(0);

                if ( _tempSpawnData.IsEmpty() || cell.Get<Position>().transform.position != interactionData.CellPos || cell.Has<TakenCell>()) continue;
                
                ref var tempSpawnData = ref _tempSpawnData.GetEntity(0);
                
                // Instantiate tree prefab
                var newCellPrefab = Object.Instantiate(tempSpawnData.Get<TempCellObjectData>().TreePrefab, cell.Get<Position>().transform.position, Quaternion.identity);
                // var isFullIconPrefab = Object.Instantiate(_staticData.GoldSprite, _ui.mainScreen.transform);
                // var levelUpTitlePrefab = Object.Instantiate(_staticData.LevelUpTitle, _ui.mainScreen.transform);
                
                // Create  tree entity
                var cellObject = _world.NewEntity();
                cellObject.Get<CellObject>().treePrefab = newCellPrefab;
                cellObject.Get<CellObject>().id = _trees.GetEntitiesCount();
                cellObject.Get<CellObject>().title = tempSpawnData.Get<TempCellObjectData>().TreeName;
                cellObject.Get<CellObject>().currentCycleState = tempSpawnData.Get<TempCellObjectData>().ProductionCycleTime;
                //cellObject.Get<CellObject>().isFullIcon = isFullIconPrefab;
                cellObject.Get<CellObject>().expAmount = tempTreeData.Get<TempCellObjectData>().ExpAmount;
                cellObject.Get<CellObject>().isExpGot = false;
                //cellObject.Get<CellObject>().levelUpTitle = levelUpTitlePrefab;
                cellObject.Get<CellObject>().isSelected = newCellPrefab.transform.GetChild(1).gameObject;
                cellObject.Get<CellObject>().spawnPoint = newCellPrefab.transform.GetChild(2).gameObject.transform;
                //cellObject.Get<CellObject>().levelUpTitleRectPos = levelUpTitlePrefab.GetComponent<RectTransform>();
                //cellObject.Get<CellObject>().isFullIconRectPos = isFullIconPrefab.GetComponent<RectTransform>();
                cellObject.Get<CellObject>().level = 1;
                cellObject.Get<CellObject>().lifeTimeLvlUpTitle = 2;
                cellObject.Get<CellObject>().upgradePrice = 10;
                cellObject.Get<Position>().transform = newCellPrefab.transform;
                cellObject.Get<OnSetTreeEvent>().TypeOfTree = tempSpawnData.Get<TempCellObjectData>().TreeName;

                // Game state event Gold
                var stateEvent01 = _world.NewEntity();
                stateEvent01.Get<GameStateChange>().EventType = Events.GoldSubtract;
                stateEvent01.Get<GameStateChange>().Value = tempSpawnData.Get<TempCellObjectData>().Price;

                // Game state event CellObject
                var stateEvent02 = _world.NewEntity();
                stateEvent02.Get<GameStateChange>().EventType = Events.CellObjectAdd;
                stateEvent02.Get<GameStateChange>().Value = 1;

                // Update UI. Should be removed from here
                _fx.experienceParticleSystem.GetComponent<RectTransform>().anchoredPosition = WorldToScreenConvertor.WorldToCanvasSpace(_sceneData.MainCanvasRect, _sceneData.MainCamera, cellObject.Get<CellObject>().spawnPoint.position);;
                _fx.experienceParticleSystem.GetComponent<ParticleSystem>().Play();

                // Take cell
                cell.Get<TakenCell>();
                      
                // Delete temp data
                tempSpawnData.Del<TempCellObjectData>();
            }
        }
    }
}