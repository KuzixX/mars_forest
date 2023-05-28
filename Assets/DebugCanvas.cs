using System;
using UnityEngine;

public class DebugCanvas : MonoBehaviour
{
    [SerializeField] private float offsetX;
    #if UNITY_EDITOR
    private void OnValidate()
    {
        gameObject.GetComponent<Canvas>().renderMode = RenderMode.WorldSpace;
        transform.position = new Vector3(offsetX, transform.position.y, transform.position.z);
    }
    #endif

    private void Start()
    {
        gameObject.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
    }
}
