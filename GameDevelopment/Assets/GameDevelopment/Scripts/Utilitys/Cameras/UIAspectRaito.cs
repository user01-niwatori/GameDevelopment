using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAspectRaito : MonoBehaviour
{
    /// <summary>
    /// Canvas
    /// </summary>
    [SerializeField]
    private Canvas _canvas = default;

    /// <summary>
    /// Start
    /// </summary>
    private void Start()
    {
        _canvas.renderMode = RenderMode.ScreenSpaceCamera;
    }
}
