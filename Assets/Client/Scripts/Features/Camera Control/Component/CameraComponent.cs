using UnityEngine;

namespace Client.Scripts.Features.Camera_Control.Component
{
    public struct CameraComponent
    {
        [Header("Move")]
        public float Distance;
        public float CurrentDistance;
        public Vector3 Delta;
        public float Timer;
        public float DragSpeed;
        public AnimationCurve Curve;
        
        [Header("Zoom")]
        public float OrthographicSize;
        public Vector2 TouchZeroPrevious;
        public Vector2 TouchOnePrevious;
        public float PreviousMag;
        public float CurrentMag;
        public float Difference;
        public float ZoomMin;
        public float ZoomMax;
        public float ZoomSpeed;
    }
}