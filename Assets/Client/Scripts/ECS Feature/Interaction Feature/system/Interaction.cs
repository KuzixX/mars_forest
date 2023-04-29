using Client.Scripts.ECS_Feature.Common_Сomponents;
using Client.Scripts.ECS_Feature.Common_Сomponents.Tags;
using Client.Scripts.ECS_Feature.Input_Features.Component;
using Client.Scripts.ECS_Feature.Interaction_Feature.Component;
using Client.Scripts.Models;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Scripts.ECS_Feature.Interaction_Feature.system
{
    internal class Interaction : IEcsRunSystem, IEcsInitSystem
    {
        private EcsWorld _world;
        private SceneData _sceneData;
        private readonly EcsFilter<Lock> _lock;
        private readonly EcsFilter<InteractionData> _filter;
        private readonly EcsFilter<InputComponent> _input;
        private readonly EcsFilter<Position, Target> _target;

        public void Init()
        {
            _world.NewEntity().Get<InteractionData>();
        }
        public void Run()
        {
            ref var input = ref _input.Get1(0);
            ref var interactionData = ref _filter.Get1(0);
            
            // Screen point to ray

            if (input.IsTap & _lock.IsEmpty())
            {
                
                interactionData.Ray = _sceneData.MainCamera.ScreenPointToRay(input.ScreenPoint);
            }

            interactionData.CenterRay = _sceneData.MainCamera.ScreenPointToRay(new Vector2(Screen.width/2, Screen.height/2));

            // Get ray hit
            if (input.IsTap)
            {
                Physics.Raycast(interactionData.Ray, out interactionData.RayInfo);
            }
            Physics.Raycast(interactionData.CenterRay, out interactionData.CenterRayInfo);
            
            // Get cell position 
            if (interactionData.RayInfo.collider != null && interactionData.RayInfo.collider.gameObject.layer == 3)
                interactionData.CellPos = interactionData.RayInfo.collider.gameObject.transform.position;
            
            // Get cell game object
            if (interactionData.RayInfo.collider != null && interactionData.RayInfo.collider.gameObject.layer == 3)
            {
                interactionData.Cell = interactionData.RayInfo.collider.gameObject;
            }
            // Get cell object position
            if (input.IsTap)
            {
                if (interactionData.RayInfo.collider != null && interactionData.RayInfo.collider.gameObject.layer == 7)
                {
                    interactionData.TreePos = interactionData.RayInfo.collider.gameObject.transform.position;
                }
            }
            // Set target
            if (_lock.IsEmpty())
            {
                ref var target = ref _target.Get1(0);
                target.transform.position = interactionData.RayInfo.point;
            }
        }
    }
}