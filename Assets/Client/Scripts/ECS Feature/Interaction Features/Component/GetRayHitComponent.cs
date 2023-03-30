using UnityEngine;

namespace Client.Scripts.ECS.Components
{
    public struct GetRayHitComponent
    {
        public RaycastHit RayInfo;
        public RaycastHit CenterRayInfo;
    }
}
