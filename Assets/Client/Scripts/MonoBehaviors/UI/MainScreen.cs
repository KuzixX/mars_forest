using Client.Scripts.ECS.Components;
using Leopotam.Ecs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Screen = Client.Scripts.MonoBehaviors.UI.Screen;

namespace Client.Scripts.MonoBehaviors.UI
{
    public class MainScreen : Screen
    {
    public global::Client.Scripts.MonoBehaviors.UI.UI ui;
    private readonly EcsFilter<MainCamera> _cam;
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

    private void Start()
    {
        // Show and hide screens
        ShowScreen(ui.settingsScreen, settingsBtn, ui.settingsScreen.backButton);
        ShowScreen(ui.craftScreen, craftBtn, ui.craftScreen.backButton);
        ShowScreen(ui.questScreen, questBtn, ui.questScreen.backButton);
        ShowScreen(ui.shopScreen, shopBtn, ui.shopScreen.backButton);
        ShowScreen(ui.screenshotScreen, takePictureBtn, ui.screenshotScreen.backBtn);
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