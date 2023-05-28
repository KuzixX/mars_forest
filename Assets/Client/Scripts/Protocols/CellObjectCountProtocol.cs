using Client.Scripts.Protocols.Interfaces;
using UniRx;

namespace Client.Scripts.Protocols
{
    public class CellObjectCountProtocol : ICellObjectCountProtocol
    {
        public ReactiveProperty<int> CellObjectsCount { get; set; }

        private CellObjectCountProtocol()
        {
            CellObjectsCount = new ReactiveProperty<int>();
        }
    }
}