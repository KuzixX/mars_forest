using System;
using UnityEngine;

namespace Client.Scripts.Data
{
    [CreateAssetMenu]
    [System.Serializable]
    public class ItemInfo : ScriptableObject
    {
        [SerializeField] protected int id;
        public int Id => id;
        [SerializeField] protected String title;
        public String Title => title;
        
        [SerializeField] protected String description;
        public String Description => description;
        
        [SerializeField] protected Sprite image;
        public Sprite Image => image;
        
        [SerializeField] protected GameObject prefab;
        public GameObject Prefab => prefab;
    
        [SerializeField] protected int level;
        public int Level => level;
    
        [SerializeField] protected int amountOfProduct;
        public int AmountOfProduct => amountOfProduct;
    
        [SerializeField] protected int amountOfExperience;
        public int AmountOfExperience => amountOfExperience;
        
        [SerializeField] protected int price;
        public int Price => price;
        [SerializeField] protected float productionCycleTime;
        public float ProductionCycleTime => productionCycleTime;
    }
}
