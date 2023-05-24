using System;
using UnityEngine;

namespace Client.Scripts.ECS_Feature.Common_Сomponents
{
    [Serializable]
    public struct CellObject
    {
        public int id;
        public int level;
        public int upgradePrice;
        public int expAmount;
        public bool isExpGot;
        public string title;
        public float currentCycleState;
        public float lifeTimeLvlUpTitle;
        public GameObject isSelected;
        public GameObject treePrefab;
        public GameObject isFullIcon;
        public Transform spawnPoint;
        public GameObject levelUpTitle;
        public RectTransform levelUpTitleRectPos;
        public RectTransform isFullIconRectPos;
        public RectTransform canvasPosition;
    }
}