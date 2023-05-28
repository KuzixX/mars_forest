using UnityEngine;

namespace Client.Scripts.Features.CraftSystem.Models
{
    public class TreeModel
    {
        public string     Title;
        public string     Description;
        public int        Level;
        public int        AmountOfProduct;
        public int        AmountOfExperience;
        public int        Price;
        public float      ProductionCycleTime;
        public Sprite      Image;
        public GameObject Prefab;
    }
}