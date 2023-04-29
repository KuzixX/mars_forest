using Client.Scripts.Protocols;
using Client.Scripts.Protocols.Interface;
using Zenject;

namespace Client.Scripts.Zenject_Installers
{
    public class ExperienceBarProtocolInstaller : MonoInstaller<ExperienceBarProtocolInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IExperienceBarProtocol>().To<ExperienceBarProtocol>().AsSingle().NonLazy();
        }
    }
}