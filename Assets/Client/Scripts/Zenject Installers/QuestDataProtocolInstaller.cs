using Client.Scripts.Protocols;
using Client.Scripts.Protocols.Interfaces;
using Zenject;

namespace Client.Scripts.Zenject_Installers
{
    public class QuestDataProtocolInstaller : MonoInstaller<QuestDataProtocolInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IQuestDataProtocol>().To<QuestDataProtocol>().AsSingle().NonLazy();
        }
    }
}