using Client.Scripts.Protocols.Interfaces;
using UniRx;

namespace Client.Scripts.Protocols
{
    public class GameStateProtocol: IGameStateProtocol
    {
        public ReactiveProperty<double> Gold { get; set; }
        public ReactiveProperty<double> Experience { get; set; }
        public ReactiveProperty<double> Diamonds { get; set; }
        public ReactiveProperty<int> CellObjectsCount { get; set; }
        public ReactiveProperty<int> GameLevel { get; set; }
        public ReactiveProperty<string> ViewXp { get; set; }

        GameStateProtocol()
        {
            Gold = new ReactiveProperty<double>();
            Experience = new ReactiveProperty<double>();
            Diamonds = new ReactiveProperty<double>();
            CellObjectsCount = new ReactiveProperty<int>();
            GameLevel = new ReactiveProperty<int>();
            ViewXp = new ReactiveProperty<string>();
        }
    }
}