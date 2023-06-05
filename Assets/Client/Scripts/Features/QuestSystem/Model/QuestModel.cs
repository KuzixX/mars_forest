using Client.Scripts.Models;

namespace Client.Scripts.Features.QuestSystem.Model
{
    public class QuestModel
    {
        public string     Title;
        public QuestType  QuestType;
        public int        Award;
        public double     QuestRequirementCount;
        public double     QuestObjectiveCurrent;
        public int        QuestDineCount;
        public bool       IsDone;
        public float      FillAmount;
    }
}
