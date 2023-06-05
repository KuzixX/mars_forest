using System;
using Client.Scripts.Services.EventBus;
using Client.Scripts.UI.Events;
using UnityEngine;
using Zenject;

namespace Client.Scripts.UI.Screens
{
    public class CraftMenu : Menu
    {
        [Inject] private EventBus _eventBus;
        [SerializeField] private GameObject craftMenuWidget;

        private void Start()
        {
            _eventBus.Subscribe<OpenCraftMenuEvent>(Show);
            _eventBus.Subscribe<CloseCraftMenuEvent>(Hide);
        }

        private void OnDisable()
        {
            _eventBus.Unsubscribe<OpenCraftMenuEvent>(Show);
            _eventBus.Unsubscribe<CloseCraftMenuEvent>(Hide);
        }

        private void Show(object sender, EventArgs e)
        {
            craftMenuWidget.SetActive(true);
            _eventBus.Publish(this, new MenuOpenEvent());
        }

        private void Hide(object sender, EventArgs e)
        {
            craftMenuWidget.SetActive(false);
        }
    }
}
