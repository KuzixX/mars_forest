using Client.Scripts.Interface;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Client.Scripts.MonoBehaviors.UI
{
    public class MainScreen : Screen
    {
        public UI ui;
        private readonly CompositeDisposable _disposable = new();
        
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
        
        [Inject] public IResourcesProtocol ResourcesProtocol;


        private int _gold;

        private void Start()
        {
            // Update UI
            ResourcesProtocol.Gold.Subscribe(_ =>
            {
                goldAmountText.text = CurrencyConvertor.CurrencyToString(ResourcesProtocol.Gold.Value);
            }).AddTo(_disposable);
            ResourcesProtocol.Experience.Subscribe(_ =>
            {
                expAmountText.text = CurrencyConvertor.CurrencyToString(ResourcesProtocol.Experience.Value);
                
            }).AddTo(_disposable);
            ResourcesProtocol.Diamonds.Subscribe(_ =>
            {
                diamondsAmountText.text = CurrencyConvertor.CurrencyToString(ResourcesProtocol.Diamonds.Value);
                
            }).AddTo(_disposable);
            
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