using System;
using Client.Scripts.Services.EventBus;
using Client.Scripts.UI.Events;
using UnityEngine;
using Zenject;

namespace Client.Scripts.UI.Menus
{
    public class ShopMenu : MonoBehaviour
    {
        [Inject] private EventBus _eventBus;
        [SerializeField] private GameObject craftMenuWidget;

        private void Start()
        {
            _eventBus.Subscribe<OpenShopMenuEvent>(Show);
            _eventBus.Subscribe<CloseShopMenuEvent>(Hide);
        }

        private void OnDisable()
        {
            _eventBus.Unsubscribe<OpenShopMenuEvent>(Show);
            _eventBus.Unsubscribe<CloseShopMenuEvent>(Hide);
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
