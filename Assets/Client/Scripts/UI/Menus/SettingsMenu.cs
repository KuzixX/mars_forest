using System;
using Client.Scripts.Services.EventBus;
using Client.Scripts.UI.Events;
using UnityEngine;
using Zenject;

namespace Client.Scripts.UI.Menus
{
    public class SettingsMenu : MonoBehaviour
    {
        [Inject] private EventBus _eventBus;
        [SerializeField] private GameObject settingsMenuWidget;

        private void Start()
        {
            _eventBus.Subscribe<OpenSettingsMenuEvent>(Show);
            _eventBus.Subscribe<CloseSettingsMenuEvent>(Hide);
        }

        private void OnDisable()
        {
            _eventBus.Unsubscribe<OpenSettingsMenuEvent>(Show);
            _eventBus.Unsubscribe<CloseSettingsMenuEvent>(Hide);
        }

        private void Show(object sender, EventArgs e)
        {
            settingsMenuWidget.SetActive(true);
            _eventBus.Publish(this, new MenuOpenEvent());
        }

        private void Hide(object sender, EventArgs e)
        {
            settingsMenuWidget.SetActive(false);
        }
    }
}
