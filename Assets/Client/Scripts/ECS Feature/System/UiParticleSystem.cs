using System;
using Client.Scripts.Data;
using Client.Scripts.ECS.Components;
using Client.Scripts.MonoBehaviors.UI;
using Leopotam.Ecs;
using Leopotam.Ecs.Ui.Components;

namespace ECS.System
{
    sealed class UiParticleSystem : IEcsRunSystem
    {
        private UI _ui;
        private readonly EcsFilter<CellObject> _trees;
        private readonly StaticData _staticData;
        private readonly EcsFilter<EcsUiDownEvent> _downEvent;
        private readonly EcsFilter<EcsUiUpEvent> _upEvent;

        public void Run()
        {
            foreach (var index in _trees)
            {
                ref var upData = ref _upEvent.Get1(0);
                ref var downData = ref _downEvent.Get1(0);
                ref var tree = ref _trees.Get1(index);
                
            }
        }
    }
}