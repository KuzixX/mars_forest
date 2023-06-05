using Client.Scripts.Commands.interfaces;
using Client.Scripts.Features.Common_Сomponents;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

namespace Client.Scripts.Commands
{
    internal class EcsEventStringCommand : MonoBehaviour, IStringCommand
    {
        private EcsWorld _world;
        public void Execute(string commandDescription) 
        {
        _world = WorldHandler.GetWorld();
        var cmd = _world.NewEntity();
        cmd.Get<EcsStringCommand>().CommandDescription = commandDescription; 
        }
    }
}