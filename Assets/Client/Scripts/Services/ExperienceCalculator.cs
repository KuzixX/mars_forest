using UnityEngine;

namespace Client.Scripts.Services
{
    public class ExperienceCalculator
    {
        public static float[] CalculateXp(int maxLevel)
        {
            float[] listOfTargetXp = new float[maxLevel];
            
            for (int i = 0; i < maxLevel; i++)
            {
                listOfTargetXp[i] = Mathf.Pow(i / 0.05f, 2);
            }
            return listOfTargetXp;
        }
    }
}