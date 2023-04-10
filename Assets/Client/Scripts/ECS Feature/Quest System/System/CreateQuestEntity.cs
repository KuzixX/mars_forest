using Client.Scripts.Data;
using Client.Scripts.ECS.Components;
using Client.Scripts.MonoBehaviors.UI;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Scripts.ECS_Feature.Quest_System.System
{
    internal class CreateQuestEntity : IEcsInitSystem
    {
        private StaticData _staticData;
        private SceneData _sceneData;
        private MonoBehaviors.UI.UI _ui;
        private EcsWorld _world;
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
        }
    }
}