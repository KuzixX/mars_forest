using Client.Scripts.Models;
using UnityEngine;
using UnityEngine.AI;

namespace Client.Scripts.Features.Delivery_Unit.Components
{
    internal struct DeliveryUnit
    {
        public NavMeshAgent NavMeshAgent;
        public bool         IsBusy;
        public Events       CargoType;
        public int          CargoAmount;
        public Collider     Collider;
        public int          TargetId;
    }
}