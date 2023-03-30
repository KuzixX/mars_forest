using Client.Scripts.ECS_Feature.Init;
using Client.Scripts.ECS.Components;
using Client.Scripts.ECS.Components.EventCoponents;
using Client.Scripts.MonoBehaviors.UI;
using ECS.Components.EventCoponents;
using ECS.System;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Scripts.ECS.System
{
    internal class ExpBarSystem : IEcsRunSystem
    {
        private UI _ui;
        private readonly EcsFilter<ExpBarComponent> _expBarComponent;
        private readonly EcsFilter<OnExpEvent> _expEvent;
        private readonly EcsFilter<EventEntityTag> _uiEventEntity;

        public void Run()
        {
            ref var expBar = ref _expBarComponent.GetEntity(0);
            ref var exp = ref _expEvent.Get1(0);
            ref var eventEntity = ref _uiEventEntity.GetEntity(0);

            if (!_expEvent.IsEmpty())
            {
                expBar.Get<ExpBarComponent>().CurrentXp += exp.ExpAmount;
                eventEntity.Get<ChangeUI>().EventDescription = "ExpBar";
                if (expBar.Get<ExpBarComponent>().CurrentXp != 0)
                {
                    expBar.Get<ExpBarComponent>().FillPercent = expBar.Get<ExpBarComponent>().CurrentXp / expBar.Get<ExpBarComponent>().TargetXp[expBar.Get<ExpBarComponent>().CurrentLevel];
                    eventEntity.Get<ChangeUI>().EventDescription = "ExpBar";
                }
            }

            if (expBar.Get<ExpBarComponent>().CurrentXp >= expBar.Get<ExpBarComponent>().TargetXp[expBar.Get<ExpBarComponent>().CurrentLevel])
            {
                expBar.Get<ExpBarComponent>().CurrentLevel += 1;
                expBar.Get<QuestEvent>().QuestType = "GameLevel";
                expBar.Get<QuestEvent>().Value = expBar.Get<ExpBarComponent>().CurrentLevel;
                expBar.Get<ExpBarComponent>().CurrentXp = 0;
                expBar.Get<ExpBarComponent>().TargetXp[expBar.Get<ExpBarComponent>().CurrentLevel] = expBar.Get<ExpBarComponent>().TargetXp[expBar.Get<ExpBarComponent>().CurrentLevel + 1];
                eventEntity.Get<ChangeUI>().EventDescription = "ExpBarIsTargetExp";
            }
        }
    }
    
}