using UnityEngine;
using UnityEngine.UI;

namespace Client.Scripts.MonoBehaviors.UI
{
    public class ScreenshotScreen : Screen
    {
        [Header("Buttons")]
        public Button screenshotBtn;
        public Button backBtn;
        public Button shareBtn;
        
        private void Start()
        {
            screenshotBtn.onClick.AddListener(() =>
            {
                CaptureScreen();
            });
        }

        private void CaptureScreen()
        {
            string timeStamp = System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
            string fileName = "Screenshot" + timeStamp + ".png";
            string pathToSave = fileName;
            ScreenCapture.CaptureScreenshot("C:/screenshots/" + pathToSave);
        }
    }
}
