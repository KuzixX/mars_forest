using Client.Scripts.Data;
using Client.Scripts.ECS_Feature.Interaction_Feature.Component;
using Client.Scripts.ECS.Components;
using ECS.Components;
using ECS.Components.EventCoponents;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Scripts.ECS_Feature.Init
{
    sealed class EcsInit : IEcsInitSystem
    {
        private EcsWorld _world = null;
        private StaticData _staticData;
        private SceneData _sceneData;
        private MonoBehaviors.UI.UI _ui;


        public void Init()
        {
            EcsEntity player = _world.NewEntity();
            EcsEntity eventEntity = _world.NewEntity();
            
            player.Get<OnStartGame>();
            player.Get<PlayerTag>();
            player.Get<ExtendLevelComponent>();
            player.Get<OnLevelExtend>();
            player.Get<Target>();
            player.Get<ExpBarComponent>();

            eventEntity.Get<EventEntityTag>();
        }
    }

    internal struct EventEntityTag
    {
        
    }
}