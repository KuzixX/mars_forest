using System;
using UnityEngine;

namespace Client.Scripts.ECS.Components
{
    internal struct SpawnTreeData
    {
        public GameObject TreePrefab;
        public String TreeName;
        public float ProductionCycleTime;
        public int Price;
        public int ExpAmount;
        public int Id;
    }
}