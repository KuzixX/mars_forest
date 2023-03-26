using System;
using UnityEngine;

namespace Client.Scripts.ECS.Components
{
    [Serializable]
    public struct MoveCameraComponent
    {
        public Vector3 tempDelta;
        public float distance;
        public float currentDistance;
        public Vector3 delta;
        public float timer;
        public float interpolationTime;
        public float dragSpeed;
        public AnimationCurve curve;
    }
}