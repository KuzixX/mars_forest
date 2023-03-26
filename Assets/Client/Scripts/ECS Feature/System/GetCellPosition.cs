using Client.Scripts.ECS.Components;
using Leopotam.Ecs;

namespace Client.Scripts.ECS.System
{
    public class GetCellPosition : IEcsRunSystem
    {
        private readonly EcsFilter<TouchEvent> _eventFilter;
        private readonly EcsFilter<GetRayHitComponent, GetCellPositionComponent> _filter;

        public void Run()
        {
            foreach (var index in _filter)
            {
                if (_eventFilter.IsEmpty()) return;

                ref var rayInfo = ref _filter.Get1(index);
                ref var cell = ref _filter.Get2(index);
                if (rayInfo.RayInfo.collider != null && rayInfo.RayInfo.collider.gameObject.layer == 3)
                {
                    cell.CellPos = rayInfo.RayInfo.collider.gameObject.transform.position;
                }
            }
        }
    }
}