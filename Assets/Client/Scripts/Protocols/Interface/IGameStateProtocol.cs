using UniRx;

namespace Client.Scripts.Protocols.Interface
{
    public interface IGameStateProtocol
    {
        public ReactiveProperty<int> Gold { get; set; }
        public ReactiveProperty<int> Experience { get; set; }
        public ReactiveProperty<int> Diamonds { get; set; }
        public ReactiveProperty<int> CellObjectsCount { get; set; }
        public ReactiveProperty<int> GameLevel { get; set; }
    }
}