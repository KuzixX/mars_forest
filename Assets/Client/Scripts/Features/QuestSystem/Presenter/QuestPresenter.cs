using Client.Scripts.Features.QuestSystem.Model;
using Client.Scripts.Features.QuestSystem.View;
using System.Collections.Generic;
using Client.Scripts.Features.Commands;
using Client.Scripts.Models;
using Client.Scripts.Protocols;
using UniRx;
using UnityEngine;
using Zenject;

namespace Client.Scripts.Features.QuestSystem.Presenter
{
    public class QuestPresenter : MonoBehaviour
    {
        private QuestView                         _view;
        private List<QuestModel>                  _models;
        private GetAwardCommand                   _getAwardCommand;
        [SerializeField] private StaticData        staticData;
        [Inject] private QuestContainerTransform  _questContainer;
      //  [Inject] private QuestDataProtocol        _questDataProtocol;
        private CompositeDisposable               _disposable = new();


        private void Start()
        {
            Init();
        }
        private void Init()
        {
            _models =             new List<QuestModel>();
            _getAwardCommand =    new GetAwardCommand();
            
            foreach (var qst in staticData.Quest)
            {
                var quest = new QuestModel();
                quest.Title = qst.Title;
                quest.QuestType = qst.Type;
                quest.Award = qst.DiamondsReward;
                quest.IsDone = false;
                quest.QuestRequirementCount = qst.QuestRequirementCount;
                quest.QuestObjectiveCurrent = qst.QuestObjectiveCount;
                _models.Add(quest);
            }
            

            foreach (var model in _models)
            {
                var questView = Instantiate(staticData.UiQuestElement, _questContainer.Transform).GetComponent<QuestView>();
                questView.SetTitleView(model.Title);
                questView.SetAwardView(model.Award);
                questView.UpdateViewState(model.QuestObjectiveCurrent, model.QuestRequirementCount, model.FillAmount);
                questView.getAward.onClick.AddListener(() => { GetAward(model.Award);});
            }
        }
        private void GetAward(int amount)
        {
            _getAwardCommand.Execute(Events.DiamondsAdd, amount);
        }

        private void UpdateModelData()
        {
            foreach (var model in _models)
            {
                // switch (model.QuestType)
                // {
                //     case QuestType.GoldQuest:
                //         if(!model.IsDone)
                //             model.QuestObjectiveCurrent = _questDataProtocol.Gold.Value;
                //         if (model.QuestObjectiveCurrent >= model.QuestRequirementCount)
                //             model.IsDone = true;
                //         break;
                //     case QuestType.ExperienceQuest:
                //         if(!model.IsDone)
                //             model.QuestObjectiveCurrent = _questDataProtocol.Experience.Value;
                //         break;
                //     case QuestType.DiamondsQuest:
                //         if(!model.IsDone)
                //             model.QuestObjectiveCurrent = _questDataProtocol.Diamonds.Value;
                //         break;
                //     case QuestType.GameLevelUpgradeQuest:
                //         if(!model.IsDone)
                //             model.QuestObjectiveCurrent = _questDataProtocol.GameLevel.Value;
                //         break;
                //     case QuestType.CellObjectQuest:
                //         if(!model.IsDone)
                //             model.QuestObjectiveCurrent = _questDataProtocol.CellObjects.Value;
                //         break;
                //     case QuestType.CellObjectLevelUpgradeQuest:
                //         break;
                // }
            }
        }
    }
}
