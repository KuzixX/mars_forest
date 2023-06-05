using UniRx;

namespace Client.Scripts.Protocols.Interfaces
{
    public interface IQuestDataProtocol
    {
        public ReactiveProperty<double> Gold { get; set; }
        public ReactiveProperty<double> Experience { get; set; }
        public ReactiveProperty<double> Diamonds { get; set; }
        public ReactiveProperty<int> CellObjects { get; set; }
        public ReactiveProperty<int> GameLevel { get; set; }
    }
}