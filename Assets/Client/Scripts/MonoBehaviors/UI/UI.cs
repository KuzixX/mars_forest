using UnityEngine;

namespace Client.Scripts.MonoBehaviors.UI
{
    public class UI : MonoBehaviour
    {
        [Header("Screens")]
        public MainScreen mainScreen;
        public CraftScreen craftScreen;
        public QuestScreen questScreen;
        public SettingsScreen settingsScreen;
        public ShopScreen shopScreen;
        public ScreenshotScreen screenshotScreen;
        [Header("Fx")]
        public ParticleSystem goldUIParticleSystem;
        public ParticleSystem expUIParticleSystem;
        public ParticleSystem diamondsUIParticleSystem;
        [Header("Other")]
        public Canvas mainCanvas;
        public RectTransform mainCanvasRect;
    }
}