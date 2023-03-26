using Client.Scripts.ECS.Components;
using ECS;
using Leopotam.Ecs;

namespace Client.Scripts.ECS.System
{
    internal class GetTreePosition : IEcsRunSystem
    {
        private readonly EcsFilter<TouchEvent> _eventFilter;
        private readonly EcsFilter<GetRayHitComponent, GetTreePositionComponent> _filter;

        public void Run()
        {
            foreach (var index in _filter)
            {
                if (!_eventFilter.IsEmpty())
                {
                    ref var rayInfo = ref _filter.Get1(0);
                    ref var tree = ref _filter.GetEntity(index);
                    if (rayInfo.RayInfo.collider != null && rayInfo.RayInfo.collider.gameObject.layer == 7)
                    {
                        tree.Get<GetTreePositionComponent>().TreePos = rayInfo.RayInfo.collider.gameObject.transform.position;
                    }
                }
            }
        }
    }
}