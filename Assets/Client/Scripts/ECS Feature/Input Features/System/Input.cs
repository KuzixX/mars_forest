using Client.Scripts.ECS_Feature.Input_Features.Component;
using ETouch = UnityEngine.InputSystem.EnhancedTouch;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Scripts.ECS_Feature.Input_Features.System
{
    sealed class Input : IEcsRunSystem, IEcsInitSystem
    {
        private EcsWorld _world;
        private InputControls _inputControls;
        private readonly EcsFilter<InputComponent> _input;
        public void Init()
        {
            _world.NewEntity().Get<InputComponent>();
        }

        public void Run()
        {
            ref var input = ref _input.Get1(0);
            
            if (_inputControls.Player.PressTouch.triggered)
            {
                input.IsTap = _inputControls.Player.PressTouch.triggered;
                input.ScreenPoint = _inputControls.Player.TouchPosition_00.ReadValue<Vector2>();
            }
            else
            {
                input.IsTap = false;
            }

            if (ETouch.Touch.activeFingers.Count == 3)
            {
                input.TouchPosition00 = _inputControls.Player.TouchPosition_00.ReadValue<Vector2>();
                input.TouchPosition01 = _inputControls.Player.TouchPosition_01.ReadValue<Vector2>();
                input.TouchDelta00 = _inputControls.Player.TouchDelta_00.ReadValue<Vector2>();
                input.TouchDelta01 = _inputControls.Player.TouchDelta_01.ReadValue<Vector2>();
            }


            input.PrimaryDelta = (Vector3)_inputControls.Player.PrimaryDelta.ReadValue<Vector2>();
            input.TouchPosition00IsTriggered = _inputControls.Player.TouchPosition_00.triggered;
            input.PressTouch = _inputControls.Player.PressTouch.triggered;
        }
    }
}