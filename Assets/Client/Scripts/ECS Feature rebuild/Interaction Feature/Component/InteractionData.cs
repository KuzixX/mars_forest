using UnityEngine;

namespace Client.Scripts.ECS_Feature_rebuild.Interaction_Feature.Component
{
    internal struct InteractionData
    {
        public Ray Ray;
        public Ray CenterRay;
        public RaycastHit RayInfo;
        public RaycastHit CenterRayInfo;
        public Vector3 CellPos;
        public Vector3 TreePos;
        public GameObject Cell;
        
    }
}