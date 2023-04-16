using Client.Scripts.Data;
using Client.Scripts.ECS_Feature_rebuild.Quest_System.Component;
using Client.Scripts.ECS_Feature_rebuild.Resources_Generation;
using Client.Scripts.ECS_Feature.Init;
using Client.Scripts.ECS.Components;
using Client.Scripts.ECS.Components.EventCoponents;
using Client.Scripts.MonoBehaviors;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Scripts.ECS_Feature.Pick_Gold_System
{
    internal class PickGold : IEcsRunSystem, IEcsInitSystem
    {
        private MonoBehaviors.UI.UI _ui;
        private StaticData _staticData;
        private readonly EcsFilter<CellObject, IsFull> _trees;
        private readonly EcsFilter<PickGoldComponent> _pickGold;
        private readonly EcsFilter<InGameResources> _resources;
        private readonly EcsFilter<EventEntityTag> _eventEntity;
        private readonly SceneData _sceneData;

        public void Run()
        {
            ref var pickGold = ref _pickGold.Get1(0);
            ref var resources = ref _resources.Get1(0);
            ref var eventEntity = ref _eventEntity.GetEntity(0);
            if (!_trees.IsEmpty())
            {
                // Pick gold automatic
                pickGold.PickCycleTime = 4;
                pickGold.CurrentCycleState += Time.deltaTime;
                if (pickGold.CurrentCycleState != 0)
                {
                    _ui.mainScreen.getGoldBtnFill.fillAmount = pickGold.CurrentCycleState / pickGold.PickCycleTime;
                }

                foreach (var index in _trees)
                {
                    if (pickGold.CurrentCycleState >= pickGold.PickCycleTime)
                    {
                        ref var tree = ref _trees.GetEntity(index);
                        for (int i = 0; i < _staticData.TreesData.Length; i++)
                        {
                            if (tree.Get<CellObject>().title == _staticData.TreesData[i].Title)
                            {
                                resources.gold += tree.Get<CellObject>().level * _staticData.TreesData[i].AmountOfProduct / 2;
                                _ui.goldUIParticleSystem.GetComponent<RectTransform>().anchoredPosition = WorldToScreenConvertor.WorldToCanvasSpace(_ui.mainCanvasRect, _sceneData.MainCamera, tree.Get<CellObject>().spawnPoint.position);
                                _ui.goldUIParticleSystem.Play();
                                tree.Del<IsFull>();
                                // Quest events
                                tree.Get<QuestEvent>().QuestType = "Gold";
                                tree.Get<QuestEvent>().Value = resources.gold;
                                eventEntity.Get<ChangeUI>().EventDescription = "ResBar";
                                // _ui.mainScreen.goldAmountText.text = resources.gold.ToString();
                            }
                        }
                        pickGold.CurrentCycleState = 0;
                    }
                }
            }
        }

        public void Init()
        {
            _ui.mainScreen.pickGoldBtn.onClick.AddListener(() =>
            {
                ref var pickGold = ref _pickGold.Get1(0);
                pickGold.CurrentCycleState += 0.5f;
            });
        }
    }
}

