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
            var experienceBar = _world.NewEntity();
            experienceBar.Get<ExperienceBarComponent>().MaxLevel = 100;
            experienceBar.Get<ExperienceBarComponent>().CurrentLevel = 0;
            experienceBar.Get<ExperienceBarComponent>().TargetXp = ExperienceCalculator.CalculateXp(experienceBar.Get<ExperienceBarComponent>().MaxLevel);
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
                        Debug.Log("Exp changed bar");
                        expBar.FillPercent = expBar.CurrentXp / expBar.TargetXp[expBar.CurrentLevel];
                        expBar.ViewXp = $"{expBar.CurrentXp} / {expBar.TargetXp[expBar.CurrentLevel]}";
                    }   
                }

                if (!(expBar.CurrentXp >= expBar.TargetXp[expBar.CurrentLevel])) continue;
                expBar.CurrentLevel += 1;
                expBar.TargetXp[expBar.CurrentLevel] = expBar.TargetXp[expBar.CurrentLevel + 1];
                expBar.CurrentXp -= (int)expBar.TargetXp[expBar.CurrentLevel - 1];
                expBar.FillPercent = expBar.CurrentXp / expBar.TargetXp[expBar.CurrentLevel];
                expBar.ViewXp = $"{expBar.CurrentXp} / {expBar.TargetXp[expBar.CurrentLevel]}";
            }
        }
    }
}