using System.Globalization;
using Client.Scripts.Models;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.UI;

namespace Client.Scripts.UI
{
    public class ShopScreen : Screen
    {
        [Header("Menus")]
        public StuffMenu stuffMenu;
        public DiamondsMenu diamondsMenu;
        public LimitedSupplyMenu limitedSupplyMenu;
        [Header("Buttons")] 
        public Button backButton;
        public Button stuffBtn;
        public Button diamondsBtn;
        public Button limitedSupplyBtn;
        
        [SerializeField] private StaticData staticData;
        [SerializeField] private global::Client.Scripts.UI.UI ui;
        public EcsWorld World;

        private void Awake()
        {
            SetShopItems();
        }

        private void Start()
        {
            SwitchMenu();
        }

        private void SetShopItems()
        {
            foreach (var item in staticData.Diamonds)
            {
                var newItem = Instantiate(staticData.UiShopElement, ui.shopScreen.diamondsMenu.diamondsGroup);
                newItem.price.text = item.Price.ToString(CultureInfo.InvariantCulture);
            }

            for (int i = 0; i < staticData.Products.Length; i++)
            {
                if (staticData.Products[i].Type.ToString() == "Gold")
                {
                    var newShopElement = Instantiate(staticData.UiShopElement, ui.shopScreen.stuffMenu.goldGroup);
                    newShopElement.title.text = staticData.Products[i].Title;
                    newShopElement.price.text = staticData.Products[i].Price.ToString();
                    newShopElement.type = staticData.Products[i].Type;
                    newShopElement.image = staticData.Products[i].Image;

                    // var newShopEntity = World.NewEntity();
                    // newShopEntity.Get<ShopItemComponent>();
                } else if (staticData.Products[i].Type.ToString() == "Exp")
                {
                    var newShopElement = Instantiate(staticData.UiShopElement, ui.shopScreen.stuffMenu.expGroup);
                    newShopElement.title.text = staticData.Products[i].Title;
                    newShopElement.price.text = staticData.Products[i].Price.ToString();
                    newShopElement.type = staticData.Products[i].Type;
                } else if (staticData.Products[i].Type.ToString() == "LimitedSupply")
                {
                    
                }
            }
        }
        private void SwitchMenu()
        {
            stuffBtn.onClick.AddListener(() =>
            {
                stuffMenu.Show();
                limitedSupplyBtn.interactable = true;
                diamondsBtn.interactable = true;
                stuffBtn.interactable = false;
                diamondsMenu.Show(false);
                limitedSupplyMenu.Show(false);
            });
            diamondsBtn.onClick.AddListener(() =>
            {
                diamondsMenu.Show();
                limitedSupplyBtn.interactable = true;
                diamondsBtn.interactable = false;
                stuffBtn.interactable = true;
                stuffMenu.Show(false);
                limitedSupplyMenu.Show(false);
            });
            limitedSupplyBtn.onClick.AddListener(() =>
            {
                limitedSupplyMenu.Show();
                limitedSupplyBtn.interactable = false;
                diamondsBtn.interactable = true;
                stuffBtn.interactable = true;
                stuffMenu.Show(false);
                diamondsMenu.Show(false);
            });
        }
    }
}