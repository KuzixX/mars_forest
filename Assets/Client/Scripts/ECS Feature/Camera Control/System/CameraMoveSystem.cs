using Client.Scripts.Data;
using Client.Scripts.ECS.Components;
using Client.Scripts.MonoBehaviors.UI;
using Leopotam.Ecs;
using UnityEngine;
using ETouch = UnityEngine.InputSystem.EnhancedTouch;

namespace Client.Scripts.ECS.System
{
    internal class CameraMoveSystem : IEcsRunSystem
    {
        private readonly EcsFilter<Position, MainCamera, MoveCameraComponent> _filter;
        private readonly EcsFilter<Lock> _lockCameraFilter;
        private SceneData _sceneData;
        private InputControls _inputControls;
        private UI _ui;

        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var camera = ref _filter.GetEntity(index);
                ref var cameraPos = ref _filter.Get1(index);
                
                // Логика выполняется при тапе
                if (_inputControls.Player.PressTouch.triggered & _lockCameraFilter.IsEmpty())
                {
                    camera.Get<MoveCameraComponent>().distance = Vector3.Distance(
                        _sceneData.MainCamera.ScreenToWorldPoint(_inputControls.Player.TouchPosition_00
                            .ReadValue<Vector2>()),
                        _sceneData.MainCamera.ScreenToWorldPoint(_inputControls.Player.TouchPosition_01
                            .ReadValue<Vector2>()));
                }

                // Логика выполняется, когда значение изеняется
                // количество тачей снизит на один
                if (_inputControls.Player.TouchPosition_00.triggered &&
                    ETouch.Touch.activeFingers.Count < 3 & _lockCameraFilter.IsEmpty())
                {
                    camera.Get<MoveCameraComponent>().currentDistance = Vector3.Distance(
                        _sceneData.MainCamera.ScreenToWorldPoint(_inputControls.Player.TouchPosition_00
                            .ReadValue<Vector2>()),
                        _sceneData.MainCamera.ScreenToWorldPoint(_inputControls.Player.TouchPosition_01
                            .ReadValue<Vector2>()));
                    camera.Get<MoveCameraComponent>().delta =
                        (Vector3)_inputControls.Player.PrimaryDelta.ReadValue<Vector2>() * -0.01f;
                    cameraPos.transform.position += camera.Get<MoveCameraComponent>().delta *
                                                    (Time.deltaTime * camera.Get<MoveCameraComponent>().dragSpeed);
                    camera.Get<MoveCameraComponent>().timer = 0;
                }
                else
                {
                    if (camera.Get<MoveCameraComponent>().timer < 1)
                    {
                        camera.Get<MoveCameraComponent>().timer += Time.deltaTime;
                        cameraPos.transform.position += camera.Get<MoveCameraComponent>().delta *
                                                        (Time.deltaTime * camera.Get<MoveCameraComponent>().dragSpeed *
                                                         camera.Get<MoveCameraComponent>().curve
                                                             .Evaluate(camera.Get<MoveCameraComponent>().timer));
                        if (camera.Get<MoveCameraComponent>().timer > 1) camera.Get<MoveCameraComponent>().timer = 1;
                    }
                }
            }
        }
    }
}