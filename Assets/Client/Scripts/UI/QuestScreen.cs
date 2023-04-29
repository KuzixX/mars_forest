using System.Collections.Generic;
using Client.Scripts.Models;
using Leopotam.Ecs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Client.Scripts.UI
{
    public class QuestScreen : Scripts.UI.Screen
    {
        [SerializeField] public Button backButton;
        [SerializeField] public TextMeshProUGUI questMenuTitle;
        [SerializeField] public GameObject itemContainer;
        [SerializeField] public List<GameObject> questItmes;

        private EcsWorld _world;
        [SerializeField] private  global::Client.Scripts.UI.UI ui;
        [SerializeField] private  StaticData staticData;
        [SerializeField] private  SceneData sceneData;

        // private void Awake()
        // {
        //     for (int i = 0; i < staticData.Quest.Length; i++)
        //     {
        //         // Instantiate UI prefab
        //         var newQuestElement = Instantiate(staticData.UiQuestElement, ui.questScreen.itemContainer.transform);
        //         newQuestElement.title.text = staticData.Quest[i].Title;
        //         newQuestElement.clickAction.WidgetName = staticData.Quest[i].Title;
        //         newQuestElement.particleSystem.externalForces.AddInfluence(sceneData.ForceFieldsDiamonds);
        //
        //         ui.questScreen.questItmes.Add(newQuestElement.gameObject);
        //         ui.questScreen.questItmes[i].GetComponent<QuestItem>().button.interactable = false;
        //         ui.questScreen.questItmes[i].GetComponent<QuestItem>().clickAction.enabled = false;
        //
        //         //Create Quest entity
        //         var quest = _world.NewEntity();
        //         quest.Get<QuestComponent>().Award = staticData.Quest[i].DiamondsReward;
        //         quest.Get<QuestComponent>().Title = staticData.Quest[i].Title;
        //         quest.Get<QuestComponent>().QuestType = staticData.Quest[i].Objective.ToString();
        //         quest.Get<QuestComponent>().QuestRequirementCount = staticData.Quest[i].QuestRequirementCount;
        //         quest.Get<QuestComponent>().ParticleSystem = newQuestElement.particleSystem;
        //         quest.Get<QuestComponent>().ParticleSpawnPoint =
        //             ui.questScreen.questItmes[i].GetComponent<QuestItem>().particleSpawnPoint;
        //     } 
        // }
    }
}