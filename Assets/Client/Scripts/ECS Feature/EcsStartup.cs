using Client.Scripts.Data;
using Client.Scripts.ECS_Feature.System;
using Client.Scripts.ECS.Components;
using Client.Scripts.ECS.Components.EventCoponents;
using Client.Scripts.ECS.System;
using Client.Scripts.MonoBehaviors.UI;
using Client.Scripts.SQLite;
using ECS.Components.EventCoponents;
using ECS.System;
using Leopotam.Ecs;
using Leopotam.Ecs.Ui.Systems;
using UnityEngine;
using Voody.UniLeo;
using ETouch = UnityEngine.InputSystem.EnhancedTouch;
using NotImplementedException = System.NotImplementedException;

namespace Client.Scripts.ECS
{
    public class EcsStartup : MonoBehaviour
    {
        private EcsWorld _world;
        private SqlLiteDB _sqlLiteDB;
        private EcsSystems _initSystems;
        private EcsSystems _systems;
        private EcsSystems _fixedUpdateSystems;
        [SerializeField] EcsUiEmitter uiEmitter;
        
        [Header("Data")]
        public UI ui;
        public StaticData staticData;
        public SceneData sceneData;
        public InputControls InputControls;

        private void Start()
        {
            Application.targetFrameRate = 60;
            _world = new EcsWorld();
            _sqlLiteDB = new SqlLiteDB();
            _initSystems = new EcsSystems(_world);
            _systems = new EcsSystems(_world);
            _fixedUpdateSystems = new EcsSystems(_world);
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
                .Add(new EcsInitSystem())    
                .Add(new UiViewSystem())
                .Add(new LoadGameProgressSystem())
                // .Add(new SetShopItemsSystem())
                // .Add(new SetInventoryItemsSystem())
                .Add(new CreateQuestEntity())
                .Add(new InitTargetXpSystem())
                .Add(new CellObjectLevelUpSystem())
                .Add(new LockCameraSystem()) //refactored;
                // Input systems
                .Add(new PlayerInputSystem())
                .Add(new ScreenPointToRaySystem())
                .Add(new GetRayHitSystem())
                .Add(new SetTargetSystem())
                .Add(new GetCellPosition())
                .Add(new GetCellSystem())
                .Add(new GetTreePosition())
                // CellObjectSystems systems
                .Add(new CellObjectDataGenerator()) // refactored
                .Add(new SpawnCellObjectSystem()) // refactored
                .Add(new SelectCellObjectSystem())
                .Add(new FreeZoneLightingSystem()) // refactored
                // Resources systems 
                .Add(new ResourcesGenerationSystem()) // refactored
                .Add(new PickGoldSystem()) // refactored
                .Add(new ExpBarSystem()) // refactored
                .Add(new ParticleControlSystem())
                //.Add(new ExtendLevelSystem()) // refactored
                .Add(new QuestSystem())
                .Add(new CameraOrthographicZoomSystem())
                .Add(new CameraMoveSystem())
                .Add(new SetFullIcon())
                .Add(new SetLvlUpTitle())
                // DataBase systems
                .Add(new GameSaveProgressSystem())
                .Add(new SecondOrderSystem())
                .Add(new BorderControlSystem());
            // .Add(new UpdateServerData());
        }

        private void AddOneFrame()
        {
            _systems.OneFrame<TouchEvent>();
            _systems.OneFrame<OnSetTreeEvent>();
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
            _initSystems?.Destroy();
            _systems?.Destroy();
            _fixedUpdateSystems?.Destroy();
            _world?.Destroy();
        }
    }
}