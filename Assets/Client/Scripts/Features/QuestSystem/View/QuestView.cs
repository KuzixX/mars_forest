using TMPro;
using UnityEngine;

namespace Client.Scripts.Features.QuestSystem
{
    public class QuestView : MonoBehaviour
    {
        private string _propertyName;
        [SerializeField] private TextMeshProUGUI _view;

        public void Init (string propertyName)
        {
            _propertyName = propertyName;
        }

        public void UpdateText(int current, int target)
        {
            _view.text = _propertyName + ":" + current + "/" + target;
        }
    }
}
