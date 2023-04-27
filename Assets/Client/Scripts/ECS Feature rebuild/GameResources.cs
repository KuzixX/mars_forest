using Client.Scripts.Interface;
using UniRx;

namespace Client.Scripts.ECS_Feature_rebuild
{
    public class GameResources: IResourcesProtocol
    {
        public ReactiveProperty<int> Gold { get; set; }
        public ReactiveProperty<int> Experience { get; set; }
        public ReactiveProperty<int> Diamonds { get; set; }

        GameResources()
        {
            Gold = new ReactiveProperty<int>();
            Experience = new ReactiveProperty<int>();
            Diamonds = new ReactiveProperty<int>();
        }
    }
}