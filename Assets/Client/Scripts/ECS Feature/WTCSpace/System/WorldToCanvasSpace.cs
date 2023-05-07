using Client.Scripts.ECS_Feature.Common_Сomponents;
using Client.Scripts.ECS_Feature.Common_Сomponents.Tags;
using Client.Scripts.Models;
using Client.Scripts.Services;
using Leopotam.Ecs;

namespace Client.Scripts.ECS_Feature.WTCSpace.System
{
    internal class WorldToCanvasSpace : IEcsRunSystem
    {
        private readonly EcsFilter<CellObject, IsFull> _fullCellObject;
        private readonly EcsFilter<CellObject>.Exclude<IsFull> _tree;
        private StaticData _staticData;
        private SceneData _sceneData;
        private Scripts.UI.UI _ui;

        public void Run()
        {
            foreach (var index in _fullCellObject)
            {
                ref var fullTree = ref _fullCellObject.GetEntity(index);
  
                fullTree.Get<CellObject>().isFullIcon.gameObject.SetActive(true);
                fullTree.Get<CellObject>().isFullIconRectPos.anchoredPosition =
                    WorldToScreenConvertor.WorldToCanvasSpace(_ui.mainCanvasRect, 
                        _sceneData.MainCamera, fullTree.Get<CellObject>().spawnPoint.position);
            }

            foreach (var index in _tree)
            {
                ref var tree = ref _tree.GetEntity(index);
                tree.Get<CellObject>().isFullIcon.gameObject.SetActive(false);
            }
        }
    }
}