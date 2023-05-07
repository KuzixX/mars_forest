using Client.Scripts.ECS_Feature.Common_Сomponents;
using Client.Scripts.Models;
using Leopotam.Ecs;

namespace Client.Scripts.ECS_Feature.ExtendLvl
{
    sealed class ExtendLevel : IEcsRunSystem
    {
        private readonly EcsFilter<ExtendLevelComponent> _filter;
        private readonly EcsFilter<Cell> _cellFilter;
        private readonly EcsFilter<CellObject> _treeFilter;
        private SceneData _sceneData;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var currentLevel = ref _filter.Get1(i);

                for (int j = currentLevel.CurrentLevel; j < _sceneData.Tilemaps.Length;)
                {
                    int amountOfTile = _cellFilter.GetEntitiesCount();
                    int amountOfTree = _treeFilter.GetEntitiesCount();

                    if (amountOfTile - 1 <= amountOfTree && currentLevel.CurrentLevel <= _sceneData.Tilemaps.Length + 1)
                    {
                        _sceneData.Tilemaps[j + 1].SetActive(true);
                        currentLevel.CurrentLevel++;
                        break;
                    }
                    else break;
                }
            }
        }
    }
}