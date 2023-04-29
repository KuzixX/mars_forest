using Client.Scripts.ECS_Feature.Common_Сomponents;
using Client.Scripts.ECS_Feature.Common_Сomponents.Tags;
using Client.Scripts.Models;
using Client.Scripts.Services;
using Leopotam.Ecs;

namespace Client.Scripts.ECS_Feature.ECS_Feature_old.UI.System
{
    internal class SetFullIcon : IEcsRunSystem
    {
        private readonly EcsFilter<CellObject, IsFull> _fullTree;
        private readonly EcsFilter<CellObject>.Exclude<IsFull> _tree;
        private StaticData _staticData;
        private SceneData _sceneData;
        private Scripts.UI.UI _ui;

        public void Run()
        {
            foreach (var index in _fullTree)
            {
                ref var fullTree = ref _fullTree.GetEntity(index);

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