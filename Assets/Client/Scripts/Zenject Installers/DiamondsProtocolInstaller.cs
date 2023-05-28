using Client.Scripts.Protocols;
using Client.Scripts.Protocols.Interfaces;
using Zenject;

namespace Client.Scripts.Zenject_Installers
{
    public class DiamondsProtocolInstaller : MonoInstaller<DiamondsProtocolInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IDiamondsProtocol>().To<DiamondsProtocol>().AsSingle().NonLazy();
        }
    }
}