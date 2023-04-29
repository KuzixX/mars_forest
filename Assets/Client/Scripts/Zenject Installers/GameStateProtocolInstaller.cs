using Client.Scripts.Protocols;
using Client.Scripts.Protocols.Interface;
using Zenject;

namespace Client.Scripts.Zenject_Installers
{
    public class GameStateProtocolInstaller : MonoInstaller<GameStateProtocolInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IGameStateProtocol>().To<GameStateProtocol>().AsSingle().NonLazy();
        }
    }
}