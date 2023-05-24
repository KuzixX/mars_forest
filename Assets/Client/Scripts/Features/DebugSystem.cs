using Leopotam.Ecs;
using UnityEngine;

namespace Client.Scripts.ECS_Feature
{
    internal class DebugSystem : IEcsRunSystem
    {
        private readonly EcsFilter<EcsCommand> _cmd;
        public void Run()
        {
            if(_cmd.IsEmpty()) return;
            var cmd = _cmd.Get1(0);
            Debug.Log(cmd.CommandDescription);
        }
    }
}