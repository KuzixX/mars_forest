using Client.Scripts.Protocols;
using Client.Scripts.Protocols.Interfaces;
using Zenject;

namespace Client.Scripts.Zenject_Installers
{
    public class ExperienceProtocolInstaller : MonoInstaller<ExperienceProtocolInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IExperienceProtocol>().To<ExperienceProtocol>().AsSingle().NonLazy();
        }
    }
}