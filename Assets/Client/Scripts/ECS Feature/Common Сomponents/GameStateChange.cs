using Client.Scripts.Models;

namespace Client.Scripts.ECS_Feature.Common_Сomponents
{
    internal struct GameStateChange
    {
        public GameStateEvents EventType;
        public int Value;
    }
}