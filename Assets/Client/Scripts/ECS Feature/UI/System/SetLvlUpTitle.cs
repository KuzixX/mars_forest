using Client.Scripts.Data;
using Client.Scripts.ECS.Components;
using Client.Scripts.MonoBehaviors;
using Client.Scripts.MonoBehaviors.UI;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Scripts.ECS.System
{
    internal class SetLvlUpTitle : IEcsRunSystem
    {
        private readonly EcsFilter<CellObject> _trees;
        private readonly SceneData _sceneData;
        private readonly UI _ui;
        public void Run()
        { 
            foreach (var index in _trees)
            {
                ref var tree = ref _trees.GetEntity(index);
                var offset = _trees.Get1(index).spawnPoint;

                if (tree.Get<CellObject>().levelUpTitle.gameObject.activeSelf)
                {
                    tree.Get<CellObject>().levelUpTitleRectPos.anchoredPosition = WorldToScreenConvertor.WorldToCanvasSpace(_ui.mainCanvasRect, _sceneData.MainCamera, offset.position);
                    tree.Get<CellObject>().lifeTimeLvlUpTitle -= Time.deltaTime;
                }

                if (tree.Get<CellObject>().lifeTimeLvlUpTitle <= 0)
                {
                    tree.Get<CellObject>().lifeTimeLvlUpTitle = 2;
                    tree.Get<CellObject>().levelUpTitle.gameObject.SetActive(false);
                }
            }
        }
    }
}