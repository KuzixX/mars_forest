using Client.Scripts.ECS.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Scripts.ECS_Feature.Init
{
    internal class InitTargetXp : IEcsInitSystem
    {
        private MonoBehaviors.UI.UI _ui;
        private readonly EcsFilter<ExpBarComponent> _expFilter;
        public void Init()
        {
            ref var expBar = ref _expFilter.Get1(0);
            expBar.MaxLevel = 100;
            expBar.CurrentLevel = 0;
            expBar.TargetXp = new float[expBar.MaxLevel];
            _ui.mainScreen.expBarAmountText.text = expBar.CurrentXp + "/" + expBar.TargetXp[expBar.CurrentLevel];
            _ui.mainScreen.expFillImage.fillAmount = 0;
            
            for (int i = 0; i < expBar.MaxLevel; i++)
            {
                expBar.TargetXp[i] = Mathf.Pow(i / 0.05f, 2);
            }
        }
    }
}