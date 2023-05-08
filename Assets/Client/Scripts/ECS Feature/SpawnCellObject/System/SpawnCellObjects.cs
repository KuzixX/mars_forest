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

        public void Run()
        {
            if (_clickEvents.IsEmpty()) return;
            ref var clickData = ref _clickEvents.Get1(0);
                ref var resources = ref _resources.Get1(0);
                ref var position = ref _interaction.Get1(0);
                ref var mainCamera = ref _mainCamera.GetEntity(0);
                ref var interactionData = ref _interaction.Get1(0);
                ref var tempTreeData = ref _tempSpawnData.GetEntity(0);

                for (int i = 0; i < _staticData.TreesData.Length; i++)
                {
                    if (clickData.WidgetName == _staticData.TreesData[i].Title &
                        resources.gold >= _staticData.TreesData[i].Price)
                    {
                        _world.NewEntity().Get<TempCellObjectData>();
                        position.CellPos = Vector3.zero;
                        tempTreeData.Get<TempCellObjectData>().Price = _staticData.TreesData[i].Price;
                        tempTreeData.Get<TempCellObjectData>().TreePrefab = _staticData.TreesData[i].Prefab;
                        tempTreeData.Get<TempCellObjectData>().TreeName = _staticData.TreesData[i].Title;
                        tempTreeData.Get<TempCellObjectData>().ProductionCycleTime = _staticData.TreesData[i].ProductionCycleTime;
                        tempTreeData.Get<TempCellObjectData>().ExpAmount = _staticData.TreesData[i].AmountOfExperience;
                        tempTreeData.Get<TempCellObjectData>().Id = _staticData.TreesData[i].Id;
                        mainCamera.Del<Lock>();
                        _ui.craftScreen.Show(false);
                    }
            }



            foreach (var index in _cells)
            {
                ref var cell = ref _cells.GetEntity(index);

                ref var spawnData = ref _tempSpawnData.GetEntity(0);
                if (cell.Get<Position>().transform.position == interactionData.CellPos && !cell.Has<TakenCell>())
                {
                    Debug.Log("Spawn");
                    // Instantiate tree prefab
                    var newTree = Object.Instantiate(spawnData.Get<TempCellObjectData>().TreePrefab, cell.Get<Position>().transform.position, Quaternion.identity);
                    var isFullIcon = Object.Instantiate(_staticData.GoldSprite, _ui.mainScreen.transform);
                    var levelUpTitle = Object.Instantiate(_staticData.LevelUpTitle, _ui.mainScreen.transform);
                      
                    // Create  tree entity
                    var tree = _world.NewEntity();
                    tree.Get<CellObject>().treePrefab = newTree;
                    tree.Get<CellObject>().id = _trees.GetEntitiesCount();
                    tree.Get<OnSetTreeEvent>().TypeOfTree = spawnData.Get<TempCellObjectData>().TreeName;
                    tree.Get<CellObject>().title = spawnData.Get<TempCellObjectData>().TreeName;
                    tree.Get<CellObject>().currentCycleState = spawnData.Get<TempCellObjectData>().ProductionCycleTime;
                    tree.Get<Position>().transform = newTree.transform;
                    tree.Get<CellObject>().isFullIcon = isFullIcon;
                    tree.Get<CellObject>().expAmount = tempTreeData.Get<TempCellObjectData>().ExpAmount;
                    tree.Get<CellObject>().isExpGot = false;
                    tree.Get<CellObject>().levelUpTitle = levelUpTitle;
                    tree.Get<CellObject>().isSelected = newTree.transform.GetChild(1).gameObject;
                    tree.Get<CellObject>().spawnPoint = newTree.transform.GetChild(2).gameObject.transform;
                    tree.Get<CellObject>().levelUpTitleRectPos = levelUpTitle.GetComponent<RectTransform>();
                    tree.Get<CellObject>().isFullIconRectPos = isFullIcon.GetComponent<RectTransform>();
                    tree.Get<CellObject>().level = 1;
                    tree.Get<CellObject>().lifeTimeLvlUpTitle = 2;
                    tree.Get<CellObject>().upgradePrice = 10;

                    var stateEvent01 = _world.NewEntity();
                    stateEvent01.Get<GameStateChange>().EventType = GameStateEvents.GoldSubtract;
                    stateEvent01.Get<GameStateChange>().Value = spawnData.Get<TempCellObjectData>().Price;

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
}