using Client.Scripts.Data;
using TMPro;
using UnityEngine;

namespace Client.Scripts.MonoBehaviors.UI
{
    public class ShopItem : Item
    {
        public Sprite image;
        public TextMeshProUGUI title;
        public TextMeshProUGUI price;
        public ProductType type;
    }
}
