using UniRx;

namespace Client.Scripts.Protocols.Interfaces
{
    public interface IExperienceProtocol
    {
        public ReactiveProperty<double> Experience { get; set; }
    }
}