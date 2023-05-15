using Client.Scripts.ECS_Feature.Common_Сomponents;
using Client.Scripts.ECS_Feature.Experience_Bar.Component;
using Client.Scripts.Models;
using Client.Scripts.Protocols.Interfaces;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Scripts.ECS_Feature.Projection_Systems.System
{
    internal class ExperienceBarProjection : IEcsRunSystem
    {
        private readonly EcsFilter<ExperienceBarComponent> _filter;
        private IExperienceBarProtocol _experienceBarProtocol;
        private readonly EcsFilter<GameStateChange> _gameState;

        public ExperienceBarProjection(IExperienceBarProtocol experienceBarProtocol)
        {
            _experienceBarProtocol = experienceBarProtocol;
        }
        public void Run()
        {
            foreach (var idx in _gameState)
            {
                ref var gameStateEvent = ref _gameState.Get1(idx);

                if (gameStateEvent.EventType != GameStateEvents.ExperienceAdd) continue;
                ref var experienceBar = ref _filter.Get1(0);
                    
                _experienceBarProtocol.CurrentLevel.Value = experienceBar.CurrentLevel;
                _experienceBarProtocol.FillPercent.Value = experienceBar.FillPercent;
                _experienceBarProtocol.MaxLevel.Value = experienceBar.MaxLevel;
                _experienceBarProtocol.TargetXp.Value = experienceBar.TargetXp;
                _experienceBarProtocol.ViewXp= experienceBar.ViewXp;
                _experienceBarProtocol.CurrentXp.Value = experienceBar.CurrentXp;
            }
        }
    }
}