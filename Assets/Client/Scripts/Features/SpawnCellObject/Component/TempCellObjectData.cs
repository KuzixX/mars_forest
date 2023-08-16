using System;
using UnityEngine;

namespace Client.Scripts.Features.SpawnCellObject.Component
{
    internal struct TempCellObjectData
    {
        public GameObject TreePrefab;
        public String TreeName;
        public float ProductionCycleTime;
        public int Price;
        public int ExpAmount;
        public int Id;
        public int ProductAmount;
    }
}