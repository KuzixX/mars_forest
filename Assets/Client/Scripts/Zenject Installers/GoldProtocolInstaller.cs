using Client.Scripts.Protocols;
using Client.Scripts.Protocols.Interfaces;
using Zenject;

namespace Client.Scripts.Zenject_Installers
{
    public class GoldProtocolInstaller : MonoInstaller<GoldProtocolInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IGoldProtocol>().To<GoldProtocol>().AsSingle().NonLazy();
        }
    }
}