using UniRx;

namespace Client.Scripts.Interface
{
    public interface IResourcesProtocol
    {
        public ReactiveProperty<int> Gold { get; set; }
        public ReactiveProperty<int> Experience { get; set; }
        public ReactiveProperty<int> Diamonds { get; set; }
    }
}