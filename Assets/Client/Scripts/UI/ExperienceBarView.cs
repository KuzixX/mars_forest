using System.ComponentModel;
using Client.Scripts.Protocols.Interfaces;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Client.Scripts.UI
{
    public class ExperienceBarView : MonoBehaviour
    {
        [Inject] private IExperienceBarProtocol _experienceBar;
        [SerializeField] private Image view;
        [SerializeField] private TextMeshProUGUI text;
        private CompositeDisposable _disposable = new();

        private void Start()
        {
            _experienceBar.CurrentXp.Subscribe(_ =>
            {
                view.fillAmount = _experienceBar.FillPercent.Value;
                text.text = _experienceBar.ViewXp;
            }).AddTo(_disposable);
        }
    }
}
