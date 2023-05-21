using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Client.Scripts.UI
{
    public class UILoader : MonoBehaviour
    {
        private void Start()
        {
            SceneManager.LoadScene("UI", LoadSceneMode.Additive);
        }
    }
}
