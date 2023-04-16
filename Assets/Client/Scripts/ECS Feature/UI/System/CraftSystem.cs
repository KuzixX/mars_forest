using Client;
using Client.Scripts.ECS.Components;
using Client.Scripts.MonoBehaviors.UI;
using Leopotam.Ecs;
using Leopotam.Ecs.Ui.Components;
using UnityEngine;

namespace ECS.System
{
    sealed class CraftSystem : IEcsRunSystem
    {
        private readonly EcsFilter<EcsUiClickEvent> _clickEvent;
        private readonly EcsFilter<EcsUiDownEvent> _downEvent;
        private readonly EcsFilter<CameraTag> _mainCamera;
        private readonly EcsFilter<Lock> _lockCameraFilter;
        private readonly UI _ui;

        public void Run()
        {
            ref var cameraEntity = ref _mainCamera.GetEntity(0);
            ref var clickData = ref _clickEvent.Get1(0);
            ref var downClickData = ref _downEvent.Get1(0);
            if (clickData.WidgetName == "ShopEventBtn" & _lockCameraFilter.IsEmpty())
            {
                cameraEntity.Get<Lock>();
                _ui.shopScreen.Show();
            } 
            else if (clickData.WidgetName == "ShopBackBtn" & !_lockCameraFilter.IsEmpty())
            {
                cameraEntity.Del<Lock>();
                _ui.shopScreen.Show(false);
            }
            if (clickData.WidgetName == "SettingsBtn" & _lockCameraFilter.IsEmpty())
            {
                cameraEntity.Get<Lock>();
                _ui.settingsScreen.Show();
            }
            else if (clickData.WidgetName == "SettingsBackBtn" & !_lockCameraFilter.IsEmpty())
            {
                _ui.settingsScreen.Show(false);
                cameraEntity.Del<Lock>();
            }
            
            if (downClickData.WidgetName == "CraftEventDownUpBtn" & _lockCameraFilter.IsEmpty())
            {
                Debug.Log("kr");
                cameraEntity.Get<Lock>();
                _ui.craftScreen.Show();
            }
            else if (clickData.WidgetName == "CraftScreen" & !_lockCameraFilter.IsEmpty())
            {
                _ui.craftScreen.Show(false);
                cameraEntity.Del<Lock>();
            }
            else if (clickData.WidgetName == "CraftItemBtn" & !_lockCameraFilter.IsEmpty())
            {
                _ui.craftScreen.Show(false);
                cameraEntity.Del<Lock>();
            }

            if (clickData.WidgetName == "QuestEventBtn" & _lockCameraFilter.IsEmpty())
            {
                cameraEntity.Get<Lock>();
                _ui.questScreen.Show();
            }
            else if (clickData.WidgetName == "QuestScreen" & !_lockCameraFilter.IsEmpty())
            {
                cameraEntity.Del<Lock>();
                _ui.questScreen.Show(false);
            }
        }
    }
}