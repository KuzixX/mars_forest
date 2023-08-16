using Client.Scripts.Features.Common_Сomponents;
using Leopotam.Ecs;
using Voody.UniLeo;

namespace Client.Scripts.Features.Commands
{
    public class SpawnCraftItem
    {
        private EcsWorld _world;
        private string _description;

        public SpawnCraftItem(string description)
        {
            _description = description;
        }
        public void Execute()
        {
            _world = WorldHandler.GetWorld();
            var cmd = _world.NewEntity();
            cmd.Get<EcsStringCommand>().CommandDescription = _description; 
        }
    }
}