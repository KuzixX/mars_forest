using Client.Scripts.Data;
using Client.Scripts.ECS_Feature.Components;
using Client.Scripts.ECS_Feature.Init;
using Client.Scripts.ECS.Components;
using Client.Scripts.ECS.Components.EventCoponents;
using Client.Scripts.MonoBehaviors;
using Client.Scripts.MonoBehaviors.UI;
using ECS.Components.EventCoponents;
using Firebase.Auth;
using Firebase.Firestore;
using Leopotam.Ecs;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Client.Scripts.ECS_Feature.SpawnCellObject.System
{
    internal class SpawnCellObjectSystem : IEcsRunSystem
    {
        private UI _ui;
        private EcsWorld _world;
        private readonly SceneData _sceneData;
        private readonly StaticData _staticData;
        private readonly EcsFilter<FirebaseComponent> _db;
        private readonly EcsFilter<Cell, Position> _cells;
        private readonly EcsFilter<InGameResources> _resources;
        private readonly EcsFilter<SpawnCellObjectData> _tempSpawnData;
        private readonly EcsFilter<GetCellPositionComponent> _hitCellCenter;
        private readonly EcsFilter<CellObject> _trees;
        private readonly EcsFilter<EventEntityTag> _eventEntity;

        public void Run()
        {
            if (_tempSpawnData.IsEmpty()) return;

            foreach (var index in _cells)
            {
                ref var cell = ref _cells.GetEntity(index);
                ref var resources = ref _resources.Get1(0);
                ref var cellPosition = ref _hitCellCenter.Get1(0);
                ref var spawnData = ref _tempSpawnData.GetEntity(0);
                ref var db = ref _db.Get1(0);
                ref var eventEntity = ref _eventEntity.GetEntity(0);

                if (!_tempSpawnData.IsEmpty() & cell.Get<Position>().transform.position == cellPosition.CellPos &&
                    !cell.Has<TakenCell>())
                {
                    // Instantiate firebase
                    db.Firestore = FirebaseFirestore.DefaultInstance;
                    db.Auth = FirebaseAuth.DefaultInstance;

                    // Instantiate tree prefab
                    var newTree = Object.Instantiate(spawnData.Get<SpawnCellObjectData>().TreePrefab,
                        cell.Get<Position>().transform.position,
                        Quaternion.identity);
                    var isFullIcon = Object.Instantiate(_staticData.GoldSprite, _ui.mainScreen.transform);
                    var levelUpTitile = Object.Instantiate(_staticData.LevelUpTitle, _ui.mainScreen.transform);

                    // Create tree entity
                    var tree = _world.NewEntity();
                    tree.Get<CellObject>().treePrefab = newTree;
                    tree.Get<CellObject>().id = _trees.GetEntitiesCount();
                    tree.Get<OnSetTreeEvent>().TypeOfTree = spawnData.Get<SpawnCellObjectData>().TreeName;
                    tree.Get<CellObject>().title = spawnData.Get<SpawnCellObjectData>().TreeName;
                    tree.Get<OnExpEvent>().ExpAmount = spawnData.Get<SpawnCellObjectData>().ExpAmount;
                    tree.Get<CellObject>().currentCycleState = spawnData.Get<SpawnCellObjectData>().ProductionCycleTime;
                    tree.Get<Position>().transform = newTree.transform;
                    tree.Get<CellObject>().isFullIcon = isFullIcon;
                    tree.Get<CellObject>().levelUpTitle = levelUpTitile;
                    tree.Get<CellObject>().isSelected = newTree.transform.GetChild(1).gameObject;
                    tree.Get<CellObject>().spawnPoint = newTree.transform.GetChild(2).gameObject.transform;
                    tree.Get<CellObject>().levelUpTitleRectPos = levelUpTitile.GetComponent<RectTransform>();
                    tree.Get<CellObject>().isFullIconRectPos = isFullIcon.GetComponent<RectTransform>();
                    tree.Get<CellObject>().level = 1;
                    tree.Get<CellObject>().lifeTimeLvlUpTitle = 2;
                    tree.Get<CellObject>().upgradePrice = 10;
                    _ui.expUIParticleSystem.GetComponent<RectTransform>().anchoredPosition = WorldToScreenConvertor.WorldToCanvasSpace(_ui.mainCanvasRect, _sceneData.MainCamera, tree.Get<CellObject>().spawnPoint.position);
                    _ui.expUIParticleSystem.Play();

                    // Set resources data
                    resources.gold -= spawnData.Get<SpawnCellObjectData>().Price; 

                    eventEntity.Get<ChangeUI>().EventDescription = "ResBar";

                    // Quest event
                    tree.Get<QuestEvent>().QuestType = "Tree";
                    tree.Get<QuestEvent>().Value = resources.treeAmount;

                    // Take cell
                    cell.Get<TakenCell>();

                    // Delete temp data
                    spawnData.Del<SpawnCellObjectData>();
                }
            }
        }
    }
}