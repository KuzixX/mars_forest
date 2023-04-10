using Client.Scripts.Data;
using Client.Scripts.ECS.Components;
using Leopotam.Ecs;
using UnityEngine;
using ETouch = UnityEngine.InputSystem.EnhancedTouch;

namespace Client.Scripts.ECS_Feature.Camera_Control.System
{
    internal class CameraZoom : IEcsRunSystem
    {
        private readonly EcsFilter<MainCamera, CameraZoomComponent> _filter;
        private readonly EcsFilter<Lock> _lockCameraFilter;
        private readonly InputControls _inputControls;
        private SceneData _sceneData;

        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var camera = ref _filter.Get2(index);
                if (ETouch.Touch.activeFingers.Count == 3 & _lockCameraFilter.IsEmpty())
                {
                    Debug.Log("Zoom");
                    camera.touchZeroPrevious = _inputControls.Player.TouchPosition_00.ReadValue<Vector2>() - _inputControls.Player.TouchDelta_00.ReadValue<Vector2>();
                    camera.touchOnePrevious = _inputControls.Player.TouchPosition_01.ReadValue<Vector2>() - _inputControls.Player.TouchDelta_01.ReadValue<Vector2>();

                    camera.previousMag = (camera.touchZeroPrevious - camera.touchOnePrevious).magnitude;
                    camera.currentMag = (_inputControls.Player.TouchPosition_00.ReadValue<Vector2>() - _inputControls.Player.TouchPosition_01.ReadValue<Vector2>()).magnitude;

                    camera.difference = camera.currentMag - camera.previousMag;

                    camera.orthographicSize =
                        Mathf.Clamp(camera.orthographicSize - camera.difference * camera.zoomSpeed, camera.zoomMin, camera.zoomMax);
                    _sceneData.MainCamera.orthographicSize = camera.orthographicSize;
                }
            }
        }
    }
}