using Client.Scripts.Protocols.Interfaces;
using UniRx;

namespace Client.Scripts.Protocols
{
    public class GameLevelProtocol : IGameLevelProtocol
    {
        public ReactiveProperty<int> GameLevel { get; set; }

        private GameLevelProtocol()
        {
            GameLevel = new ReactiveProperty<int>();
        }
    }
}