using Client.Scripts.Protocols.Interfaces;
using Client.Scripts.Services;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

namespace Client.Scripts.UI
{
    public class Diamonds : MonoBehaviour
    {
        [Inject] private IGameStateProtocol _diamonds;
        private TextMeshProUGUI _view;
        private CompositeDisposable _disposable = new();

        private void Start()
        {
            _view = gameObject.GetComponent<TextMeshProUGUI>();
            _diamonds.Gold.Subscribe(_ =>
            {
                _view.text = CurrencyConvertor.CurrencyToString(_diamonds.Diamonds.Value);
            }).AddTo(_disposable);
        }
    }
}
