using Client.Scripts.ECS.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Scripts.ECS.System
{
    internal class GetRayHitSystem : IEcsRunSystem
    {
        private readonly EcsFilter<TouchEvent> _eventFilter = null;
        private readonly EcsFilter<ScreenPointToRayComponent, GetRayHitComponent> _filter;


        public void Run()
        {
            ref var ray = ref _filter.Get1(0);
            ref var hit = ref _filter.Get2(0);
            if (!_eventFilter.IsEmpty())
            {
                Physics.Raycast(ray.Ray, out hit.RayInfo);
            }
            Physics.Raycast(ray.CenterRay, out hit.CenterRayInfo);
        }
    }
}