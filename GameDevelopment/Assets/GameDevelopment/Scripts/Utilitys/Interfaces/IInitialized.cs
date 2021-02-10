using UniRx;
using System;

/// <summary>
/// 初期化のインターフェース
/// </summary>
public interface IInitialized
{
    /// <summary>
    /// 初期化されたらイベントを発行する
    /// </summary>
    IObservable<Unit> OnInitialized { get;}
}