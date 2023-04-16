using System;

namespace Client.Scripts.ECS_Feature_rebuild.Resources_Generation
{
    [Serializable]
    public struct InGameResources
    {
        public int gold;
        public int diamonds;
        public int experience;
        public int treeAmount;

        public int tempGold;
        public int tempDiamonds;
        public int tempExperience;
        public int tempTreeAmount;
    }
}