using System;
using UnityEngine;

namespace Client.Scripts.ECS.Components
{
    [Serializable]
    public struct SecondOrderComponent
    {
        public float xp, zp; // previous input
        public float y, yd, y00, yd00; // state variables
        public float k1, k2, k3; // dynemics constant
        public float xd, zd;
        public float T;

        public float deltaValueZ;
        public float deltaValueX;
        public float lastFrameValueZ;
        public float lastFrameValueX;

        [Range(0, 10)] public float f;
        [Range(0, 10)] public float z;
        [Range(0, 10)] public float r;
    }
}