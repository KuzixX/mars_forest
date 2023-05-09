using Client.Scripts.ECS_Feature.Camera_Control.System;
using Client.Scripts.ECS_Feature.ECS_Feature_old.EventCoponents;
using Client.Scripts.ECS_Feature.ECS_Feature_old.UI.System;
using Client.Scripts.ECS_Feature.Quest_System.System;
using Client.Scripts.Models;
using Client.Scripts.Services;
using Leopotam.Ecs;
using Leopotam.Ecs.Ui.Systems;
using UnityEngine;
using Voody.UniLeo;
using ETouch = UnityEngine.InputSystem.EnhancedTouch;

namespace Client.Scripts.ECS_Feature.ECS_Feature_old
{
    public class EcsStartup : MonoBehaviour
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

        private void Start()
        {
            
            Application.targetFrameRate = 60;
            _world = new EcsWorld();
            _sqlLiteDB = gameObject.AddComponent<SqlLiteDB>();
            _systems = new EcsSystems(_world);
            InputControls = new InputControls();
            InputControls.Enable();
            ETouch.EnhancedTouchSupport.Enable();

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
           // _systems.ConvertScene().
                // Resources systems 
                //OneFrame<OnExpEvent>()
                //.Add(new UiView()) //UI  Init
                //.Add(new Robot.System.Robot())
                //.Add(new LoadGameProgress())
                //-------------------------------------
                //.Add(new Input())
                //.Add(new Interaction())
                //.Add(new CellObjectLvlUp())
                //-------------------------------------
                //.Add(new CellObjectDataGenerator()) // Init
               // .Add(new SpawnCellObjects())
                //-------------------------------------
               // .Add(new ResourcesGeneration()) // UI
               // .Add(new PickGold()) //UI
            //.Add(new Experience_Bar.System.ExperienceBar()) //UI
            //.Add(new ParticleControl()) // UI
            //.Add(new ExtendLevel())
            //.Add(new QuestSys()) // UI
            //-------------------------------------
            //.Add(new CameraControl())
            //.Add(new LockCamera())
                //-------------------------------------
            //.Add(new SetFloatIcon())
            //.Add(new SetLvlUpTitle())
            //-------------------------------------
            //.Add(new GameSaveProgress());
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