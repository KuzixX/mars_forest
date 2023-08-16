using Client.Scripts.Protocols.Interfaces;
using Client.Scripts.Services;
using Client.Scripts.Services.Other;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

namespace Client.Scripts.UI
{
    internal class Experience : MonoBehaviour
    {
        [Inject] private IExperienceProtocol _experience;
        private TextMeshProUGUI _view;
        private CompositeDisposable _disposable = new();

        private void Start()
        {
            _view = gameObject.GetComponent<TextMeshProUGUI>();
            _experience.Experience.Subscribe(_ =>
            {
                _view.text = CurrencyConvertor.CurrencyToString(_experience.Experience.Value);
            }).AddTo(_disposable);
        }
    }
}
