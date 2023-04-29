using Client.Scripts.ECS_Feature.Common_Сomponents;
using Client.Scripts.Models;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Scripts.ECS_Feature.ExtendLevel
{
    sealed class ExtendLevel : IEcsRunSystem , IEcsInitSystem
    {
        private readonly EcsFilter<ExtendLevelComponent> _filter;
        private readonly EcsFilter<Cell> _cellFilter;
        private readonly EcsFilter<CellObject> _treeFilter;
        private SceneData _sceneData;
        private StaticData _staticData;
        private UI.UI _ui;

        public void Init()
        {
            
        }
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var currentLevel = ref _filter.Get1(i);
                ref var entity = ref _filter.GetEntity(i);

                for (int j = currentLevel.CurrentLevel; j < _sceneData.Tilemaps.Length;)
                {
                    int amountOfTile = _cellFilter.GetEntitiesCount();
                    int amountOfTree = _treeFilter.GetEntitiesCount();

                    if (amountOfTile - 1 <= amountOfTree && currentLevel.CurrentLevel <= _sceneData.Tilemaps.Length + 1)
                    {
                        _sceneData.Tilemaps[j + 1].SetActive(true);
                        currentLevel.CurrentLevel++;
                        _ui.mainScreen.gameLevelText.text = currentLevel.CurrentLevel.ToString();
                        Debug.Log("LevelUP");
                        break;
                    }
                    else break;
                }
            }
        }
    }
}