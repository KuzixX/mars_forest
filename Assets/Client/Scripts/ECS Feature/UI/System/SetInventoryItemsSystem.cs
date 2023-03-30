using Client.Scripts.Data;
using Client.Scripts.MonoBehaviors.UI;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Scripts.ECS.System
{
    sealed class SetInventoryItemsSystem : IEcsInitSystem
    {
        private StaticData _staticData;
        private UI _ui;

        public void Init()
        {
            for (int i = 0; i < _staticData.TreesData.Length; i++)
            {
                var newUiITemElement = Object.Instantiate(_staticData.UiItemElement,
                    _ui.craftScreen.treeMenuMenu.treeContainer.transform);
                newUiITemElement.image.sprite = _staticData.TreesData[i].Image;
                newUiITemElement.title.text = _staticData.TreesData[i].Title;
                newUiITemElement.description.text = _staticData.TreesData[i].Description;
                newUiITemElement.clickAction.WidgetName = _staticData.TreesData[i].Title;
            }
        }
    }
}