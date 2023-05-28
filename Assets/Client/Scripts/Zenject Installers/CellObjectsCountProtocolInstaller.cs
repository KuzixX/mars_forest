using Client.Scripts.Protocols;
using Client.Scripts.Protocols.Interfaces;
using Zenject;

namespace Client.Scripts.Zenject_Installers
{
    public class CellObjectsCountProtocolInstaller : MonoInstaller<CellObjectsCountProtocolInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<ICellObjectCountProtocol>().To<CellObjectCountProtocol>().AsSingle().NonLazy();
        }
    }
}