using Client.Scripts.ECS.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Scripts.ECS.System
{
    sealed class PlayerInputSystem : IEcsRunSystem
    {
        private InputControls _inputControls;
        private readonly EcsFilter<PlayerInputComponent> _filter;

        public void Run()
        {
            if (_inputControls.Player.PressTouch.triggered)
            {
                ref var input = ref _filter.Get1(0);
                ref var entity = ref _filter.GetEntity(0);
                
                input.IsTap = _inputControls.Player.PressTouch.triggered;
                input.ScreenPoint = _inputControls.Player.TouchPosition_00.ReadValue<Vector2>();
                
                if (input.IsTap) entity.Get<TouchEvent>();
            }
        }
    }
}