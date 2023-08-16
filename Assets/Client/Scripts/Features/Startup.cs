using Client.Scripts.Features.Camera_Control.System;
using Client.Scripts.Features.CellObjectLevelUp.Systems;
using Client.Scripts.Features.ClearSystem.Systems;
using Client.Scripts.Features.Delivery_Lander.Systems;
using Client.Scripts.Features.Delivery_Unit.Components;
using Client.Scripts.Features.Delivery_Unit.Systems;
using Client.Scripts.Features.Experience_Bar.System;
using Client.Scripts.Features.ExtendLvl.Systems;
using Client.Scripts.Features.Interaction_Feature.system;
using Client.Scripts.Features.Pick_Gold_System.System;
using Client.Scripts.Features.Projection_Systems.System;
using Client.Scripts.Features.Resources_Generation.System;
using Client.Scripts.Features.Robot.System;
using Client.Scripts.Features.SpawnCellObject.System;
using Client.Scripts.Features.UpdGameState.Systems;
using Client.Scripts.Models;
using Client.Scripts.Protocols.Interfaces;
using Client.Scripts.Services.SQL;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;
using Zenject;
using Input = Client.Scripts.Features.Input_Features.System.Input;

namespace Client.Scripts.Features
{
    public class Startup : MonoBehaviour
    {
        private EcsWorld   _world;
        private SqlLiteDB  _sqlLiteDB;
        private EcsSystems _coreGameSystems;
        private EcsSystems _projectionSystems;
        private EcsSystems _clearSystems;

        [Header("Data")]
        public StaticData staticData;
        public SceneData  sceneData;

        [Inject] private IGoldProtocol            _goldProtocol;
        [Inject] private IExperienceProtocol      _experienceProtocol;
        [Inject] private IDiamondsProtocol        _diamondsProtocol;
        [Inject] private ICellObjectCountProtocol _cellObjectCount;
        [Inject] private IGameLevelProtocol       _gameLevelProtocol;
        [Inject] private IExperienceBarProtocol   _experienceBarProtocol;
        [Inject] private IQuestDataProtocol       _questDataProtocol;

        private void Start()
        {
            _world = new EcsWorld();
            _coreGameSystems = new EcsSystems(_world);
            _projectionSystems = new EcsSystems(_world);
            _clearSystems = new EcsSystems(_world);
            _sqlLiteDB = gameObject.AddComponent<SqlLiteDB>();
            Application.targetFrameRate = 60;

#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_coreGameSystems);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_projectionSystems);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_clearSystems);
#endif
            
            _coreGameSystems.ConvertScene()
                .Add(new DebugSystem())
                .Add(new Input())
                .Add(new Interaction())
                .Add(new SpawnCellObjects())
                .Add(new CellObjectLvlUp())
                .Add(new ExtendLevel())
                .Add(new ResourcesGeneration())
                .Add(new DeliveryLander())
                //.Add(new PickResources())
                .Add(new ExtendLevel())
                //.Add(new HomeRobot())
                .Add(new UnitMovement())
                .Add(new CameraControl())
                //.Add(new WorldToCanvasSpace())
                .Add(new UpdateGameState())
                .Add(new ExperienceBar())
                .Inject(_sqlLiteDB)
                .Inject(staticData)
                .Inject(sceneData)
                .Init();
            _projectionSystems
                .Add(new GoldProjection(_goldProtocol))
                .Add(new ExperienceProjection(_experienceProtocol))
                .Add(new DiamondsProjection(_diamondsProtocol))
                .Add(new CellObjectProjection(_cellObjectCount))
                .Add(new GameLevelProjection(_gameLevelProtocol))
                .Add(new ExperienceBarProjection(_experienceBarProtocol))
                .Add(new QuestDataProjection(_questDataProtocol))
                .Init();
            _clearSystems
                .Add(new Clear())
                .Init();
        }

        private void Update()
        {
            _coreGameSystems?.Run();
            _projectionSystems?.Run();
            _clearSystems?.Run();
        }
        

        private void OnDestroy()
        {
            _coreGameSystems?.Destroy();
            _projectionSystems?.Destroy();
            _clearSystems?.Run();
            _world?.Destroy();
        }
    }
}