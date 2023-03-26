using Client.Scripts.ECS.Components;
using ECS.System;
using Leopotam.Ecs;

namespace Client.Scripts.ECS.System
{
    sealed class SetTargetSystem : IEcsRunSystem
    {
        private readonly EcsFilter<GetCellPositionComponent> _filter;
        private readonly EcsFilter<Position, Target> _targetFilter;
        private readonly EcsFilter<Lock> _lock;

        public void Run()
        {
            if (_lock.IsEmpty())
            {
                ref var ray = ref _filter.GetEntity(0);
                foreach (var index in _targetFilter)
                {
                    ref var target = ref _targetFilter.Get1(index);
                    target.transform.position = ray.Get<GetCellPositionComponent>().CellPos;
                } 
            }
            
        }
    }
}