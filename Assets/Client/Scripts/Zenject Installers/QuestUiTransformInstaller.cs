using Client.Scripts.Protocols;
using UnityEngine;
using Zenject;

namespace Client.Scripts.Zenject_Installers
{
    public class QuestUiTransformInstaller : MonoInstaller<QuestUiTransformInstaller>
    {
        [SerializeField] private QuestContainerTransform container;
        public override void InstallBindings()
        {
            Container.Bind<QuestContainerTransform>().FromInstance(container).AsSingle().NonLazy();
        }
    }
}