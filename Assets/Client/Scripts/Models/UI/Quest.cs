using System;
using UnityEngine;

namespace Client.Scripts.Models.UI
{
    [CreateAssetMenu]
    [System.Serializable]
    public class Quest : ScriptableObject
    {
        [Header("Description")]
        [SerializeField] protected QuestType type;
        public QuestType Type => type;
        [SerializeField] protected String title;
        public String Title => title;
        [SerializeField] protected QuestObjective objective; // name of the quest objective
        public QuestObjective Objective => objective;
        [Header("Rewards")]
        [SerializeField] protected int diamondsReward;
        public int DiamondsReward => diamondsReward;
        [SerializeField] protected int goldReward;
        public int GoldReward => goldReward;

        [SerializeField] protected int expReward;
        public int ExpReward => expReward;

        [Header("Objective")] 
        [SerializeField] protected int questObjectiveCount; // current number of QuestObjective count
        public int QuestObjectiveCount => questObjectiveCount;

        [SerializeField] protected int questRequirementCount; // requirement number of QuestObjective count
        public int QuestRequirementCount => questRequirementCount;
        
        [SerializeField] protected bool isDone; // requirement number of QuestObjective count
        public bool IsDone => isDone;
    }
}