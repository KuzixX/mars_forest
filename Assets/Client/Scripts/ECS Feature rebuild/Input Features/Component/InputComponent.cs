using UnityEngine;

namespace Client.Scripts.ECS_Feature.Input_Features.Component
{
    public struct InputComponent
    {
        public Vector2 ScreenPoint;
        public bool TouchPosition00IsTriggered;
        public bool PressTouch;
        public Vector2 TouchPosition00;
        public Vector2 TouchPosition01;
        public Vector2 TouchDelta00;
        public Vector2 TouchDelta01;
        public Vector3 PrimaryDelta;
        public bool IsTap;
    }
}
