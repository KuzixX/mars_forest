using Client.Scripts.Models;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Scripts.ECS_Feature.ECS_Feature_old.UI.System
{
    sealed class SetInventoryItemsSystem : IEcsInitSystem
    {
        private StaticData _staticData;
        private Scripts.UI.UI _ui;

        public void Init()
        {
            for (int i = 0; i < _staticData.TreesData.Length; i++)
            {
                var newUiITemElement = Object.Instantiate(_staticData.UiItemElement,
                    _ui.craftScreen.treeMenuMenu.treeContainer.transform);
                newUiITemElement.image.sprite = _staticData.TreesData[i].Image;
                newUiITemElement.title.text = _staticData.TreesData[i].Title;
                newUiITemElement.description.text = _staticData.TreesData[i].Description;
//                newUiITemElement.clickAction.WidgetName = _staticData.TreesData[i].Title;
            }
        }
    }
}