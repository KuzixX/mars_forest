using Client.Scripts.Protocols.Interfaces;
using Client.Scripts.Services;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

namespace Client.Scripts.UI
{
    public class GameLevel : MonoBehaviour
    {
        [Inject] private IExperienceBarProtocol _level;
        private TextMeshProUGUI _view;
        private CompositeDisposable _disposable = new();

        private void Start()
        {
            _view = gameObject.GetComponent<TextMeshProUGUI>();
            _level.CurrentLevel.Subscribe(_ =>
            {
                _view.text = _level.CurrentLevel.ToString();
            }).AddTo(_disposable);
        }
    }
}
