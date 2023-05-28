using UniRx;

namespace Client.Scripts.Protocols.Interfaces
{
    public interface ICellObjectCountProtocol
    {
        public ReactiveProperty<int> CellObjectsCount { get; set; }
    }
}