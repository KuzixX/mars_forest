using Client.Scripts.Commands.interfaces;
using Client.Scripts.ECS_Feature;
using Client.Scripts.Features.Common_Сomponents;
using Client.Scripts.Models;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

namespace Client.Scripts.Commands
{
    internal class EcsEventCommand : MonoBehaviour, ICommand
    {
        private EcsWorld _world;
        public void Execute(string commandDescription) 
        {
        _world = WorldHandler.GetWorld();
        var cmd = _world.NewEntity();
        cmd.Get<EcsCommand>().CommandDescription = commandDescription; 
        }
    }
}