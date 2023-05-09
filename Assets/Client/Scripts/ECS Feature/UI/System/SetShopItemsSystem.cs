using Client.Scripts.ECS_Feature.ECS_Feature_old.UI.Component;
using Client.Scripts.Models;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Scripts.ECS_Feature.ECS_Feature_old.UI.System
{
    internal class SetShopItemsSystem : IEcsInitSystem
    {
        private readonly StaticData _staticData;
        private readonly Scripts.UI.UI _ui;
        private EcsWorld _world;

        public void Init()
        {
            for (int i = 0; i < _staticData.Products.Length; i++)
            {
                if (_staticData.Products[i].Type.ToString() == "Gold")
                {
                    var newShopElement = Object.Instantiate(_staticData.UiShopElement, _ui.shopScreen.stuffMenu.goldGroup);
                    newShopElement.title.text = _staticData.Products[i].Title;
                    newShopElement.price.text = _staticData.Products[i].Price.ToString();
                    newShopElement.type = _staticData.Products[i].Type;
                    newShopElement.image = _staticData.Products[i].Image;

                    var newShopEntity = _world.NewEntity();
                    newShopEntity.Get<ShopItemComponent>();
                } else if (_staticData.Products[i].Type.ToString() == "Exp")
                {
                    var newShopElement = Object.Instantiate(_staticData.UiShopElement, _ui.shopScreen.stuffMenu.expGroup);
                    newShopElement.title.text = _staticData.Products[i].Title;
                    newShopElement.price.text = _staticData.Products[i].Price.ToString();
                    newShopElement.type = _staticData.Products[i].Type;
                } else if (_staticData.Products[i].Type.ToString() == "LimitedSupply")
                {
                    
                }
            }
        }
    }
}