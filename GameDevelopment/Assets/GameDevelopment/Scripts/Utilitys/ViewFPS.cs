using UnityEngine;
using UnityEngine.UI;

public class ViewFPS : MonoBehaviour
{
    [SerializeField]
    private Text _fpsText = default;

    [SerializeField]
    private float Interval = 0.1f;
    private float _time_cnt;
    private int _frames;
    private float _time_mn;
    private float _fps;

    /// <summary>
    /// FPSの表示と計算
    /// </summary>
    private void Update()
    {
        _time_mn -= Time.deltaTime;
        _time_cnt += Time.timeScale / Time.deltaTime;
        _frames++;

        if (0 < _time_mn) return;

        _fps = _time_cnt / _frames;
        _time_mn = Interval;
        _time_cnt = 0;
        _frames = 0;

        _fpsText.text = "FPS: " + _fps.ToString("f2");
    }
}