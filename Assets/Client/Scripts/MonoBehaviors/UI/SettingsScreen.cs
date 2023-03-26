using Client.Scripts.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Client.Scripts.MonoBehaviors.UI
{
    public class SettingsScreen : Screen
    {
        public StaticData staticData;
        [Header("UI Settings")]
        public Button backButton;
        public TextMeshProUGUI settingsMenuTitle;
        public Transform languageBtnContainer;
        [Header("Sliders")]
        [SerializeField] private Slider musicSlider;
        [SerializeField] private Slider soundEffectsSlider;
        [SerializeField] private Slider uiSoundSlider;
        [Header("Buttons")] 
        [SerializeField] private Button instBtn;
        [SerializeField] private Button facebookBtn;
        [SerializeField] private Button youTubeBtn;
        [Header("Audio Sources")]
        [SerializeField] private AudioSource musicSound;
        [SerializeField] private AudioSource effectsSound;
        [SerializeField] private AudioSource uiSound;
        

        private void Start()
        {
            // Sliders
            musicSlider.onValueChanged.AddListener(delegate {ChangeVolume(musicSound, musicSlider); });
            soundEffectsSlider.onValueChanged.AddListener(delegate {ChangeVolume(effectsSound, soundEffectsSlider); });
            uiSoundSlider.onValueChanged.AddListener(delegate {ChangeVolume(uiSound, uiSoundSlider); });
            // Open Url
            instBtn.onClick.AddListener(() => {OpenUrl(staticData.InstagramUrl);});
            facebookBtn.onClick.AddListener(() => {OpenUrl(staticData.FacebookUrl);});
            youTubeBtn.onClick.AddListener(() => {OpenUrl(staticData.YouTubeUrl);});
        }
        
        private void ChangeVolume(AudioSource source, Slider value)
        {
            source.volume = value.value;
            
        }
        private void OpenUrl(string url)
        {
            Application.OpenURL(url);
        }
        
        private void ChangeLanguage() {}

    }
}