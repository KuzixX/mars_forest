using Client.Scripts.ECS_Feature.Common_Сomponents;
using Client.Scripts.ECS_Feature.Experience_Bar.Component;
using Client.Scripts.Models;
using Client.Scripts.Services;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Scripts.ECS_Feature.Experience_Bar.System
{
    internal class ExperienceBar : IEcsRunSystem, IEcsInitSystem
    {
        private readonly EcsFilter<ExperienceBarComponent> _expBarComponent;
        private readonly EcsFilter<GameStateChange> _event;
        private EcsWorld _world;

        public void Init()
        {
            _world.NewEntity().Get<ExperienceBarComponent>();
            ref var experienceBar = ref _expBarComponent.Get1(0);
            experienceBar.MaxLevel = 100;
            experienceBar.CurrentLevel = 0;
            experienceBar.CurrentXp = 0;
            experienceBar.TargetXp = ExperienceCalculator.CalculateXp(experienceBar.MaxLevel);
        }
        public void Run()
        {
            ref var expBar = ref _expBarComponent.Get1(0);

            foreach (var idx in _event)
            {
                ref var expEvent = ref _event.Get1(idx);

                if (expEvent.EventType == GameStateEvents.ExperienceAdd)
                {
                    expBar.CurrentXp += expEvent.Value;

                    if (expBar.CurrentXp != 0)
                    {
                        expBar.FillPercent = expBar.CurrentXp / expBar.TargetXp[expBar.CurrentLevel];
                        expBar.ViewXp = $"{expBar.CurrentXp} / {expBar.TargetXp[expBar.CurrentLevel]}";
                    }   
                }

                if (!(expBar.CurrentXp >= expBar.TargetXp[expBar.CurrentLevel])) continue;
                expBar.CurrentLevel += 1;
                expBar.CurrentXp = 0;
                expBar.TargetXp[expBar.CurrentLevel] = expBar.TargetXp[expBar.CurrentLevel + 1];

            }
        }
    }
}