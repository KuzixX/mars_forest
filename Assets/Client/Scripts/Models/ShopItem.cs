using Client.Scripts.Models.UI_Models;
using TMPro;
using UnityEngine;

namespace Client.Scripts.Models
{
    public class ShopItem : Item
    {
        public Sprite image;
        public TextMeshProUGUI title;
        public TextMeshProUGUI price;
        public ProductType type;
    }
}
