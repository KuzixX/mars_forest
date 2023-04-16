using Client.Scripts.Data;
using Client.Scripts.ECS_Feature_rebuild.Camera_Control.System;
using Client.Scripts.ECS_Feature_rebuild.Interaction_Feature.system;
using Client.Scripts.ECS_Feature_rebuild.Quest_System.System;
using Client.Scripts.ECS_Feature_rebuild.Resources_Generation;
using Client.Scripts.ECS_Feature_rebuild.SpawnCellObject.System;
using Client.Scripts.ECS_Feature.CellObjectLevelUp;
using Client.Scripts.ECS_Feature.Lighting_Free_Zone;
using Client.Scripts.ECS_Feature.Pick_Gold_System;
using Client.Scripts.ECS_Feature.Save_Load_Game_Progress;
using Client.Scripts.ECS_Feature.SpawnCellObject.System;
using Client.Scripts.ECS_Feature.UI.System;
using Client.Scripts.ECS.System;
using Client.Scripts.MonoBehaviors;
using ECS.Components.EventCoponents;
using Leopotam.Ecs;
using Leopotam.Ecs.Ui.Systems;
using UnityEngine;
using Voody.UniLeo;
using ETouch = UnityEngine.InputSystem.EnhancedTouch;
using Input = Client.Scripts.ECS_Feature_rebuild.Input_Features.System.Input;

namespace Client.Scripts.ECS_Feature
{
    public class EcsStartup : MonoBehaviour
    {
        private EcsWorld _world;
        private SqlLiteDB _sqlLiteDB;
        private EcsSystems _systems;
        [SerializeField] EcsUiEmitter uiEmitter;
        
        [Header("Data")]
        public MonoBehaviors.UI.UI ui;
        public StaticData staticData;
        public SceneData sceneData;
        public InputControls InputControls;

        private void Start()
        {
            
            Application.targetFrameRate = 60;
            _world = new EcsWorld();
            _sqlLiteDB = gameObject.AddComponent<SqlLiteDB>();
            _systems = new EcsSystems(_world);
            InputControls = new InputControls();
            InputControls.Enable();
            ETouch.EnhancedTouchSupport.Enable();
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_systems);
#endif
            AddSystems();
            AddInjection();
            
            _systems.Init();
        }

        private void Update()
        {
            _systems?.Run();
        }

        private void AddSystems()
        {
            _systems.ConvertScene().
                // Resources systems 
                OneFrame<OnExpEvent>()
                .Add(new UiView()) //UI  Init
                .Add(new ECS_Feature_rebuild.Robot.Robot())
                .Add(new LoadGameProgress())
                //-------------------------------------
                .Add(new Input())
                .Add(new Interaction())
                .Add(new FreeZoneLighting())
                .Add(new CellObjectLvlUp())
                //-------------------------------------
                //.Add(new CellObjectDataGenerator()) // Init
                .Add(new SpawnCellObjects())
                //-------------------------------------
                .Add(new ResourcesGeneration()) // UI
                .Add(new PickGold()) //UI
            .Add(new ExperienceBar()) //UI
            .Add(new ParticleControl()) // UI
            .Add(new ExtendLevel.ExtendLevel())
            .Add(new QuestSys()) // UI
            //-------------------------------------
            .Add(new CameraControl())
            .Add(new LockCamera())
                //-------------------------------------
            .Add(new SetFullIcon())
            .Add(new SetLvlUpTitle())
            //-------------------------------------
            .Add(new GameSaveProgress());
            // .Add(new UpdateServerData());
        }
        
        private void AddInjection()
        {
            _systems
                .Inject(staticData)
                .Inject(InputControls)
                .Inject(sceneData)
                .Inject(ui)
                .Inject(_sqlLiteDB)
                .InjectUi(uiEmitter);
        }

        private void OnDestroy()
        {
            _systems?.Destroy();
            _world?.Destroy();
        }
    }
}