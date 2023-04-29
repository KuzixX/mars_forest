using UnityEngine;

namespace Client.Scripts.Services
{
    public class WorldToScreenConvertor : MonoBehaviour
    {
        public static Vector2 WorldToCanvasSpace(RectTransform canvas, Camera camera, Vector3 worldPosition)
        {
            Vector2 viewportPosition = camera.WorldToViewportPoint(worldPosition);
            var sizeDelta = canvas.sizeDelta;
            var worldObjectScreenPosition = new Vector2(
                ((viewportPosition.x*sizeDelta.x)-(sizeDelta.x*0.5f)), 
                ((viewportPosition.y*sizeDelta.y)-(sizeDelta.y*0.5f)));
            return worldObjectScreenPosition;
        }
    }
}