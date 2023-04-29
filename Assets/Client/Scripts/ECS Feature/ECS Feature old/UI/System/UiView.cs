using Client.Scripts.ECS_Feature.ECS_Feature_old.EventCoponents;
using Client.Scripts.ECS_Feature.Experience_Bar.Component;
using Client.Scripts.ECS_Feature.Resources_Generation.Component;
using Client.Scripts.Services;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Scripts.ECS_Feature.ECS_Feature_old.UI.System
{
    internal class UiView : IEcsRunSystem
    {
        private Scripts.UI.UI _ui;
        private EcsFilter<ChangeUI> _eventEntity;
        private EcsFilter<GameState> _resources;
        private readonly EcsFilter<ExperienceBarComponent> _expBarComponent;

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