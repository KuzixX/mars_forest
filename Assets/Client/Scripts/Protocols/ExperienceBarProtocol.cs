using Client.Scripts.Protocols.Interface;
using Client.Scripts.Protocols.Interfaces;
using UniRx;

namespace Client.Scripts.Protocols
{
    public class ExperienceBarProtocol : IExperienceBarProtocol
    {
        public ReactiveProperty<int> CurrentXp { get; set; }
        public ReactiveProperty<float[]> TargetXp { get; set; }
        public ReactiveProperty<int> CurrentLevel { get; set; }
        public ReactiveProperty<int> MaxLevel { get; set; }
        public ReactiveProperty<float> FillPercent { get; set; }
        public string ViewXp { get; set; }

        ExperienceBarProtocol()
        {
            CurrentLevel = new ReactiveProperty<int>();
            CurrentXp = new ReactiveProperty<int>();
            TargetXp = new ReactiveProperty<float[]>();
            MaxLevel = new ReactiveProperty<int>();
            FillPercent = new ReactiveProperty<float>();
        }
    }
}