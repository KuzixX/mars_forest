using System;
using Client.Scripts.Data;
using Client.Scripts.ECS_Feature_rebuild.Interaction_Feature.Component;
using Client.Scripts.ECS_Feature.Robot;
using Client.Scripts.ECS.Components;
using ECS.Components;
using ECS.Components.EventCoponents;
using Leopotam.Ecs;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Client.Scripts.ECS_Feature_rebuild.Robot
{
    internal class Robot : IEcsRunSystem, IEcsInitSystem
    {
        private readonly EcsFilter<Position, RobotComponent> _mainCharacterFilter;
        private readonly EcsFilter<Position, Target> _filter;
        private readonly EcsFilter<OnStartGame> _eventFilter;
        private readonly StaticData _staticData;
        private readonly SceneData _sceneData;
        private readonly EcsWorld _world;

        public void Init()
        {
            var spawnPosition = _sceneData.SpawnPoint.position;
            Object.Instantiate(_staticData.MainCharacter.Prefab, spawnPosition, Quaternion.identity);
            Object.Instantiate(_staticData.Target, spawnPosition, Quaternion.identity);
            
            EcsEntity robotEntity = _world.NewEntity();

            robotEntity.Get<OnStartGame>();
            robotEntity.Get<PlayerTag>();
            //robotEntity.Get<ExtendLevelComponent>();
            robotEntity.Get<OnLevelExtend>();
            robotEntity.Get<Target>();
            //robotEntity.Get<ExpBarComponent>();
            //eventEntity.Get<EventEntityTag>();
        }
        
        public void Run()
        {
            if (!_eventFilter.IsEmpty())
            {
                ref var variables = ref _mainCharacterFilter.Get2(0);
                ref var target = ref _filter.Get1(0);
                ref var entity = ref _eventFilter.GetEntity(0);
                // initialize vatiables
                var position = target.transform.position;
                variables.xp = position.x;
                variables.zd = position.z;
                variables.y = position.x;
                variables.y00 = position.z;
                variables.yd = 0;
                variables.yd00 = 0;
                variables.xd = 0;
                variables.zd = 0;

                variables.k1 = variables.z / (MathF.PI * variables.f);
                variables.k2 = ((2 * Mathf.PI * variables.f) * (2 * Mathf.PI * variables.f));
                variables.k3 = variables.r * variables.z / (2 * Mathf.PI * variables.f);
                entity.Del<OnStartGame>();
            }

            foreach (var index in _filter)
            {
                ref var mainCharacter = ref _mainCharacterFilter.Get1(0);
                ref var targetPos = ref _filter.Get1(index);
                ref var var = ref _mainCharacterFilter.Get2(0);

                // Calculate deltas
                var position1 = mainCharacter.transform.position;
                var.deltaValueZ = position1.z - var.lastFrameValueZ;
                var.deltaValueX = position1.x - var.lastFrameValueX;
                var.lastFrameValueZ = position1.z;
                var.lastFrameValueX = position1.x;

                // Look the target at the Main character
                if (Vector3.Distance(mainCharacter.transform.position, targetPos.transform.position) > 1)
                    targetPos.transform.LookAt(mainCharacter.transform.position);
                
                // Rortate the Main Character to the target
                mainCharacter.transform.rotation = Quaternion.Euler(var.deltaValueZ * _staticData.MainCharacter.Speed,
                    targetPos.transform.eulerAngles.y, var.deltaValueX * _staticData.MainCharacter.Speed);

                // Interpolate position
                if (var.xd == 0)
                {
                    var position = targetPos.transform.position;
                    var.xd = (position.x - var.xp) / var.T;
                    var.xp = position.x;
                }

                var.y += var.T * var.yd;
                var.yd += var.T * (targetPos.transform.position.x + var.k3 * var.xd - var.y -
                                   var.k1 * var.yd) / var.k2;

                if (var.zd == 0)
                {
                    var position = targetPos.transform.position;
                    var.zd = (position.z - var.zp) / var.T;
                    var.zp = position.z;
                }

                var.y00 += var.T * var.yd00;
                var.yd00 += var.T * (targetPos.transform.position.z + var.k3 * var.zd - var.y00 -
                                     var.k1 * var.yd00) / var.k2;
                
                // Add calculations
                mainCharacter.transform.position =
                    new Vector3(var.y, mainCharacter.transform.position.y, var.y00);
            }
        }
    }
}