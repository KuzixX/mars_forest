/*using System.Data;
using Client.Scripts.ECS_Feature.Common_Сomponents;
using Client.Scripts.ECS_Feature.Common_Сomponents.Tags;
using Client.Scripts.ECS_Feature.ECS_Feature_old.EventCoponents;
using Client.Scripts.ECS_Feature.ECS_Feature_old.UI.Component;
using Client.Scripts.ECS_Feature.ExtendLvl;
using Client.Scripts.ECS_Feature.ExtendLvl.Components;
using Client.Scripts.ECS_Feature.Resources_Generation.Component;
using Client.Scripts.Models;
using Client.Scripts.Services;
using Leopotam.Ecs;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Client.Scripts.ECS_Feature.ECS_Feature_old.Save_Load_Game_Progress
{
    internal class LoadGameProgress : IEcsInitSystem
    {
        private SqlLiteDB _sqlLiteDB;
        private readonly EcsWorld _world;
        private readonly StaticData _staticData;
        private readonly SceneData _sceneData;
        private readonly EcsFilter<Cell> _cells;
        private readonly EcsFilter<GameState> _resources;
        private readonly EcsFilter<EventEntityTag> _eventEntity;
        private readonly EcsFilter<ExtendLevelComponent> _level;
        private readonly Scripts.UI.UI _ui;

        public void Init()
        {
            // Загружаем в игру внутреигровые ресурсы с БД
            DataTable inGameResourcesData = _sqlLiteDB.GetTable("SELECT * FROM InGameResources");
            ref var resources = ref _resources.Get1(0);
            ref var eventEntity = ref _eventEntity.GetEntity(0);
            ref var currentLevel = ref _level.Get1(0).CurrentLevel;

            // Устанавливаем значения ресурсов с БД </summary>            
            resources.gold = int.Parse(inGameResourcesData.Rows[0][0].ToString());
            resources.experience = int.Parse(inGameResourcesData.Rows[0][1].ToString());
            resources.diamonds = int.Parse(inGameResourcesData.Rows[0][2].ToString());

            // Запускаем события обновленяи UI
            eventEntity.Get<ChangeUI>().EventDescription = "FullUI";
            
            // Устанавливаем уровень игры
            _sceneData.Tilemaps[currentLevel].SetActive(true);
            
            // Загружаем в игру игровые объекты
            if (_sqlLiteDB.GetRowCount("WorldElements") == 0) return;
            
            DataTable worldElementsData = _sqlLiteDB.GetTable("SELECT PosX, PosY, PosZ, Title, ID FROM WorldElements");
            
            for (int i = 0; i < _sqlLiteDB.GetRowCount("WorldElements"); i++)
            {
                Vector3 pos = new Vector3(float.Parse(worldElementsData.Rows[i][0].ToString()), float.Parse(worldElementsData.Rows[i][1].ToString()), float.Parse(worldElementsData.Rows[i][2].ToString()));
                string title = worldElementsData.Rows[i][3].ToString();
                int id = int.Parse(worldElementsData.Rows[i][4].ToString());

                for (int j = 0; j < _staticData.TreesData.Length; j++)
                {
                    if (title == _staticData.TreesData[j].Title)
                    {
                        var cellObject = Object.Instantiate(_staticData.TreesData[j].Prefab, pos, Quaternion.identity);
                        var isFullIcon = Object.Instantiate(_staticData.GoldSprite, _ui.mainScreen.transform);
                        var levelUpTitile = Object.Instantiate(_staticData.LevelUpTitle, _ui.mainScreen.transform);

                        var tree = _world.NewEntity();
                        tree.Get<CellObject>().treePrefab = cellObject;
                        tree.Get<CellObject>().id = id;
                        tree.Get<OnSetTreeEvent>().TypeOfTree = title;
                        tree.Get<CellObject>().title = title;
                        tree.Get<OnExpEvent>().ExpAmount = 2;
                        tree.Get<CellObject>().currentCycleState = 2;
                        tree.Get<Position>().transform = cellObject.transform;
                        tree.Get<CellObject>().isFullIcon = isFullIcon;
                        tree.Get<CellObject>().levelUpTitle = levelUpTitile;
                        tree.Get<CellObject>().isSelected = cellObject.transform.GetChild(1).gameObject;
                        tree.Get<CellObject>().spawnPoint = cellObject.transform.GetChild(2).gameObject.transform;
                        tree.Get<CellObject>().levelUpTitleRectPos = levelUpTitile.GetComponent<RectTransform>();
                        tree.Get<CellObject>().isFullIconRectPos = isFullIcon.GetComponent<RectTransform>();
                        tree.Get<CellObject>().level = 1;
                        tree.Get<CellObject>().lifeTimeLvlUpTitle = 2;
                        tree.Get<CellObject>().upgradePrice = 10;

                        foreach (var index in _cells)
                        {
                            ref var cell = ref _cells.GetEntity(index);

                            if (cell.Get<Position>().transform.position == cellObject.transform.position)
                            {
                                cell.Get<TakenCell>();
                            }
                        }
                    }
                }
            }
        }
    }
}*/