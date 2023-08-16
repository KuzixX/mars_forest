using System;
using UnityEngine;

namespace Client.Scripts.Models.UI
{
    [CreateAssetMenu]
    [System.Serializable]
    public class Product : ScriptableObject
    {
        [SerializeField] protected String title;
        public String Title => title;
        [SerializeField] protected float price;
        public float Price => price;
        [SerializeField] protected float amountOfProduct;
        public float AmountOfProduct => amountOfProduct;
        [SerializeField] protected PriceType priceType;
        public PriceType PriceType => priceType;
        [SerializeField] protected ProductType productType;
        public ProductType Type => productType;
        [SerializeField] protected Sprite image;
        public Sprite Image => image;
        
    }
}
