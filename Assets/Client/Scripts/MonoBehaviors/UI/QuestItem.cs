using Leopotam.Ecs.Ui.Actions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Client.Scripts.MonoBehaviors.UI
{
    public class QuestItem : Item
    {
        public Button button;
        public Image fillBar;
        public TextMeshProUGUI title;
        public TextMeshProUGUI questObjectiveCurrent;
        public EcsUiClickAction clickAction;
        public ParticleSystem particleSystem;
        public RectTransform particleSpawnPoint;
    }
}