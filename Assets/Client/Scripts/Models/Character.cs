using UnityEngine;

namespace Client.Scripts.Models
{
    [CreateAssetMenu]
    public class Character : ScriptableObject
    {
        [SerializeField] protected GameObject prefab;
        public GameObject Prefab => prefab;
        [SerializeField] protected float speed;
        public float Speed => speed * -1;
    }
}
