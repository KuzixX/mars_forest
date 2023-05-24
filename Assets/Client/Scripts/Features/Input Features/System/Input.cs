using Client.Scripts.ECS_Feature.Input_Features.Component;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Scripts.ECS_Feature.Input_Features.System
{
    sealed class Input : IEcsRunSystem, IEcsInitSystem
    {
        private EcsWorld _world;
        private readonly InputControls _inputControls = new();
        private readonly EcsFilter<InputComponent> _input;
        public void Init()
        {
            _world.NewEntity().Get<InputComponent>();
            _inputControls.Enable();
        }

        public void Run()
        {
            ref var input = ref _input.Get1(0);

            input.IsTap = _inputControls.Player.PressTouch.triggered;
            input.ScreenPoint = _inputControls.Player.TouchPosition_00.ReadValue<Vector2>();

            input.TouchPosition00 = _inputControls.Player.TouchPosition_00.ReadValue<Vector2>();
            input.TouchPosition01 = _inputControls.Player.TouchPosition_01.ReadValue<Vector2>();
            input.TouchDelta00 = _inputControls.Player.TouchDelta_00.ReadValue<Vector2>();
            input.TouchDelta01 = _inputControls.Player.TouchDelta_01.ReadValue<Vector2>();

            input.PrimaryDelta = _inputControls.Player.PrimaryDelta.ReadValue<Vector2>();
            input.TouchPosition00IsTriggered = _inputControls.Player.TouchPosition_00.triggered;
            input.PressTouch = _inputControls.Player.PressTouch.triggered;
        }
    }
}