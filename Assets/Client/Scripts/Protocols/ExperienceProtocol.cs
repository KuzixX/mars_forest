using Client.Scripts.Protocols.Interfaces;
using UniRx;

namespace Client.Scripts.Protocols
{
    public class ExperienceProtocol : IExperienceProtocol
    {
        public ReactiveProperty<double> Experience { get; set; }

        private ExperienceProtocol()
        {
            Experience = new ReactiveProperty<double>();
        }
    }
}