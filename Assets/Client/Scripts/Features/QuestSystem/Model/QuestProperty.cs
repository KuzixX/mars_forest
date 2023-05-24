
namespace Client.Scripts.Features.QuestSystem.Model
{
    public class QuestProperty
    {
        private int _current;
        private int _target;
        public QuestProperty(int current, int target)
        {
            _current = current;
            _target = target;
        }

        public int Current
        {
            get => _current;
            private set { _current = value; }
        }
        public int Target => _target;

        public void Add(int point) => Current += point;
    }
}
