using UnityEngine;

namespace Client.Scripts.UI.Menus
{
    public abstract class Menu : MonoBehaviour
    {
        public virtual void Show(bool state = false)
        {
            gameObject.SetActive(state);
        }
    }
}
