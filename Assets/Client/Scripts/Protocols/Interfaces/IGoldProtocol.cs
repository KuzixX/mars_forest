using UniRx;

namespace Client.Scripts.Protocols.Interfaces
{
    public interface IGoldProtocol
    {
        public ReactiveProperty<double> Gold { get; set; }
    }
}