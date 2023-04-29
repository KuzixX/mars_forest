using System;

namespace Client.Scripts.ECS_Feature.Resources_Generation.Component
{
    [Serializable]
    public struct GameState
    {
        public int gold;
        public int diamonds;
        public int experience;
        public int cellObjectAmount;
        public int gameLevel;

        public int tempGold;
        public int tempDiamonds;
        public int tempExperience;
        public int tempCellObjectAmount;
    }
}