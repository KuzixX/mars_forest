using System;
using UnityEngine;

namespace Client.Scripts.ECS.Components
{
    [Serializable]
    public struct Position
    {
        public Transform transform;
    }
}