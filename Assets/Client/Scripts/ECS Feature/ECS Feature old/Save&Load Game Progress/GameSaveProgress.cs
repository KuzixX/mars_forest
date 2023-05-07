using Client.Scripts.ECS_Feature.Common_Сomponents;
using Client.Scripts.ECS_Feature.ECS_Feature_old.EventCoponents;
using Client.Scripts.ECS_Feature.ExtendLvl;
using Client.Scripts.ECS_Feature.Resources_Generation.Component;
using Client.Scripts.Services;
using Leopotam.Ecs;

namespace Client.Scripts.ECS_Feature.ECS_Feature_old.Save_Load_Game_Progress
{
    internal class GameSaveProgress : IEcsRunSystem
    {
        private SqlLiteDB _sqlLiteDB;
        private readonly EcsFilter<CellObject> _cellObject;
        private readonly EcsFilter<GameState> _resources;
        private readonly EcsFilter<OnSetTreeEvent> _onSetCellObject;
        private readonly EcsFilter<ExtendLevelComponent> _gameLevel;

        public void Run()
        {
            ref var resources = ref _resources.Get1(0);
            ref var currentLevel = ref _gameLevel.Get1(0);
            
            // Update cell objects on LocalDB
            if (!_onSetCellObject.IsEmpty())
            {
                ref var cellObject = ref _cellObject.GetEntity(_cellObject.GetEntitiesCount() - 1);
                
                _sqlLiteDB.SaveCellObjectData("WorldElements", cellObject.Get<CellObject>().id,
                    cellObject.Get<CellObject>().title, cellObject.Get<CellObject>().level,
                    cellObject.Get<CellObject>().treePrefab.transform.position);
            }

            if (currentLevel.CurrentLevel != currentLevel.PreviousLevel)
            {
                currentLevel.PreviousLevel = currentLevel.CurrentLevel;
                
                _sqlLiteDB.SaveResData("InGameResources", resources.gold, resources.experience, resources.diamonds, currentLevel.CurrentLevel);
            }
            
            if (resources.gold != resources.tempGold)
            {
                resources.tempGold = resources.gold;
                
                _sqlLiteDB.SaveResData("InGameResources", resources.gold, resources.experience, resources.diamonds, currentLevel.CurrentLevel);
            }
            
            if (resources.experience != resources.tempExperience)
            {
                resources.tempExperience = resources.experience;
                _sqlLiteDB.SaveResData("InGameResources", resources.gold, resources.experience, resources.diamonds, currentLevel.CurrentLevel);
            }
            
            if (resources.diamonds != resources.tempDiamonds)
            {
                resources.tempDiamonds = resources.diamonds;
                _sqlLiteDB.SaveResData("InGameResources", resources.gold, resources.experience, resources.diamonds, currentLevel.CurrentLevel);
            }
        }
    }
}