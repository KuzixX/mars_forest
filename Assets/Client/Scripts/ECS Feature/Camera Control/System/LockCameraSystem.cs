using Client.Scripts.ECS.Components;
using Client.Scripts.MonoBehaviors.UI;
using Leopotam.Ecs;

namespace Client.Scripts.ECS.System
{
    internal class LockCameraSystem : IEcsInitSystem
    {
        private UI _ui;
        private readonly EcsFilter<MainCamera> _camera;
        public void Init()
        {
            _ui.mainScreen.questBtn.onClick.AddListener(() =>
            {
                ref var camera = ref _camera.GetEntity(0);
                camera.Get<Lock>();
            });
            _ui.mainScreen.shopBtn.onClick.AddListener(() =>
            {
                ref var camera = ref _camera.GetEntity(0);
                camera.Get<Lock>();
            });
            _ui.mainScreen.settingsBtn.onClick.AddListener(() =>
            {
                ref var camera = ref _camera.GetEntity(0);
                camera.Get<Lock>();
            });
            _ui.mainScreen.craftBtn.onClick.AddListener(() =>
            {
                ref var camera = ref _camera.GetEntity(0);
                camera.Get<Lock>();
            });
            _ui.questScreen.backButton.onClick.AddListener(() =>
            {
                ref var camera = ref _camera.GetEntity(0);
                camera.Del<Lock>();
            });
            _ui.shopScreen.backButton.onClick.AddListener(() =>
            {
                ref var camera = ref _camera.GetEntity(0);
                camera.Del<Lock>();
            });
            _ui.settingsScreen.backButton.onClick.AddListener(() =>
            {
                ref var camera = ref _camera.GetEntity(0);
                camera.Del<Lock>();
            });
            _ui.craftScreen.backButton.onClick.AddListener(() =>
            {
                ref var camera = ref _camera.GetEntity(0);
                camera.Del<Lock>();
            });
        }
    }
}