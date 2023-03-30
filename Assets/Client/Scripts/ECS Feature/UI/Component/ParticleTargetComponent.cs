using System;
using UnityEngine;

namespace Client.Scripts.ECS.Components {
    [Serializable]
    public struct ParticleTargetComponent
    {
        public ParticleSystemForceField particleTarget;
        public String name;
    }
}