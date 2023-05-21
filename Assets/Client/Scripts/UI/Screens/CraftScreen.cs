using Client.Scripts.Models;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace Client.Scripts.UI
{
    public class CraftScreen : Scripts.UI.Screen
    {
    
        [Header("Menus")]
        public TreesMenu treeMenuMenu;
        public DevicesMenu devicesMenuMenu;
        public DecorMenu decorMenuMenu;
        [Header("Buttons")] 
        public Button backButton;
        public Button decorBtn;
        public Button devicesBtn;
        public Button treesBtn;

        [SerializeField] private StaticData staticData;
        [SerializeField] private global::Client.Scripts.UI.UI ui;

        private void Awake()
        {
            SetCraftItem();
        }

        private void Start()
        {
            SwitchMenu();
        }

        private void SetCraftItem()
        {
            for (int i = 0; i < staticData.TreesData.Length; i++)
            {
                var newUiITemElement = Object.Instantiate(staticData.UiItemElement,
                    ui.craftScreen.treeMenuMenu.treeContainer.transform);
                newUiITemElement.image.sprite = staticData.TreesData[i].Image;
                newUiITemElement.title.text = staticData.TreesData[i].Title;
                newUiITemElement.description.text = staticData.TreesData[i].Description;
                //newUiITemElement.clickAction.WidgetName = staticData.TreesData[i].Title;
            }
        }
        private void SwitchMenu()
        {
            decorBtn.onClick.AddListener(() =>
            {
                decorMenuMenu.Show();
                devicesBtn.interactable = true;
                treesBtn.interactable = true;
                decorBtn.interactable = false;
                devicesMenuMenu.Show(false);
                treeMenuMenu.Show(false);
            });
            devicesBtn.onClick.AddListener(() =>
            {
                devicesMenuMenu.Show();
                treesBtn.interactable = true;
                devicesBtn.interactable = false;
                decorBtn.interactable = true;
                decorMenuMenu.Show(false);
                treeMenuMenu.Show(false);
            });
            treesBtn.onClick.AddListener(() =>
            {
                treeMenuMenu.Show();
                treesBtn.interactable = false;
                devicesBtn.interactable = true;
                decorBtn.interactable = true;
                decorMenuMenu.Show(false);
                devicesMenuMenu.Show(false);
            });
        }
    }
}