using Client.Scripts.Data;
using Client.Scripts.ECS_Feature_rebuild.Camera_Control.System;
using Client.Scripts.ECS_Feature_rebuild.Interaction_Feature.system;
using Client.Scripts.ECS_Feature_rebuild.Projection_Systems;
using Client.Scripts.ECS_Feature_rebuild.Quest_System.System;
using Client.Scripts.ECS_Feature_rebuild.Resources_Generation;
using Client.Scripts.ECS_Feature_rebuild.SpawnCellObject.System;
using Client.Scripts.ECS_Feature.ExtendLevel;
using Client.Scripts.ECS_Feature.Pick_Gold_System;
using Client.Scripts.ECS.Components;
using Client.Scripts.MonoBehaviors;
using Leopotam.Ecs;
using Leopotam.Ecs.Ui.Systems;
using UnityEngine;
using Voody.UniLeo;
using Zenject;
using ETouch = UnityEngine.InputSystem.EnhancedTouch;
using Input = Client.Scripts.ECS_Feature_rebuild.Input_Features.System.Input;

namespace Client.Scripts.ECS_Feature_rebuild
{
    public class Startup : MonoBehaviour
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
        
        [Inject] public IResourcesProtocol ResourcesProtocol;

        private void Start()
        {
            // ECS
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);
            // MonoBehaviour
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
                .Add(new ExtendLevel())
                .Add(new QuestSys())
                .Add(new Robot.Robot())
                .Add(new CameraControl())
                .Add(new GameResourcesProjection())
                .Inject(staticData)
                .Inject(InputControls)
                .Inject(sceneData)
                .Inject(ui)
                .Inject(_sqlLiteDB)
                .Inject(ResourcesProtocol)
                .InjectUi(uiEmitter)
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


    internal class DebugSystem : IEcsInitSystem
    {
        private readonly EcsFilter<InGameResources> _res;

        public void Init()
        {
            ref var res = ref _res.Get1(0);
            res.gold = 1000;
            res.diamonds = 1000;
            res.experience = 1000;
        }
    }
}