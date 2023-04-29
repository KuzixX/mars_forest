using Client.Scripts.ECS_Feature.Common_Сomponents;
using Client.Scripts.Models;
using Leopotam.Ecs;
using Leopotam.Ecs.Ui.Components;

namespace Client.Scripts.ECS_Feature.ECS_Feature_old.UI.System
{
    sealed class UiParticleSystem : IEcsRunSystem
    {
        private Scripts.UI.UI _ui;
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