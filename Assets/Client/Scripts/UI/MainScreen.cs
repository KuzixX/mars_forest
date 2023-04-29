using Client.Scripts.Protocols.Interface;
using Client.Scripts.Services;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
namespace Client.Scripts.UI
{
    public class MainScreen : Screen
    {
        public UI ui;
        private readonly CompositeDisposable _disposable = new();
        
        [SerializeField] public TextMeshProUGUI cellObjectsAmountText;
        [SerializeField] public TextMeshProUGUI expAmountText;
        [SerializeField] public TextMeshProUGUI goldAmountText;
        [SerializeField] public TextMeshProUGUI diamondsAmountText;
        [SerializeField] public TextMeshProUGUI gameLevelText;
        [SerializeField] public TextMeshProUGUI expBarAmountText;
        [Header("Images")] 
        [SerializeField] public Image expFillImage;
        [SerializeField] public Image getGoldBtnFill;

        [Header("Main screen buttons")] [SerializeField]
        public Button pickGoldBtn;

        [SerializeField] public Button takePictureBtn;
        [SerializeField] public Button treeLvlUpBtn;
        [SerializeField] public Button shopBtn;
        [SerializeField] public Button questBtn;
        [SerializeField] public Button craftBtn;
        [SerializeField] public Button settingsBtn;
        
        [Inject] public IGameStateProtocol GameStateProtocol;
        

        private void Start()
        {
            UpdateUI(); 
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
    private void UpdateUI()
    {
        // Update UI
        GameStateProtocol.Gold.Subscribe(_ =>
        {
            goldAmountText.text = CurrencyConvertor.CurrencyToString(GameStateProtocol.Gold.Value);
        }).AddTo(_disposable);
        GameStateProtocol.Experience.Subscribe(_ =>
        {
            expAmountText.text = CurrencyConvertor.CurrencyToString(GameStateProtocol.Experience.Value);
                
        }).AddTo(_disposable);
        GameStateProtocol.Diamonds.Subscribe(_ =>
        {
            diamondsAmountText.text = CurrencyConvertor.CurrencyToString(GameStateProtocol.Diamonds.Value);
                
        }).AddTo(_disposable);
        GameStateProtocol.CellObjectsCount.Subscribe(_ =>
        {
            cellObjectsAmountText.text = GameStateProtocol.CellObjectsCount.Value.ToString();
        });
        GameStateProtocol.GameLevel.Subscribe(_ =>
        {
            gameLevelText.text = GameStateProtocol.GameLevel.Value.ToString();
        });
    }
    
    }
}