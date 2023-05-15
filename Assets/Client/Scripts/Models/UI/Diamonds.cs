using UnityEngine;

namespace Client.Scripts.Models.UI_Models
{
    [CreateAssetMenu]
    [System.Serializable]
    public class Diamonds : ScriptableObject
    {
        [SerializeField] protected float price;
        public float Price => price;
        [SerializeField] protected int diamondsAmount;
        public int DiamondsAmount => diamondsAmount;
    }
}
