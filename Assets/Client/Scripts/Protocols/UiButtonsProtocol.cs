using Client.Scripts.Protocols.Interfaces;

namespace Client.Scripts.Protocols
{
    public class UiButtonsProtocol : IUiButtonsProtocol
    {
        public bool PickGoldBtn { get; set; }
        public bool UpLevelBtn { get; set; }
    }
}