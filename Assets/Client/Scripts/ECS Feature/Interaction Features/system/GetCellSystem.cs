using Client.Scripts.ECS_Feature.Interaction_Features.Component;
using Client.Scripts.ECS.Components;
using Leopotam.Ecs;

namespace Client.Scripts.ECS.System
{
    public class GetCellSystem : IEcsRunSystem
    {
        private readonly EcsFilter<TouchEvent> _eventFilter;
        private readonly EcsFilter<GetRayHitComponent, GetCellComponent> _filter;

        public void Run()
        {
            if (_eventFilter.IsEmpty()) return;

            foreach (var index in _filter)
            {
                ref var rayInfo = ref _filter.Get1(index);
                ref var getCell = ref _filter.Get2(index);
                if (rayInfo.RayInfo.collider != null && rayInfo.RayInfo.collider.gameObject.layer == 3)
                {
                    getCell.Cell = rayInfo.RayInfo.collider.gameObject;
                }
            }
        }
    }
}