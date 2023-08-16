using UnityEngine;

namespace Client.Scripts.Models
{
    [CreateAssetMenu]
    public class EnvModule : ScriptableObject
    {
        [SerializeField] protected GameObject prefab;
        public GameObject Prefab => prefab;
    }
}