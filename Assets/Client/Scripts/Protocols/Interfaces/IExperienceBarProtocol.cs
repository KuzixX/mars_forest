using UniRx;

namespace Client.Scripts.Protocols.Interfaces
{
    public interface IExperienceBarProtocol
    {
        public ReactiveProperty<int> CurrentXp { get; set; }
        public ReactiveProperty<float[]> TargetXp { get; set; }
        public ReactiveProperty<int> CurrentLevel { get; set; }
        public ReactiveProperty<int> MaxLevel { get; set; }
        public ReactiveProperty<float> FillPercent { get; set; }
        public string ViewXp { get; set; }
    }
}