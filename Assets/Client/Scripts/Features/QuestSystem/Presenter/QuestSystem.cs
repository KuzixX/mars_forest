using Client.Scripts.Features.QuestSystem.Model;
using UnityEngine;

namespace Client.Scripts.Features.QuestSystem
{
    public class QuestSystem : MonoBehaviour
    {
        private QuestProperty _goldQuest;
        private QuestView _view;

        public void Init(string propertyName, int current, int target)
        {
            _goldQuest = new QuestProperty(current, target);
            _view = GetComponent<QuestView>();
            _view.Init(propertyName);
            UpdateView();
        }

        private void UpdateView()
        {
            _view.UpdateText(_goldQuest.Current, _goldQuest.Target);
        }

        public void AddProperty(int value)
        {
            _goldQuest.Add(value);
            UpdateView();
        }
    }
}
