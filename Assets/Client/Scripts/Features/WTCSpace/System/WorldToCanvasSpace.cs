using Client.Scripts.Features.Common_Сomponents;
using Client.Scripts.Features.Common_Сomponents.Tags;
using Client.Scripts.Models;
using Client.Scripts.Protocols;
using Client.Scripts.Services.Other;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Scripts.Features.WTCSpace.System
{
    internal class WorldToCanvasSpace : IEcsRunSystem
    {
        private readonly EcsFilter<CellObject, IsFull> _fullCellObject;
        private readonly EcsFilter<CellObject>.Exclude<IsFull> _cellObjects;
        private FX _fx;
        private SceneData _sceneData;

        public void Run()
        {
            foreach (var index in _fullCellObject)
            {
                ref var fullCellObject = ref _fullCellObject.GetEntity(index);
                var anchoredPosition = WorldToScreenConvertor.WorldToCanvasSpace(_sceneData.MainCanvasRect,
                    _sceneData.MainCamera, fullCellObject.Get<CellObject>().spawnPoint.position);

                fullCellObject.Get<CellObject>().isFullIcon.gameObject.SetActive(true);
                fullCellObject.Get<CellObject>().isFullIcon.GetComponent<RectTransform>().anchoredPosition = anchoredPosition;
                _fx.goldParticleSystem.GetComponent<RectTransform>().anchoredPosition = anchoredPosition;
            }

            foreach (var index in _cellObjects)
            {
                ref var cellObject = ref _cellObjects.GetEntity(index);
                cellObject.Get<CellObject>().isFullIcon.gameObject.SetActive(false);
            }
        }
    }
}