using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Client.Scripts.Features.QuestSystem.View
{
    public class QuestView : MonoBehaviour
    {
        public TextMeshProUGUI questStateView;
        public TextMeshProUGUI title;
        public TextMeshProUGUI awardView;
        public Image           questFillImage;
        public Button          getAward;
        public void UpdateViewState(double current, double target, float fillPercent)
        {
            questStateView.text = $"{current} / {target}";
            questFillImage.fillAmount = fillPercent;
        }

        public void SetTitleView(string questTitle)
        {
            title.text = questTitle;
        }

        public void SetAwardView(int award)
        {
            awardView.text = award.ToString();
        }
    }
}
