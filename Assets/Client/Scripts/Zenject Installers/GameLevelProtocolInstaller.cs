using Client.Scripts.Protocols;
using Client.Scripts.Protocols.Interfaces;
using Zenject;

namespace Client.Scripts.Zenject_Installers
{
    public class GameLevelProtocolInstaller : MonoInstaller<GameLevelProtocolInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IGameLevelProtocol>().To<GameLevelProtocol>().AsSingle().NonLazy();
        }
    }
}