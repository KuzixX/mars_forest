using Client.Scripts.Data;
using Client.Scripts.ECS.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Scripts.ECS.System
{
    sealed class ScreenPointToRaySystem : IEcsRunSystem
    {
        private readonly EcsFilter<TouchEvent> _eventFilter = null;
        private readonly EcsFilter<Lock> _lock;
        private readonly EcsFilter<ScreenPointToRayComponent, PlayerInputComponent> _filter;
        private SceneData _sceneData;

        public void Run()
        {
            ref var ray = ref _filter.Get1(0);
            ref var input = ref _filter.Get2(0);
            if (!_eventFilter.IsEmpty() & _lock.IsEmpty())
            {
                
                ray.Ray = _sceneData.MainCamera.ScreenPointToRay(input.ScreenPoint);
            }

            ray.CenterRay = _sceneData.MainCamera.ScreenPointToRay(new Vector2(Screen.width/2, Screen.height/2));
        }
    }
}