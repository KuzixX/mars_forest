using Client.Scripts.Features;
using Zenject;

namespace Client.Scripts.Zenject_Installers
{
    public class EcsStartupInstaller : MonoInstaller<EcsStartupInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<Startup>().AsSingle().NonLazy();
        }
    }
}