using UnityEngine;

namespace Client.Scripts.ECS_Feature
{
    public struct CameraComponent
    {
        public Vector3 TempDelta;
        public float Distance;
        public float CurrentDistance;
        public Vector3 Delta;
        public float Timer;
        public float InterpolationTime;
        public float DragSpeed;
        public AnimationCurve Curve;
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