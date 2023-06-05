using System;

namespace Client.Scripts.Features.Resources_Generation.Component
{
    [Serializable]
    public struct GameState
    {
        public double gold;
        public double diamonds;
        public double experience;
        public int cellObjectAmount;
        public int gameLevel;
    }
}