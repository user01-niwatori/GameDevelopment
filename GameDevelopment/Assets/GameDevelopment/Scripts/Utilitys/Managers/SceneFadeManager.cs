using UniRx;
using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// シーンの名前
/// </summary>
public enum SceneName
{
    Start,              // 開始時に必ず読まれるシーン
    Logo,               // ロゴの表示シーン
    DataCheck,          // データチェック用シーン
    Title,              // タイトルシーン
    Company,            // 会社シーン
}

/// <summary>
/// シーンを管理クラス
/// </summary>
public class SceneFadeManager : SingletonMonoBehaviour<SceneFadeManager>
{

    [SerializeField, Header("背景画像")]
    private Image _backgroundImage = default;

    /// <summary>
    /// シーン遷移中か？
    /// </summary>
    /// <remarks>
    /// TRUE:  遷移中
    /// FALSE: 遷移終了
    /// </remarks>
    private BoolReactiveProperty _isTransition = new BoolReactiveProperty(false);

    /// <summary>
    /// シーン遷移が終了していたらイベントを発行する
    /// </summary>
    public IObservable<Unit> OnTransitionFinished
    {
        get
        {
            // シーン遷移をしていないなら、即イベント発行
            // Observable.Return 値を一つだけ発行したいときに使用
            if (!_isTransition.Value) return Observable.Return(Unit.Default);

            // シーン遷移中なら終わったときにイベント発行
            // FirstOrDefault 一番最初に到達したOnNextのみを流してObservableを完了させたい
            // AsUnitObservable == Select(_ => Unit.Default) メッセージをUnit型に変換
            return _isTransition.FirstOrDefault(x => !x).AsUnitObservable();
        }
    }

    /// <summary>
    /// シーン遷移を開始する
    /// </summary>
    /// <param name="nextSceneName">遷移するシーン</param>
    /// <param name="transitionSeconds">遷移にかかる時間</param>
    public void Transition(SceneName nextSceneName, float transitionSeconds = 0.5f)
    {
        // すでにシーン遷移中ならこれ以降処理を読まない
        if (_isTransition.Value) return;

        StartCoroutine(TransitionCoroutine(nextSceneName, transitionSeconds));

    }

    /// <summary>
    /// シーン遷移をコルーチンで実行
    /// </summary>
    /// <param name="nextSceneName">遷移するシーン</param>
    /// <param name="transitionSeconds">遷移にかかる時間</param>
    /// <returns></returns>
    private IEnumerator TransitionCoroutine(SceneName nextSceneName, float transitionSeconds)
    {
        // シーン遷移開始を通知
        _backgroundImage.raycastTarget = true;
        _isTransition.Value = true;

        // フェードイン
        var time = transitionSeconds;
        while (time > 0)
        {
            time -= Time.deltaTime;
            _backgroundImage.color = OverrideColorAlpha(_backgroundImage.color, 1.0f - time / transitionSeconds);
            yield return null;
        }
        _backgroundImage.color = OverrideColorAlpha(_backgroundImage.color, 1f);

        // 画面を隠し終わったらシーン遷移する
        var scene = "0" + (int)nextSceneName + "_" + nextSceneName.ToString();
        yield return SceneManager.LoadSceneAsync(scene);

        // フェードアウト
        time = transitionSeconds;
        while (time > 0)
        {
            time -= Time.deltaTime;
            _backgroundImage.color = OverrideColorAlpha(_backgroundImage.color, time / transitionSeconds);
            yield return null;
        }
        _backgroundImage.color = OverrideColorAlpha(_backgroundImage.color, 0f);

        // シーン遷移完了を通知
        _backgroundImage.raycastTarget = false;
        _isTransition.Value = false;

    }

    /// <summary>
    /// alpha値を設定
    /// </summary>
    /// <param name="c"></param>
    /// <param name="a"></param>
    /// <returns></returns>
    private Color OverrideColorAlpha(Color c, float a)
    {
        return new Color(c.r, c.g, c.b, a);
    }
}