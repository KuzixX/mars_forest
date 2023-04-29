using Client.Scripts.ECS_Feature.Experience_Bar.Component;
using Client.Scripts.ECS_Feature.Resources_Generation;
using Client.Scripts.ECS_Feature.Resources_Generation.Component;
using Client.Scripts.Protocols.Interface;
using Leopotam.Ecs;
using UnityEngine;
using Zenject;

namespace Client.Scripts.ECS_Feature.Experience_Bar.System
{
    internal class ExperienceBar : IEcsRunSystem, IEcsInitSystem
    {
        private Scripts.UI.UI _ui;
        private readonly EcsFilter<ExperienceBarComponent> _expBarComponent;
        private readonly EcsFilter<GameState> _gameStateData;
        private EcsWorld _world;

        public void Init()
        {
            _world.NewEntity().Get<ExperienceBarComponent>();
            
            ref var experienceBar = ref _expBarComponent.Get1(0);
            experienceBar.MaxLevel = 100;
            experienceBar.CurrentLevel = 0;
            experienceBar.TargetXp = new float[experienceBar.MaxLevel];
            
            _ui.mainScreen.expBarAmountText.text = experienceBar.CurrentXp + "/" + experienceBar.TargetXp[experienceBar.CurrentLevel];
            _ui.mainScreen.expFillImage.fillAmount = 0;
            
            for (int i = 0; i < experienceBar.MaxLevel; i++)
            {
                experienceBar.TargetXp[i] = Mathf.Pow(i / 0.05f, 2);
            }
        }
        public void Run()
        {
            ref var expBar = ref _expBarComponent.GetEntity(0);
            ref var gameResources = ref _gameStateData.Get1(0);
                
            expBar.Get<ExperienceBarComponent>().CurrentXp += gameResources.experience;
            
            if (expBar.Get<ExperienceBarComponent>().CurrentXp != 0)
            {
                expBar.Get<ExperienceBarComponent>().FillPercent = expBar.Get<ExperienceBarComponent>().CurrentXp / expBar.Get<ExperienceBarComponent>().TargetXp[expBar.Get<ExperienceBarComponent>().CurrentLevel];
            }
            
            if (expBar.Get<ExperienceBarComponent>().CurrentXp >= expBar.Get<ExperienceBarComponent>().TargetXp[expBar.Get<ExperienceBarComponent>().CurrentLevel])
            {
                expBar.Get<ExperienceBarComponent>().CurrentLevel += 1;
                expBar.Get<ExperienceBarComponent>().CurrentXp = 0;
                expBar.Get<ExperienceBarComponent>().TargetXp[expBar.Get<ExperienceBarComponent>().CurrentLevel] = expBar.Get<ExperienceBarComponent>().TargetXp[expBar.Get<ExperienceBarComponent>().CurrentLevel + 1];
            }
        }
    }
    
}