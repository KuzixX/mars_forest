using UniRx;

namespace Client.Scripts.Protocols.Interfaces
{
    public interface IGameLevelProtocol
    {
        public ReactiveProperty<int> GameLevel { get; set; }
    }
}