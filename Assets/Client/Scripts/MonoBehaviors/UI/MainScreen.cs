using System;
using Client.Scripts.ECS_Feature_rebuild;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Client.Scripts.MonoBehaviors.UI
{
    public class MainScreen : Screen
    {
    public UI ui;
    [Header("Texts")] [SerializeField] public TextMeshProUGUI treesAmountText;
    [SerializeField] public TextMeshProUGUI expAmountText;
    [SerializeField] public TextMeshProUGUI goldAmountText;
    [SerializeField] public TextMeshProUGUI diamondsAmountText;
    [SerializeField] public TextMeshProUGUI gameLevelText;
    [SerializeField] public TextMeshProUGUI expBarAmountText;
    [Header("Images")] [SerializeField] public Image expFillImage;
    [SerializeField] public Image getGoldBtnFill;

    [Header("Main screen buttons")] [SerializeField]
    public Button pickGoldBtn;
    [SerializeField] public Button takePictureBtn;
    [SerializeField] public Button treeLvlUpBtn;
    [SerializeField] public Button shopBtn;
    [SerializeField] public Button questBtn;
    [SerializeField] public Button craftBtn;
    [SerializeField] public Button settingsBtn;
    public IResourcesProtocol ResourcesProtocol;
    
    [Inject]
    public void Construct(IResourcesProtocol resourcesProtocol)
    {
        ResourcesProtocol = resourcesProtocol;
    }
    
    private void Start()
    {
        // Show and hide screens
        ShowScreen(ui.settingsScreen, settingsBtn, ui.settingsScreen.backButton);
        ShowScreen(ui.craftScreen, craftBtn, ui.craftScreen.backButton);
        ShowScreen(ui.questScreen, questBtn, ui.questScreen.backButton);
        ShowScreen(ui.shopScreen, shopBtn, ui.shopScreen.backButton);
        ShowScreen(ui.screenshotScreen, takePictureBtn, ui.screenshotScreen.backBtn);
        
    }

    private void Update()
    {
        goldAmountText.text = CurrencyConvertor.CurrencyToString(ResourcesProtocol.Gold);
        expAmountText.text = CurrencyConvertor.CurrencyToString(ResourcesProtocol.Experience);
        diamondsAmountText.text = CurrencyConvertor.CurrencyToString(ResourcesProtocol.Diamonds);
    }

    private void ShowScreen(Screen screen, Button showButton, Button hideButton)
    {
        showButton.onClick.AddListener(() =>
        {
            screen.Show();
        });
        hideButton.onClick.AddListener(() =>
        {
            screen.Show(false);
        });
    }
    }
}