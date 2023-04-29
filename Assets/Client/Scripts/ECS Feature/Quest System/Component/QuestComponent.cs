using System;
using UnityEngine;

namespace Client.Scripts.ECS_Feature.Quest_System.Component
{
    internal struct QuestComponent
    {
        public String Title;
        public int Award;
        public String QuestType;
        public int CurrentRequirementCount;
        public int QuestObjectiveCount;
        public bool IsDone;
        public float OldQuestRequirementCount;
        public float QuestRequirementCount;
        public ParticleSystem ParticleSystem;
        public ParticleSystem.Particle[] Particles;
        public int NumParticlesAlive;
        public int QuestDoneCount;
        public RectTransform ParticleSpawnPoint;
    }
}