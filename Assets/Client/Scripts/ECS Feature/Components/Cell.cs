using System;
using UnityEngine;

namespace Client.Scripts.ECS.Components
{
    [Serializable]
    public struct Cell
    {
        public GameObject lightingCell;
        public String cellType;
    }
}