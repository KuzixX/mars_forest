using UnityEngine;

namespace Client.Scripts.UI
{
    public class UI : MonoBehaviour
    {
        [Header("Screens")]
        public CraftScreen craftScreen;
        public QuestScreen questScreen;
        public SettingsScreen settingsScreen;
        public ShopScreen shopScreen;
        public ScreenshotScreen screenshotScreen;
        [Header("Other")]
        public Canvas mainCanvas;
        public RectTransform mainCanvasRect;
    }
}