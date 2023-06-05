using Client.Scripts.Protocols.Interfaces;
using UniRx;

namespace Client.Scripts.Protocols
{
    public class QuestDataProtocol : IQuestDataProtocol
    {
        public ReactiveProperty<double>  Gold { get; set; }
        public ReactiveProperty<double>  Experience { get; set; }
        public ReactiveProperty<double>  Diamonds { get; set; }
        public ReactiveProperty<int>     CellObjects { get; set; }
        public ReactiveProperty<int>     GameLevel { get; set; }

        private QuestDataProtocol()
        {
            Gold = new ReactiveProperty<double>();
            Experience = new ReactiveProperty<double>();
            Diamonds = new ReactiveProperty<double>();
            CellObjects = new ReactiveProperty<int>();
            GameLevel = new ReactiveProperty<int>();
        }
    }
}