using Client.Scripts.Protocols.Interface;
using UniRx;

namespace Client.Scripts.Protocols
{
    public class GameStateProtocol: IGameStateProtocol
    {
        public ReactiveProperty<int> Gold { get; set; }
        public ReactiveProperty<int> Experience { get; set; }
        public ReactiveProperty<int> Diamonds { get; set; }
        public ReactiveProperty<int> CellObjectsCount { get; set; }
        public ReactiveProperty<int> GameLevel { get; set; }
        public ReactiveProperty<string> ViewXp { get; set; }

        GameStateProtocol()
        {
            Gold = new ReactiveProperty<int>();
            Experience = new ReactiveProperty<int>();
            Diamonds = new ReactiveProperty<int>();
            CellObjectsCount = new ReactiveProperty<int>();
            GameLevel = new ReactiveProperty<int>();
            ViewXp = new ReactiveProperty<string>();
        }
    }
}