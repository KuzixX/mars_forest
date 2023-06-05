using Client.Scripts.Services.EventBus;
using Zenject;

namespace Client.Scripts.Zenject_Installers
{
    public class EventBusInstaller : MonoInstaller<EventBusInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<EventBus>().AsSingle().NonLazy();
        }
    }
}