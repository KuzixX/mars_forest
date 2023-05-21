using Client.Scripts.Protocols.Interfaces;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

namespace Client.Scripts.UI
{
    public class CellObjectCountView : MonoBehaviour
    {
        [Inject] private IGameStateProtocol _cellObjectsCount;
        private TextMeshProUGUI _view;
        private CompositeDisposable _disposable = new();

        private void Start()
        {
            _view = gameObject.GetComponent<TextMeshProUGUI>();
            _cellObjectsCount.CellObjectsCount.Subscribe(_ =>
            {
                _view.text = _cellObjectsCount.CellObjectsCount.ToString();
            }).AddTo(_disposable);
        }
    }
}
