using Client.Scripts.Data;
using Client.Scripts.ECS.Components;
using Client.Scripts.ECS.Components.EventCoponents;
using Client.Scripts.MonoBehaviors.UI;
using ECS.Components;
using ECS.Components.EventCoponents;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Scripts.ECS.System
{
    sealed class EcsInitSystem : IEcsInitSystem
    {
        private EcsWorld _world = null;
        private readonly EcsFilter<MainCharacter> _characterfilter;
        private readonly EcsFilter<Target> _targetFilet;
        private readonly EcsFilter<InGameResources> _resources;
        private readonly EcsFilter<ExpBarComponent> _expBarFilter;
        private StaticData _staticData;
        private SceneData _sceneData;
        private UI _ui;


        public void Init()
        {
            EcsEntity player = _world.NewEntity();
            EcsEntity eventEntity = _world.NewEntity();

            #region Init GameObject

            if (_characterfilter.IsEmpty())
            {
                Object.Instantiate(_staticData.MainCharacter.Prefab, _sceneData.SpawnPoint.position,
                    Quaternion.identity);
            }

            if (_targetFilet.IsEmpty())
            {
                Object.Instantiate(_staticData.Target, _sceneData.SpawnPoint.position, Quaternion.identity);
            }

            if (!_sceneData.Tilemaps[0].activeSelf)
            {
                _sceneData.Tilemaps[0].SetActive(true);
            }

            #endregion

            player.Get<PlayerInputComponent>();
            player.Get<OnStartGame>();
            player.Get<PlayerTag>();
            player.Get<ScreenPointToRayComponent>();
            player.Get<GetRayHitComponent>();
            player.Get<GetCellPositionComponent>();
            player.Get<SetTreeComponent>();
            player.Get<ExtendLevelComponent>();
            player.Get<OnLevelExtend>();
            player.Get<GetCellComponent>();
            player.Get<NtpComponent>();
            player.Get<Target>();
            player.Get<ExpBarComponent>();
            player.Get<GetTreePositionComponent>();

            eventEntity.Get<EventEntityTag>();
        }
    }

    internal struct EventEntityTag
    {
        
    }
}