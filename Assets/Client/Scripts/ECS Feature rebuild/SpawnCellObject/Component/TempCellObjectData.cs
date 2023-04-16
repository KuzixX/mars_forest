using System;
using UnityEngine;

namespace Client.Scripts.ECS_Feature.Components
{
    internal struct TempCellObjectData
    {
        public GameObject TreePrefab;
        public String TreeName;
        public float ProductionCycleTime;
        public int Price;
        public int ExpAmount;
        public int Id;
    }
}