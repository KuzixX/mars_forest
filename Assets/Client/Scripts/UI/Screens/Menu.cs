using UnityEngine;

namespace Client.Scripts.UI.Screens
{
    public abstract class Menu : MonoBehaviour
    {
        public virtual void Show(bool state = false)
        {
            gameObject.SetActive(state);
        }
    }
}
