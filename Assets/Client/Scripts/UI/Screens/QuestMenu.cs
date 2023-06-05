using System;
using Client.Scripts.Services.EventBus;
using Client.Scripts.UI.Events;
using UnityEngine;
using Zenject;

namespace Client.Scripts.UI.Screens
{
    public class QuestMenu : Menu
    {
        [Inject] private EventBus _eventBus;
        [SerializeField] private GameObject questMenuWidget;

        private void Start()
        {
            _eventBus.Subscribe<OpenQuestMenuEvent>(Show);
            _eventBus.Subscribe<CloseQuestMenuEvent>(Hide);
        }

        private void OnDisable()
        {
            _eventBus.Unsubscribe<OpenQuestMenuEvent>(Show);
            _eventBus.Unsubscribe<CloseQuestMenuEvent>(Hide);
        }

        private void Show(object sender, EventArgs e)
        {
            questMenuWidget.SetActive(true);
            _eventBus.Publish(this, new MenuOpenEvent());
        }

        private void Hide(object sender, EventArgs e)
        {
            questMenuWidget.SetActive(false);
        }
    }
}
