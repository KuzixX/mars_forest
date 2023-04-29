namespace Client.Scripts.ECS_Feature.Experience_Bar.Component
{
    internal struct ExperienceBarComponent
    {
        public int CurrentXp;
        public float[] TargetXp;
        public int CurrentLevel;
        public int MaxLevel;
        public float FillPercent;
    }
}