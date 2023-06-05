using Leopotam.Ecs.Ui.Actions;
using TMPro;
using UnityEngine.UI;

namespace Client.Scripts.Models.UI_Models
{
    public class CraftItem : Ite {
        public Image image;
        public TextMeshProUGUI title;
        public TextMeshProUGUI description;
        public EcsUiClickAction clickAction;
    }
}
