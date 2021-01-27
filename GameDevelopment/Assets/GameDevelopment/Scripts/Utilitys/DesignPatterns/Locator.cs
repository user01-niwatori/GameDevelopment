using UnityEngine;
using System;

/// <summary>
/// サービスロケーター
/// </summary>
/// <typeparam name="T"></typeparam>
public class Locator<T> where T : class
{
    /// <summary>
    /// インスタンス
    /// </summary>
    public static T I { get; private set; }

    /// <summary>
    /// サービスロケーターが有効か？
    /// </summary>
    public static bool IsValid() => I != null;

    /// <summary>
    /// インスタンスを紐づける
    /// </summary>
    /// <param name="instance">インスタンス</param>
    public static void Bind(T instance)
    {
        I = instance;
    }

    /// <summary>
    /// 紐づけたインスタンスを解除する
    /// </summary>
    /// <remarks>
    /// これを忘れるとメモリリークが発生するので使い終わったらちゃんと開放する。
    /// </remarks>
    /// <param name="instance"></param>
    public static void UnBind(T instance)
    {
        if(I == instance)
        {
            I = null;
        }
    }

    /// <summary>
    /// インスタンス解除
    /// </summary>
    public static void Clear()
    {
        I = null;
    }
}
