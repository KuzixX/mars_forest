using Client.Scripts.Protocols;
using Client.Scripts.Protocols.Interfaces;
using Zenject;

namespace Client.Scripts.Zenject_Installers
{
    public class UiButtonsProtocolInstaller : MonoInstaller<UiButtonsProtocolInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IUiButtonsProtocol>().To<UiButtonsProtocol>().AsSingle().NonLazy();
        }
    }
}