using Client.Scripts.ECS_Feature.Experience_Bar.Component;
using Client.Scripts.Protocols.Interface;
using Leopotam.Ecs;

namespace Client.Scripts.ECS_Feature.Projection_Systems.System
{
    internal class ExperienceBarProjection : IEcsRunSystem
    {
        private readonly EcsFilter<ExperienceBarComponent> _filter;
        private IExperienceBarProtocol _experienceBarProtocol;
        public void Run()
        {
            ref var experienceBar = ref _filter.Get1(0);

            _experienceBarProtocol.CurrentLevel.Value = experienceBar.CurrentLevel;
            _experienceBarProtocol.CurrentXp.Value = experienceBar.CurrentXp;
            _experienceBarProtocol.FillPercent.Value = experienceBar.FillPercent;
            _experienceBarProtocol.MaxLevel.Value = experienceBar.MaxLevel;
            _experienceBarProtocol.TargetXp.Value = experienceBar.TargetXp;
        }
    }
}