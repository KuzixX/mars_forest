using UnityEngine;
using UnityEngine.SceneManagement;

namespace Client.Scripts.Services.Other
{
    public class LoadScene : MonoBehaviour
    {
        public int sceneIdx;
        void Start()
        {
            SceneManager.LoadScene(sceneIdx, LoadSceneMode.Additive);
        }
    }
}
