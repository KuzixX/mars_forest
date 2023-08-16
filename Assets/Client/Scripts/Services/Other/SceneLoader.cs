using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Client.Scripts.Services.Other
{
    public class SceneLoader : MonoBehaviour
    {
        public Image loadBar;
        public void LoadLevel(int sceneIdx)
        {
            StartCoroutine(LoadAsynchronously(sceneIdx));
        }

        IEnumerator LoadAsynchronously (int sceneIdx)
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIdx);

            while (!operation.isDone)
            {
                float progress = Mathf.Clamp01(operation.progress / .9f);
                loadBar.fillAmount = progress;
                yield return null;
            }
        }
    }
}