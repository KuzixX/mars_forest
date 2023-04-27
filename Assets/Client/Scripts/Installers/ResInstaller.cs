using Client.Scripts.ECS_Feature_rebuild;
using Client.Scripts.Interface;
using Zenject;

namespace Client.Scripts.Installers
{
    public class ResInstaller : MonoInstaller<ResInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IResourcesProtocol>().To<GameResources>().AsSingle().NonLazy();
        }
    }
}