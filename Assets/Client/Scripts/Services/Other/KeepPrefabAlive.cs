using UnityEngine;

namespace Client.Scripts.Services.Other
{
    public class KeepPrefabAlive : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
