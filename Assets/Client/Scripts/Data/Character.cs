using UnityEngine;

namespace Client.Scripts.Data
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
