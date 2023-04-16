using Client.Scripts.ECS_Feature_rebuild.Resources_Generation;
using Client.Scripts.ECS.Components;
using Client.Scripts.ECS.Components.EventCoponents;
using Client.Scripts.MonoBehaviors;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Scripts.ECS_Feature.UI.System
{
    internal class UiView : IEcsRunSystem
    {
        private MonoBehaviors.UI.UI _ui;
        private EcsFilter<ChangeUI> _eventEntity;
        private EcsFilter<InGameResources> _resources;
        private readonly EcsFilter<ExpBarComponent> _expBarComponent;

        public void Run()
        {
            ref var resources = ref _resources.Get1(0);
            ref var expBar = ref _expBarComponent.Get1(0);
            ref var eventEntity = ref _eventEntity.GetEntity(0);

            if (_eventEntity.IsEmpty()) return;

            var eventDescription = eventEntity.Get<ChangeUI>().EventDescription;

            if (eventDescription is "ResBar" or "FullUI")
            {
                Debug.Log("Ui Changed");
                _ui.mainScreen.goldAmountText.text = CurrencyConvertor.CurrencyToString(resources.gold);
                _ui.mainScreen.expAmountText.text = CurrencyConvertor.CurrencyToString(resources.experience);
                _ui.mainScreen.diamondsAmountText.text = CurrencyConvertor.CurrencyToString(resources.diamonds);
                eventEntity.Del<ChangeUI>();
            }

            if (eventDescription is "ExpBar" or "FullUI")
            {
                _ui.mainScreen.expBarAmountText.text = CurrencyConvertor.CurrencyToString(expBar.CurrentXp) + "/" + CurrencyConvertor.CurrencyToString(expBar.TargetXp[expBar.CurrentLevel]);
                _ui.mainScreen.expFillImage.fillAmount = expBar.FillPercent;
                eventEntity.Del<ChangeUI>();
            }

            if (eventDescription is not ("ExpBarIsTargetExp" or "FullUI")) return;
            _ui.mainScreen.expFillImage.fillAmount = 0;
            _ui.mainScreen.expBarAmountText.text = CurrencyConvertor.CurrencyToString(expBar.CurrentXp) + "/" + CurrencyConvertor.CurrencyToString(expBar.TargetXp[expBar.CurrentLevel]);
            _ui.mainScreen.gameLevelText.text = expBar.CurrentLevel.ToString();
            eventEntity.Del<ChangeUI>();
        }
    }
}