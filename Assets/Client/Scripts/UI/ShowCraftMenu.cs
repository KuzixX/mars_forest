using System;
using Client.Scripts.Services.EventBus;
using Client.Scripts.UI.Events;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Client.Scripts.UI
{
    public class ShowCraftMenu : MonoBehaviour
    {
        [Inject] private EventBus _eventBus;
        private Button _button;
        private Image _image;

        private void Start()
        {
            _button = GetComponent<Button>();
            _image = GetComponent<Image>();
            _eventBus.Subscribe<MenuOpenEvent>(ActivateButton);
        }

        public void Show()
        {
            _eventBus.Publish(this, new OpenCraftMenuEvent());
        }
        public void Hide()
        {
            _eventBus.Publish(this, new CloseCraftMenuEvent());
            _button.enabled = false;
            _image.enabled = false;
        }

        public void ActivateButton(object sender, EventArgs e)
        {
            _button.enabled = true;
            _image.enabled = true;
        }
    }
}
