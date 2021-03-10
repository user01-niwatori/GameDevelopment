using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

public class ViewFPS : BehaviourEnabled
{
    [SerializeField]
    private Text _fpsText = default;

    /// <summary>
    /// Update()が呼ばれた回数をカウントします。
    /// </summary>
    int frameCount = 0;

    /// <summary>
    /// 前回フレームレートを表示してからの経過時間です。
    /// </summary>
    float elapsedTime = 0;


    /// <summary>
    /// Start
    /// </summary>
    private void Start()
    {
        this.UpdateAsObservable()
            .Subscribe(_ => Display());
    }

    /// <summary>
    /// FPSの表示と計算
    /// </summary>
    private void Display()
    {
        // 呼ばれた回数を加算します。
        frameCount++;

        // 前のフレームからの経過時間を加算します。
        elapsedTime += Time.unscaledDeltaTime;

        if (elapsedTime >= 1.0f)
        {
            // 経過時間が1秒を超えていたら、フレームレートを計算します。
            float fps = 1.0f * frameCount / elapsedTime;

            // 計算したフレームレートを画面に表示します。(小数点以下2ケタまで)
            string fpsRate = $"FPS: {fps.ToString("F2")}";
            _fpsText.text = fpsRate;

            // フレームのカウントと経過時間を初期化します。
            frameCount = 0;
            elapsedTime = 0f;
        }
    }
}