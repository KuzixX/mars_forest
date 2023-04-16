using Client.Scripts.ECS_Feature_rebuild.Quest_System.Component;
using Client.Scripts.ECS_Feature.Init;
using Client.Scripts.ECS.Components;
using Client.Scripts.ECS.Components.EventCoponents;
using ECS.Components.EventCoponents;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Scripts.ECS_Feature.UI.System
{
    internal class ExperienceBar : IEcsRunSystem, IEcsInitSystem
    {
        private MonoBehaviors.UI.UI _ui;
        private readonly EcsFilter<ExpBarComponent> _expBarComponent;
        private readonly EcsFilter<OnExpEvent> _expEvent;
        private readonly EcsFilter<EventEntityTag> _uiEventEntity;

        public void Init()
        {
            ref var expBar = ref _expBarComponent.Get1(0);
            expBar.MaxLevel = 100;
            expBar.CurrentLevel = 0;
            expBar.TargetXp = new float[expBar.MaxLevel];
            _ui.mainScreen.expBarAmountText.text = expBar.CurrentXp + "/" + expBar.TargetXp[expBar.CurrentLevel];
            _ui.mainScreen.expFillImage.fillAmount = 0;
            
            for (int i = 0; i < expBar.MaxLevel; i++)
            {
                expBar.TargetXp[i] = Mathf.Pow(i / 0.05f, 2);
            }
        }
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