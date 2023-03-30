using Client.Scripts.Data;
using Client.Scripts.ECS.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Scripts.ECS.System
{
    internal class BorderControlSystem : IEcsRunSystem
    {
        private readonly EcsFilter<GetRayHitComponent> _hitPos;
        private readonly EcsFilter<Cell> _cells;
        private readonly EcsFilter<MainCamera> _mainCamera;
        private readonly StaticData _staticData;

        public void Run()
        {
            ref var hitPoint = ref _hitPos.Get1(0);
            ref var mainCamera = ref _mainCamera.GetEntity(0);
            if (!hitPoint.CenterRayInfo.collider)
            {
                mainCamera.Get<MoveCameraComponent>().timer = 1;
                mainCamera.Get<Position>().transform.position =
                    Vector3.Lerp(mainCamera.Get<Position>().transform.position,
                        _staticData.DefaultCamPos.transform.position, 0.01f);
            }

        }
    }
}