using System;
using UnityEngine;

namespace Client.Scripts.ECS.Components
{
    [Serializable]
    public struct CellObject
    {
        public String title;
        public int id;
        public float lvlTitleOffset;
        public float lifeTimeLvlUpTitle;
        public GameObject treePrefab;
        public float currentCycleState;
        public GameObject isFullIcon;
        public GameObject levelUpTitle;
        public RectTransform levelUpTitleRectPos;
        public RectTransform isFullIconRectPos;
        public GameObject isSelected;
        public Transform spawnPoint;
        public ParticleSystem expParticleSystem;
        public int numParticlesAlive;
        public int upgradePrice;
        public ParticleSystem.Particle[] Particles;
        public int level;
    }
}