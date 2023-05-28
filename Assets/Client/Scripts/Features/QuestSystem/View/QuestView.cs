using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace Client.Scripts.Features.QuestSystem.View
{
    public class QuestView : MonoBehaviour
    {
        public TextMeshProUGUI questStateView;
        public TextMeshProUGUI title;
        public Image           questFillImage;
        public Button          getAward;

        public void UpdateViewState(int current, int target, float fillPercent)
        {
            questStateView.text = $"{current} / {target}";
            questFillImage.fillAmount = fillPercent;
        }

        public void SetTitle(string questTitle)
        {
            title.text = questTitle;
        }
    }
}
