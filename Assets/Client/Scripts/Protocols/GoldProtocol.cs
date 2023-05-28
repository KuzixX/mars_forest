using Client.Scripts.Protocols.Interfaces;
using UniRx;

namespace Client.Scripts.Protocols
{
    public class GoldProtocol : IGoldProtocol
    {
        public ReactiveProperty<double> Gold { get; set; }

        private GoldProtocol()
        {
            Gold = new ReactiveProperty<double>();
        }
    }
}