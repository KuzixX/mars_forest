using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using ETouch = UnityEngine.InputSystem.EnhancedTouch;

namespace Client.Scripts.MonoBehaviors
{
    public class CamraController : MonoBehaviour
    {
        private InputControls _inputControls;
        [SerializeField] private float dragSpeed;

        private Vector3 _touchStart;
        private Vector3 _firstTouch;
        private Vector3 _secondTouch;
        private float _distance;
        private Vector3 _delta;
        private float _currentDistance;
        private Camera _camera;
        public float InterpTime = 2;
        public AnimationCurve Curve = AnimationCurve.Linear(0, 0, 0, 0);
        private Vector3 _a;
        private Vector3 _b;
        private float _currentTime;
        private float _currentWeight;
        private bool _shitIsInterpolating;
        private Vector3 _saveDirection;
        private float _timer = 1;
        private float _saveOrtoSize;
        private float _saveDistance;

        private void OnEnable()
        {
            EnhancedTouchSupport.Enable();
        }

        private void Start()
        {
            _inputControls = new InputControls();
            _inputControls.Enable();
            _camera = Camera.main;
        }

        void Update()
        {
            // Логика выполняется при тапе
            if (_inputControls.Player.PressTouch.triggered)
            {
                _saveDistance = Vector3.Distance(
                    _camera.ScreenToWorldPoint(_inputControls.Player.TouchPosition_00.ReadValue<Vector2>()),
                    _camera.ScreenToWorldPoint(_inputControls.Player.TouchPosition_01.ReadValue<Vector2>()));
            }

            // Логика выполняется, когда значение изеняется // количество тачей снизит на один
            if (_inputControls.Player.TouchPosition_00.triggered && ETouch.Touch.activeFingers.Count < 3)
            {
                _currentDistance = Vector3.Distance(
                    _camera.ScreenToWorldPoint(_inputControls.Player.TouchPosition_00.ReadValue<Vector2>()),
                    _camera.ScreenToWorldPoint(_inputControls.Player.TouchPosition_01.ReadValue<Vector2>()));
                _delta = (Vector3)_inputControls.Player.PrimaryDelta.ReadValue<Vector2>() * -0.01f;
                transform.position += _delta * (Time.deltaTime * dragSpeed);
                _timer = 0;
            }
            else
            {
                if (_timer < 1)
                {
                    _timer += Time.deltaTime * InterpTime;
                    transform.position += _delta * (Time.deltaTime * dragSpeed * Curve.Evaluate(_timer));
                    if (_timer > 1) _timer = 1;
                }
            }

            // if (ETouch.Touch.activeFingers.Count == 3)
            // {
            //
            //     Vector3 TouchZeroPrevious = _inputControls.Player.TouchPosition_00.ReadValue<Vector2>() -
            //                                 _inputControls.Player.TouchDelta_00.ReadValue<Vector2>();
            //     Vector3 TouchOnePrevious = _inputControls.Player.TouchPosition_01.ReadValue<Vector2>() -
            //                                _inputControls.Player.TouchDelta_01.ReadValue<Vector2>();
            //
            //     float prevMag = (TouchZeroPrevious - TouchOnePrevious).magnitude;
            //     float curMag = (_inputControls.Player.TouchPosition_00.ReadValue<Vector2>() -
            //                     _inputControls.Player.TouchPosition_01.ReadValue<Vector2>()).magnitude;
            //
            //     float dif = curMag - prevMag;
            //     
            //     _camera.orthographicSize = Mathf.Clamp(_camera.orthographicSize - dif * 0.01f, 1, 5);
            //
            // }
        }
    }
}