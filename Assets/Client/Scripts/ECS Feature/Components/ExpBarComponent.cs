namespace Client.Scripts.ECS.Components
{
    internal struct ExpBarComponent
    {
        public int CurrentXp;
        public float[] TargetXp;
        public int CurrentLevel;
        public int MaxLevel;
        public float FillPercent;
    }
}