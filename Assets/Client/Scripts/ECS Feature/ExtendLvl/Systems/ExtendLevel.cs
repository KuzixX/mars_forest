using Client.Scripts.ECS_Feature.Common_Сomponents;
using Client.Scripts.ECS_Feature.ExtendLvl.Components;
using Client.Scripts.Models;
using Leopotam.Ecs;

namespace Client.Scripts.ECS_Feature.ExtendLvl.Systems
{
    sealed class ExtendLevel : IEcsRunSystem, IEcsInitSystem
    {
        private readonly EcsFilter<ExtendLevelComponent> _filter;
        private readonly EcsFilter<Cell> _cellFilter;
        private readonly EcsFilter<CellObject> _treeFilter;
        private SceneData _sceneData;
        private EcsWorld _world;

        public void Init()
        {
            var levelControlData = _world.NewEntity();
            levelControlData.Get<ExtendLevelComponent>();
        }
        
        public void Run()
        {
            ref var currentLevel = ref _filter.Get1(0);
            var amountOfTile = _cellFilter.GetEntitiesCount();
            var amountOfTree = _treeFilter.GetEntitiesCount();

            if (currentLevel.CurrentLevel == _sceneData.Tilemaps.Length) return;
            if (amountOfTile - 1 > amountOfTree) return;
            _sceneData.Tilemaps[currentLevel.CurrentLevel].SetActive(true);
            currentLevel.CurrentLevel++;
        }
    }
}