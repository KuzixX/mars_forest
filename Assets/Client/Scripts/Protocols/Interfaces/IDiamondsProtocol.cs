using UniRx;

namespace Client.Scripts.Protocols.Interfaces
{
    public interface IDiamondsProtocol
    {
        public ReactiveProperty<double> Diamonds { get; set; }
    }
}