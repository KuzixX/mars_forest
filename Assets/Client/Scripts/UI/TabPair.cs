using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Client.Scripts.UI
{
    [Serializable]
    public class TabPair : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private TabMenu tabMenu;
        [SerializeField] private GameObject tabWindow;
        
        public void OnPointerClick(PointerEventData eventData)
        {
            
        }
    }
}
