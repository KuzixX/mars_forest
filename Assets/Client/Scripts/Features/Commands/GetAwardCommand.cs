using Client.Scripts.Features.Common_Сomponents;
using Client.Scripts.Models;
using Leopotam.Ecs;
using Voody.UniLeo;

namespace Client.Scripts.Features.Commands
{
    public class GetAwardCommand
    {
        private EcsWorld _world;
        public void Execute(Events type, int amount)
        {
            _world = WorldHandler.GetWorld();
            var cmd = _world.NewEntity();
            cmd.Get<GameStateChange>().EventType = type;
            cmd.Get<GameStateChange>().Value = amount;
        }
    }
}