using UnityEngine;

namespace Client.Scripts.Services
{
    public class KeepPrefabAlive : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
