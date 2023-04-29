using Client.Scripts.ECS_Feature.Camera_Control.Component;
using Client.Scripts.ECS_Feature.Common_Сomponents;
using Client.Scripts.ECS_Feature.Common_Сomponents.Tags;
using Client.Scripts.ECS_Feature.Input_Features.Component;
using Client.Scripts.ECS_Feature.Interaction_Feature.Component;
using Client.Scripts.Models;
using Leopotam.Ecs;
using UnityEngine;
using ETouch = UnityEngine.InputSystem.EnhancedTouch;

namespace Client.Scripts.ECS_Feature.Camera_Control.System
{
    internal class CameraControl : IEcsRunSystem, IEcsInitSystem
    {
        private readonly EcsWorld _world;
        private readonly SceneData _sceneData;
        private readonly StaticData _staticData;
        private readonly EcsFilter<InteractionData> _interaction; 
        private readonly EcsFilter<CameraComponent, Position, CameraTag> _camera;
        private readonly EcsFilter<InputComponent> _input;
        private readonly EcsFilter<Lock> _lockCameraFilter;
        
        public void Init()
        {
            var camera = _world.NewEntity();
            camera.Get<CameraTag>();
            camera.Get<CameraComponent>().ZoomSpeed = 0.01f;
            camera.Get<CameraComponent>().ZoomMin = 1;
            camera.Get<CameraComponent>().ZoomMax = 5;
            camera.Get<CameraComponent>().Curve = new AnimationCurve();
            camera.Get<CameraComponent>().DragSpeed = 6;
            camera.Get<CameraComponent>().Timer = 1;
            camera.Get<Position>().transform =_sceneData.MainCamera.transform;
        }
        
        public void Run()
        {
            ref var cameraData = ref _camera.Get1(0);
            ref var cameraPos = ref _camera.Get2(0);
            ref var input = ref _input.Get1(0);
            ref var hitPoint = ref _interaction.Get1(0);

            // Zoom camera
            if (ETouch.Touch.activeFingers.Count == 3)
            {
                cameraData.TouchZeroPrevious = input.TouchPosition00 - input.TouchDelta00;
                cameraData.TouchOnePrevious = input.TouchPosition01 - input.TouchDelta01;

                cameraData.PreviousMag = (cameraData.TouchZeroPrevious - cameraData.TouchOnePrevious).magnitude;
                cameraData.CurrentMag = (input.TouchPosition00 - input.TouchPosition01).magnitude;

                cameraData.Difference = cameraData.CurrentMag - cameraData.PreviousMag;

                cameraData.OrthographicSize = Mathf.Clamp(cameraData.OrthographicSize - cameraData.Difference * cameraData.ZoomSpeed, cameraData.ZoomMin, cameraData.ZoomMax);
                _sceneData.MainCamera.orthographicSize = cameraData.OrthographicSize;
            }


            // Move camera
            // Логика выполняется при тапе
                 if (input.PressTouch & _lockCameraFilter.IsEmpty())
                 {
                     cameraData.Distance = Vector3.Distance(
                         _sceneData.MainCamera.ScreenToWorldPoint(input.TouchPosition00),
                         _sceneData.MainCamera.ScreenToWorldPoint(input.TouchPosition01));
                 }

            
                 // количество тачей снизит на один
                 if (input.TouchPosition00IsTriggered &&
                     ETouch.Touch.activeFingers.Count < 3 & _lockCameraFilter.IsEmpty())
                 {
                     cameraData.CurrentDistance = Vector3.Distance(
                         _sceneData.MainCamera.ScreenToWorldPoint(input.TouchPosition00),
                         _sceneData.MainCamera.ScreenToWorldPoint(input.TouchPosition01));
                     cameraData.Delta = input.PrimaryDelta * -0.01f;
                     cameraPos.transform.position += cameraData.Delta * (Time.deltaTime * cameraData.DragSpeed);
                     cameraData.Timer = 0;
                 }
                 else
                 {
                     if (cameraData.Timer < 1)
                     {
                         cameraData.Timer += Time.deltaTime;
                         cameraPos.transform.position += cameraData.Delta * (Time.deltaTime * cameraData.DragSpeed * cameraData.Curve.Evaluate(cameraData.Timer));
                         if (cameraData.Timer > 1) cameraData.Timer = 1;
                     }
                 }
                
                
                 // Border control
                 if (!hitPoint.CenterRayInfo.collider)
                 {
                     cameraData.Timer = 1;
                     cameraPos.transform.position =
                         Vector3.Lerp(cameraPos.transform.position,
                             _staticData.DefaultCamPos.transform.position, 0.01f);
                 }
        }
    }
}