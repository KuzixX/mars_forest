using Client.Scripts.ECS_Feature.Camera_Control.System;
using Client.Scripts.ECS_Feature.Interaction_Feature.system;
using Client.Scripts.ECS_Feature.Pick_Gold_System;
using Client.Scripts.ECS_Feature.Pick_Gold_System.System;
using Client.Scripts.ECS_Feature.Projection_Systems.System;
using Client.Scripts.ECS_Feature.Quest_System.System;
using Client.Scripts.ECS_Feature.Resources_Generation.System;
using Client.Scripts.ECS_Feature.SpawnCellObject.System;
using Client.Scripts.Models;
using Client.Scripts.Protocols.Interface;
using Client.Scripts.Services;
using Leopotam.Ecs;
using Leopotam.Ecs.Ui.Systems;
using UnityEngine;
using Voody.UniLeo;
using Zenject;
using ETouch = UnityEngine.InputSystem.EnhancedTouch;
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
        public InputControls InputControls;
        
        [Inject] private IGameStateProtocol _gameStateProtocol;
        [Inject] private IExperienceBarProtocol _experienceBarProtocol;

        private void Start()
        {
            // ECS
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);
            InputControls = new InputControls();
            InputControls.Enable();
            _sqlLiteDB = gameObject.AddComponent<SqlLiteDB>();
            ETouch.EnhancedTouchSupport.Enable();
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
                .Add(new ResourcesGeneration())
                .Add(new PickGold())
                .Add(new ExtendLevel.ExtendLevel())
                .Add(new QuestSys())
                .Add(new Robot.System.Robot())
                .Add(new CameraControl())
                .Add(new Experience_Bar.System.ExperienceBar())
                .Add(new GameStateProjection())
                .Add(new ExperienceBarProjection())
                .Inject(_experienceBarProtocol)
                .Inject(_gameStateProtocol)
                .Inject(InputControls)
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