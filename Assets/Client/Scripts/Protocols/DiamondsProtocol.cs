using Client.Scripts.Protocols.Interfaces;
using UniRx;

namespace Client.Scripts.Protocols
{
    public class DiamondsProtocol :IDiamondsProtocol
    {
        public ReactiveProperty<double> Diamonds { get; set; }

        private DiamondsProtocol()
        {
            Diamonds = new ReactiveProperty<double>();
        }
    }
}