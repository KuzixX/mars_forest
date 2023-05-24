using System;
using UnityEngine;

namespace Client.Scripts.ECS_Feature.Common_Сomponents
{
    [Serializable]
    public struct Cell
    {
        public GameObject lightingCell;
        public String cellType;
    }
}