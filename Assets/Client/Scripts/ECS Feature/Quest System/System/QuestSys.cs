  using Client.Scripts.ECS_Feature.Quest_System.Component;
using Client.Scripts.ECS_Feature.Resources_Generation;
using Client.Scripts.ECS_Feature.Resources_Generation.Component;
using Client.Scripts.Models;
using Client.Scripts.Models.UI_Models;
using Client.Scripts.Services;
using Client.Scripts.UI;
using Leopotam.Ecs;
using Leopotam.Ecs.Ui.Components;
using UnityEngine;

namespace Client.Scripts.ECS_Feature.Quest_System.System
{
    internal class QuestSys : IEcsRunSystem, IEcsInitSystem
    {
        private EcsWorld _world;
        private readonly EcsFilter<QuestEvent> _questEvents;
        private readonly EcsFilter<QuestComponent> _quests;
        private readonly EcsFilter<EcsUiClickEvent> _clickAction;
        private readonly EcsFilter<GameState> _resources;
        private SceneData _sceneData;
        private Scripts.UI.UI _ui;
        private readonly StaticData _staticData;

        public void Init()
        {
            for (int i = 0; i < _staticData.Quest.Length; i++)
            {
                // Instantiate UI prefab
                var newQuestElement = Object.Instantiate(_staticData.UiQuestElement, _ui.questScreen.itemContainer.transform);
                newQuestElement.title.text = _staticData.Quest[i].Title;
                newQuestElement.clickAction.WidgetName = _staticData.Quest[i].Title;
                newQuestElement.particleSystem.externalForces.AddInfluence(_sceneData.ForceFieldsDiamonds);
                
                _ui.questScreen.questItmes.Add(newQuestElement.gameObject);
                _ui.questScreen.questItmes[i].GetComponent<QuestItem>().button.interactable = false;
                _ui.questScreen.questItmes[i].GetComponent<QuestItem>().clickAction.enabled = false;

                //Create Quest entity
                var quest = _world.NewEntity();
                quest.Get<QuestComponent>().Award = _staticData.Quest[i].DiamondsReward;
                quest.Get<QuestComponent>().Title = _staticData.Quest[i].Title;
                quest.Get<QuestComponent>().QuestType = _staticData.Quest[i].Objective.ToString();
                quest.Get<QuestComponent>().QuestRequirementCount = _staticData.Quest[i].QuestRequirementCount;
                quest.Get<QuestComponent>().ParticleSystem = _ui.questScreen.questItmes[i].GetComponent<QuestItem>().particleSystem;
                quest.Get<QuestComponent>().ParticleSpawnPoint = _ui.questScreen.questItmes[i].GetComponent<QuestItem>().particleSpawnPoint;
            } 
            foreach (var index in _quests)
            {
                ref var quest = ref _quests.Get1(index);
                quest.IsDone = false;
                _ui.questScreen.questItmes[index].GetComponent<QuestItem>().questObjectiveCurrent.text = quest.QuestObjectiveCount + "/" + quest.QuestRequirementCount;
                _ui.questScreen.questItmes[index].GetComponent<QuestItem>().fillBar.fillAmount = quest.QuestObjectiveCount / quest.QuestRequirementCount;
            }
        }

        public void Run()
        {
            
            if (!_questEvents.IsEmpty())
            {
                ref var questEventEntity = ref _questEvents.GetEntity(0);

                foreach (var index in _quests)
                {
                    ref var quest = ref _quests.Get1(index);

                    if (quest.QuestType == questEventEntity.Get<QuestEvent>().QuestType)
                    {
                        quest.QuestObjectiveCount = questEventEntity.Get<QuestEvent>().Value;

                        if (!quest.IsDone)
                        {
                          _ui.questScreen.questItmes[index].GetComponent<QuestItem>().questObjectiveCurrent.text = quest.QuestObjectiveCount + "/" + quest.QuestRequirementCount;
                          _ui.questScreen.questItmes[index].GetComponent<QuestItem>().fillBar.fillAmount = quest.QuestObjectiveCount / quest.QuestRequirementCount;  
                        }

                        if (quest.QuestObjectiveCount >= quest.QuestRequirementCount)
                        {
                            quest.IsDone = true;
                            quest.QuestDoneCount++;
                            quest.QuestRequirementCount *= 2;
                            _ui.questScreen.questItmes[index].GetComponent<QuestItem>().button.interactable = true;
                            _ui.questScreen.questItmes[index].GetComponent<QuestItem>().clickAction.enabled = true;
                            questEventEntity.Del<QuestEvent>();
                        }
                        questEventEntity.Del<QuestEvent>();
                    }
                }
                questEventEntity.Del<QuestEvent>();
            }


            // Pick reward by click button and update UI
            foreach (var index in _quests)
            {
                if (_clickAction.IsEmpty()) return;

                ref var quest = ref _quests.Get1(index);
                ref var res = ref _resources.Get1(0);
                ref var clickData = ref _clickAction.GetEntity(0);

                if (clickData.Get<EcsUiClickEvent>().WidgetName == _ui.questScreen.questItmes[index].GetComponent<QuestItem>().title.text && quest.QuestDoneCount > 0)
                {
                    quest.QuestDoneCount--;
                    res.diamonds += quest.Award;
                    _ui.mainScreen.diamondsAmountText.text = res.diamonds.ToString();
                    _ui.questScreen.questItmes[index].GetComponent<QuestItem>().particleSystem.Play();
                    clickData.Del<EcsUiClickEvent>();
                    _ui.diamondsUIParticleSystem.GetComponent<RectTransform>().anchoredPosition = WorldToScreenConvertor.WorldToCanvasSpace(_ui.mainCanvasRect, _sceneData.UiCamera, quest.ParticleSpawnPoint.position);
                                            _ui.diamondsUIParticleSystem.Play();
                    if (quest.QuestDoneCount <= 0)
                    {
                        quest.IsDone = false;
                        _ui.questScreen.questItmes[index].GetComponent<QuestItem>().fillBar.fillAmount = quest.QuestObjectiveCount / quest.QuestRequirementCount;
                        _ui.questScreen.questItmes[index].GetComponent<QuestItem>().questObjectiveCurrent.text = quest.QuestObjectiveCount + "/" + quest.QuestRequirementCount;
                        _ui.questScreen.questItmes[index].GetComponent<QuestItem>().button.interactable = false;
                        _ui.questScreen.questItmes[index].GetComponent<QuestItem>().clickAction.enabled = false;
                        
                    }
                }
            }
        }
    }
}