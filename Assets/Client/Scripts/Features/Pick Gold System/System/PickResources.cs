using Client.Scripts.ECS_Feature.Common_Сomponents;
using Client.Scripts.ECS_Feature.Common_Сomponents.Tags;
using Client.Scripts.ECS_Feature.ECS_Feature_old.UI.Component;
using Client.Scripts.ECS_Feature.Pick_Gold_System.Component;
using Client.Scripts.ECS_Feature.Resources_Generation.Component;
using Client.Scripts.Models;
using Client.Scripts.Models.UI_Models;
using Client.Scripts.Protocols;
using Client.Scripts.Protocols.Interfaces;
using Client.Scripts.Services;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Scripts.ECS_Feature.Pick_Gold_System.System
{
    internal class PickResources : IEcsRunSystem, IEcsInitSystem
    {
        private Scripts.UI.UI _ui;
        private FX _fx;
        private EcsWorld _world;
        private StaticData _staticData;
        private readonly EcsFilter<CellObject, IsFull> _trees;
        private readonly EcsFilter<PickGoldComponent> _pickGold;
        private readonly EcsFilter<GameState> _gameState;
        private readonly EcsFilter<EventEntityTag> _eventEntity;
        private readonly SceneData _sceneData;

        public void Init()
        {
            //_ui.mainScreen.pickGoldBtn.onClick.AddListener(() =>
            //{
                ref var pickGold = ref _pickGold.Get1(0);
                pickGold.CurrentCycleState += 0.5f;
            //});
        }
        public void Run()
        {
            ref var pickGold = ref _pickGold.Get1(0);
            if (_trees.IsEmpty()) return;
            // Pick gold automatic
            pickGold.PickCycleTime = 4;
            pickGold.CurrentCycleState += Time.deltaTime;
            if (pickGold.CurrentCycleState != 0)
            {
              //  _ui.mainScreen.getGoldBtnFill.fillAmount = pickGold.CurrentCycleState / pickGold.PickCycleTime;
            }

            foreach (var index in _trees)
            {
                if (!(pickGold.CurrentCycleState >= pickGold.PickCycleTime)) continue;
                ref var tree = ref _trees.GetEntity(index);
                foreach (var t in _staticData.TreesData)
                {
                    if (tree.Get<CellObject>().title != t.Title) continue;
                    var anchoredPosition = WorldToScreenConvertor.WorldToCanvasSpace(_sceneData.MainCanvasRect,
                        _sceneData.MainCamera, tree.Get<CellObject>().spawnPoint.position);
                    var stateEvent = _world.NewEntity();
                    stateEvent.Get<GameStateChange>().EventType = GameStateEvents.GoldAdd;
                    stateEvent.Get<GameStateChange>().Value = tree.Get<CellObject>().level * t.AmountOfProduct / 2;
                    tree.Get<CellObject>().isFullIcon.GetComponent<RectTransform>().anchoredPosition = anchoredPosition;
                    _fx.goldParticleSystem.GetComponent<ParticleSystem>().Play();
                                
                    tree.Del<IsFull>();
                }
                pickGold.CurrentCycleState = 0;
            }
        }
    }
}

