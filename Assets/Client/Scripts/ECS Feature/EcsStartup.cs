using Client.Scripts.Data;
using Client.Scripts.ECS_Feature.Camera_Control.System;
using Client.Scripts.ECS_Feature.CellObjectLevelUp;
using Client.Scripts.ECS_Feature.Init;
using Client.Scripts.ECS_Feature.Input_Features.Component;
using Client.Scripts.ECS_Feature.Interaction_Features.system;
using Client.Scripts.ECS_Feature.Lighting_Free_Zone;
using Client.Scripts.ECS_Feature.Pick_Gold_System;
using Client.Scripts.ECS_Feature.Quest_System.System;
using Client.Scripts.ECS_Feature.Resources_Generation;
using Client.Scripts.ECS_Feature.Save_Load_Game_Progress;
using Client.Scripts.ECS_Feature.SpawnCellObject.System;
using Client.Scripts.ECS_Feature.UI.System;
using Client.Scripts.ECS.Components;
using Client.Scripts.ECS.System;
using Client.Scripts.MonoBehaviors;
using ECS.Components.EventCoponents;
using Leopotam.Ecs;
using Leopotam.Ecs.Ui.Systems;
using UnityEngine;
using Voody.UniLeo;
using ETouch = UnityEngine.InputSystem.EnhancedTouch;
using Input = Client.Scripts.ECS_Feature.Input_Features.System.Input;

namespace Client.Scripts.ECS_Feature
{
    public class EcsStartup : MonoBehaviour
    {
        private EcsWorld _world;
        private SqlLiteDB _sqlLiteDB;
        private EcsSystems _systems;
        private EcsSystems _initSystems;
        private EcsSystems _interactionSystems;
        private EcsSystems _behaviourSystems;
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
            AddOneFrame();
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
            _systems.ConvertScene()
                // Resources systems 
                .Add(new UiView()) //UI
                .Add(new Robot.Robot())
                .Add(new LoadGameProgress())
                .Add(new LockCamera())
                //-------------------------------------
                .Add(new Input())
                .Add(new Interaction())
                //-------------------------------------
                .Add(new FreeZoneLighting())
                //-------------------------------------
                .Add(new CellObjectDataGenerator())
                .Add(new SpawnCellObjects())
                //-------------------------------------
                .Add(new ResourcesGeneration()) // UI
                .Add(new CellObjectLvlUp())
                .Add(new PickGold()) //UI
                .Add(new ExperienceBar()) //UI
                .Add(new ParticleControl()) // UI
                .Add(new ExtendLevel.ExtendLevel()) 
                .Add(new QuestSys()) // UI
                //-------------------------------------
                //.Add(new CameraControl())
                .Add(new CameraZoom())
                .Add(new CameraMove())
                .Add(new CameraBorderControl())
                //-------------------------------------
                .Add(new SetFullIcon())
                .Add(new SetLvlUpTitle())
                //-------------------------------------
                .Add(new GameSaveProgress());
            // .Add(new UpdateServerData());
        }

        private void AddOneFrame()
        {
            // _systems.OneFrame<TouchEvent>();
            // _systems.OneFrame<OnSetTreeEvent>();
            _systems.OneFrame<OnLevelExtend>();
            _systems.OneFrame<OnExpEvent>();
            _systems.OneFrame<OnParticleSpawn>();
            _systems.OneFrame<OnPickGold>();
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

    internal class CameraControl : IEcsRunSystem, IEcsInitSystem
    {

        private readonly SceneData _sceneData;
        private readonly EcsFilter<CameraComponent, Position, MainCamera> _camera;
        private readonly EcsFilter<InputComponent> _input;
        private readonly EcsFilter<Lock> _lockCameraFilter;
        
        public void Init()
        {
        
        }
        
        public void Run()
        {
            ref var cameraData = ref _camera.Get1(0);
            ref var cameraPos = ref _camera.Get2(0);
            ref var input = ref _input.Get1(0);
            
                if (_lockCameraFilter.IsEmpty())
                {
                    cameraData.TouchZeroPrevious = input.TouchPosition00 - input.TouchDelta00;
                    cameraData.TouchOnePrevious = input.TouchPosition01 - input.TouchDelta01;

                    cameraData.PreviousMag = (cameraData.TouchZeroPrevious - cameraData.TouchOnePrevious).magnitude;
                    cameraData.CurrentMag = (input.TouchPosition00 - input.TouchPosition01).magnitude;

                    cameraData.Difference = cameraData.CurrentMag - cameraData.PreviousMag;

                    cameraData.OrthographicSize = Mathf.Clamp(cameraData.OrthographicSize - cameraData.Difference * cameraData.ZoomSpeed, cameraData.ZoomMin, cameraData.ZoomMax);
                    _sceneData.MainCamera.orthographicSize = cameraData.OrthographicSize;
                }
                
            
                
                // Логика выполняется при тапе
                if (input.PressTouch & _lockCameraFilter.IsEmpty())
                {
                    cameraData.Distance = Vector3.Distance(
                        _sceneData.MainCamera.ScreenToWorldPoint(input.TouchPosition00),
                        _sceneData.MainCamera.ScreenToWorldPoint(input.TouchPosition01));
                }

                // Логика выполняется, когда значение изеняется
                // количество тачей снизит на один
                if (input.TouchPosition00IsTriggered &&
                    ETouch.Touch.activeFingers.Count < 3 & _lockCameraFilter.IsEmpty())
                {
                    cameraData.CurrentDistance = Vector3.Distance(
                        _sceneData.MainCamera.ScreenToWorldPoint(input.TouchPosition00),
                        _sceneData.MainCamera.ScreenToWorldPoint(input.TouchPosition01));
                    cameraData.Delta =
                        input.PrimaryDelta * -0.01f;
                    cameraPos.transform.position += cameraData.Delta *
                                                    (Time.deltaTime * cameraData.DragSpeed);
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
        }
    }
}