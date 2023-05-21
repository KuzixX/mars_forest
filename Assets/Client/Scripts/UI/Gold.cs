using System;
using Client.Scripts.Protocols.Interfaces;
using Client.Scripts.Services;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

namespace Client.Scripts.UI
{
    public class Gold : MonoBehaviour
    {
        [Inject] private IGameStateProtocol _gold;
        private TextMeshProUGUI _view;
        private CompositeDisposable _disposable = new();

        private void Start()
        {
            _view = gameObject.GetComponent<TextMeshProUGUI>();
            _gold.Gold.Subscribe(_ =>
            {
                _view.text = CurrencyConvertor.CurrencyToString(_gold.Gold.Value);
            }).AddTo(_disposable);
        }
    }
}
