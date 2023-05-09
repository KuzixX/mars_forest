using Client.Scripts.ECS_Feature.Camera_Control.System;
using Client.Scripts.ECS_Feature.ClearSystem.Systems;
using Client.Scripts.ECS_Feature.Experience_Bar.System;
using Client.Scripts.ECS_Feature.ExtendLvl;
using Client.Scripts.ECS_Feature.ExtendLvl.Systems;
using Client.Scripts.ECS_Feature.Interaction_Feature.system;
using Client.Scripts.ECS_Feature.Pick_Gold_System.System;
using Client.Scripts.ECS_Feature.Projection_Systems.System;
using Client.Scripts.ECS_Feature.Resources_Generation.System;
using Client.Scripts.ECS_Feature.Robot.System;
using Client.Scripts.ECS_Feature.SpawnCellObject.System;
using Client.Scripts.ECS_Feature.UpdGameState.Systems;
using Client.Scripts.ECS_Feature.WTCSpace.System;
using Client.Scripts.Models;
using Client.Scripts.Protocols.Interface;
using Client.Scripts.Protocols.Interfaces;
using Client.Scripts.Services;
using Leopotam.Ecs;
using Leopotam.Ecs.Ui.Systems;
using UnityEngine;
using Voody.UniLeo;
using Zenject;
using Input = Client.Scripts.ECS_Feature.Input_Features.System.Input;

namespace Client.Scripts.ECS_Feature
{
    public class Startup : MonoBehaviour
    {
        private EcsWorld _world;
        private SqlLiteDB _sqlLiteDB;
        private EcsSystems _systems;
        [SerializeField] EcsUiEmitter uiEmitter;
          
        [Header("Data")]
        public Scripts.UI.UI ui;
        public StaticData staticData;
        public SceneData sceneData;

        [Inject] private IGameStateProtocol _gameStateProtocol;
        [Inject] private IExperienceBarProtocol _experienceBarProtocol;
        [Inject] private IUiButtonsProtocol _uiButtonsProtocol;

        private void Start()
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);
            _sqlLiteDB = gameObject.AddComponent<SqlLiteDB>();
            Application.targetFrameRate = 60;

#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_systems);
#endif
            
            _systems.ConvertScene()
                .Add(new DebugSystem())
                .Add(new Input())
                .Add(new Interaction())
                .Add(new SpawnCellObjects())
                .Add(new ExtendLevel())
                .Add(new ResourcesGeneration())
                .Add(new PickGold(_uiButtonsProtocol))
                .Add(new ExtendLevel())
                .Add(new HomeRobot())
                .Add(new CameraControl())
                .Add(new WorldToCanvasSpace())
                .Add(new UpdateGameState())
                .Add(new ExperienceBar())
                .Add(new GameStateProjection(_gameStateProtocol))
                .Add(new ExperienceBarProjection(_experienceBarProtocol))
                .Add(new Clear())
                .InjectUi(uiEmitter)
                .Inject(_sqlLiteDB)
                .Inject(staticData)
                .Inject(sceneData)
                .Inject(ui)
                .Init();
        }

        private void Update()
        {
            _systems?.Run();
        }
        

        private void OnDestroy()
        {
            _systems?.Destroy();
            _world?.Destroy();
        }
    }
}