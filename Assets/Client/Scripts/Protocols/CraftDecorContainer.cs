using Client.Scripts.Protocols.Interfaces;
using UnityEngine;

namespace Client.Scripts.Protocols
{
    public class CraftDecorContainer : MonoBehaviour, ICraftItemTransform
    {
        [SerializeField] private RectTransform rectTransform;
        public RectTransform RectTransform
        {
            get => rectTransform;
            set => rectTransform = value;
        }
    }
}