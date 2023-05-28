using Client.Scripts.Features.QuestSystem.Model;
using Client.Scripts.Features.QuestSystem.View;
using System.Collections.Generic;
using Client.Scripts.Models;
using Client.Scripts.Protocols;
using UnityEngine;
using Zenject;

namespace Client.Scripts.Features.QuestSystem.Presenter
{
    public class QuestPresenter : MonoBehaviour
    {
        private QuestView                         _view;
        private List<QuestModel>                  _models;
        [SerializeField] private StaticData        staticData;
        [Inject] private QuestContainerTransform  _questContainer;

        private void Start()
        {
            Init();
        }

        private void Init()
        {
            _models = new List<QuestModel>();
            foreach (var qst in staticData.Quest)
            {
                var quest = new QuestModel();
                quest.Title = qst.Title;
                quest.Award = qst.DiamondsReward;
                quest.QuestType = qst.Objective.ToString();
                quest.QuestRequirementCount = qst.QuestRequirementCount;
                quest.QuestObjectiveCurrent = qst.QuestObjectiveCount;
                _models.Add(quest);
            }

            foreach (var model in _models)
            {
                var questView = Instantiate(staticData.UiQuestElement, _questContainer.Transform);
                questView.GetComponent<QuestView>().SetTitle(model.Title);
                questView.GetComponent<QuestView>().UpdateViewState(model.QuestObjectiveCurrent, model.QuestRequirementCount, model.FillAmount);
            }
        }

        private void UpdateModelData()
        {
            
        }
    }
}
