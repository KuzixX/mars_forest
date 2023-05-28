using Client.Scripts.Features.Common_Сomponents;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Scripts.Features
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