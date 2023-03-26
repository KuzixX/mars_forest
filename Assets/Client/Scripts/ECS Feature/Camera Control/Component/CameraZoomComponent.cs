using System;
using Vector2 = UnityEngine.Vector2;

namespace Client.Scripts.ECS.Components
{[Serializable]
    public struct CameraZoomComponent
    {
        public float orthographicSize;
        public Vector2 touchZeroPrevious;
        public Vector2 touchOnePrevious;
        public float previousMag;
        public float currentMag;
        public float difference;
        public float zoomMin;
        public float zoomMax;
        public float zoomSpeed;
    }
}