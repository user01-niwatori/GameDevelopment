using System;
using UniRx;
using UnityEngine;

/// <summary>
/// 初期化をイベントとして発行する機能を備えたMonoBehaviour
/// </summary>
public class BehaviourInitialized : MonoBehaviour, IInitialized
{
    /// <summary>
    /// 初期化されたか調べるFlg
    /// </summary>
    protected BoolReactiveProperty _isInitialized = new BoolReactiveProperty(false);

    /// <summary>
    /// 初期化されたらイベントを発行する
    /// </summary>
    public IObservable<Unit> OnInitialized
    {
        get
        {
            // 既に初期化済みなら、即イベント発行
            if (_isInitialized.Value) return Observable.Return(Unit.Default);

            // 初期化中なら終了後にイベントを発行
            return _isInitialized.FirstOrDefault(x => !x).AsUnitObservable();
        }
    }
}
