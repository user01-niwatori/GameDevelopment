using UnityEngine;

/*
 * TODO: 参考URL
 * https://note.com/suzukijohnp/n/n9d736836feb1
 */


/// <summary>
/// カメラの複数アスペクト比対応（3D）
/// </summary>
public class CameraAspectRatio3D : MonoBehaviour
{
    /// <summary>
    /// 対象のカメラ
    /// </summary>
    [SerializeField, Header("対象のカメラ")]
    private Camera m_camera = null;

    /// <summary>
    /// 画面縦比率
    /// </summary>
    [SerializeField, Header("画面縦比率")]
    private float m_baseHeight = 16.0f;

    /// <summary>
    /// 画面横比率
    /// </summary>
    [SerializeField, Header("画面横比率")]
    private float m_baseWidth = 9.0f;


    /// <summary>
    /// 開始時に呼ばれる処理
    /// </summary>
    private void Start()
    {
        Init();
    }

    /// <summary>
    /// 初期化
    /// </summary>
    private void Init()
    {
        // アスペクト比固定
        FixedAspectRatio();
    }

    /// <summary>
    /// 幅固定+高さ可変
    /// </summary>
    private void FixedWidth_VariableHeight()
    {
        var scaleWidth = (Screen.height / m_baseHeight) * (m_baseWidth / Screen.width);
        m_camera.fieldOfView = Mathf.Atan(Mathf.Tan(m_camera.fieldOfView * 0.5f * Mathf.Deg2Rad) * scaleWidth) * 2.0f * Mathf.Rad2Deg;
    }

    /// <summary>
    /// ペース維持
    /// </summary>
    private void KeepPace()
    {
        var scaleWidth = (Screen.height / m_baseHeight) * (m_baseWidth / Screen.width);
        var scaleRatio = Mathf.Max(scaleWidth, 1.0f);
        m_camera.fieldOfView = Mathf.Atan(Mathf.Tan(m_camera.fieldOfView * 0.5f * Mathf.Deg2Rad) * scaleRatio) * 2.0f * Mathf.Rad2Deg;
    }

    /// <summary>
    /// アスペクト比固定
    /// </summary>
    private void FixedAspectRatio()
    {
        var scale = Mathf.Min(Screen.height / m_baseHeight, Screen.width / m_baseWidth);
        var width = (m_baseWidth * scale) / Screen.width;
        var height = (m_baseHeight * scale) / Screen.height;
        m_camera.rect = new Rect((1.0f - width) * 0.5f, (1.0f - height) * 0.5f, width, height);
    }

    /// <summary>
    /// 高さ固定+幅上限あり
    /// </summary>
    private void FixedHeight_UpperLimitOfWidth()
    {
        // 高さ固定+幅上限あり
        var scale = Mathf.Min(Screen.height / m_baseHeight, Screen.width / m_baseWidth);
        var width = (m_baseWidth * scale) / Screen.width;
        m_camera.rect = new Rect((1.0f - width) * 0.5f, 0, width, 1.0f);
    }

    /// <summary>
    /// 幅固定+高さ上限あり
    /// </summary>
    private void FixedWidth_UpperLimit()
    {
        var scale = Mathf.Min(Screen.height / m_baseHeight, Screen.width / m_baseWidth);
        var height = (m_baseHeight * scale) / Screen.height;
        m_camera.rect = new Rect(0, (1.0f - height) * 0.5f, 1.0f, height);

        var scaleWidth = (Screen.height / m_baseHeight) * (m_baseWidth / Screen.width);
        var scaleRatio = Mathf.Min(scaleWidth, 1.0f);
        m_camera.fieldOfView = Mathf.Atan(Mathf.Tan(m_camera.fieldOfView * 0.5f * Mathf.Deg2Rad) * scaleRatio) * 2.0f * Mathf.Rad2Deg;
    }

    /// <summary>
    /// フィット
    /// </summary>
    private void Fit()
    {
        var scaleWidth = (Screen.height / m_baseHeight) * (m_baseWidth / Screen.width);
        var scaleRatio = Mathf.Min(scaleWidth, 1.0f);
        m_camera.fieldOfView = Mathf.Atan(Mathf.Tan(m_camera.fieldOfView * 0.5f * Mathf.Deg2Rad) * scaleRatio) * 2.0f * Mathf.Rad2Deg;
    }

}

