using UnityEngine;

/// <summary>
/// 汎用的なメソッドがまとめられたクラス
/// </summary>
public class Utility
{
    /// <summary>
    /// 2点間の距離が指定した長さに収まっているか調べる
    /// </summary>
    /// <param name="a">地点A</param>
    /// <param name="b">地点B</param>
    /// <param name="magnitude">指定した長さ</param>
    /// <returns></returns>
    public static bool InDistance(Vector3 a, Vector3 b, float magnitude)
    {
        return (b - a).sqrMagnitude <= magnitude * magnitude;
    }

    /// <summary>
    /// スクリーン（マウス）座標からワールド座標に変換
    /// </summary>
    /// <param name="camera">対象のカメラ</param>
    /// <param name="mousePos">マウス位置</param>
    /// <returns></returns>
    public static Vector3 ScreenToWorldPoint(Camera camera, Vector3 mousePos)
    {
        // スクリーン座標は２次元なので、３次元のVector3に突っ込んだ時、zは初期値の0になります。
        // 0では困るので0以外の値を入れています。
        mousePos.z   = 10f;
        var worldPos = camera.ScreenToWorldPoint(mousePos);
        return worldPos;
    }

    /// <summary>
    /// ワールド座標からUI
    /// </summary>
    /// <param name="rectCanvas"></param>
    /// <param name="worldPos"></param>
    /// <returns></returns>
    public static Vector3 WorldToUIPoint(RectTransform rectCanvas, Vector3 worldPos)
    {
        Vector2 spos  = RectTransformUtility.WorldToScreenPoint(Camera.main, worldPos);
        Vector2 uiPos = Vector2.zero;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectCanvas, spos, Camera.main, out uiPos);
        return uiPos;
    }

    /// <summary>
    /// フレームを秒数に変換
    /// </summary>
    /// <param name="frame">フレーム</param>
    /// <returns></returns>
    public static float ConvertFrameToSeconds(int frame)
    {
        var seconds = frame / 60f;
        return seconds;
    }

    /// <summary>
    /// 置き換え（2つのものを交換する）処理
    /// </summary>
    /// <typeparam name="T">ジェネリック</typeparam>
    /// <param name="a">対象A</param>
    /// <param name="b">対象B</param>
    public void Swap<T>(ref T a, ref T b)
    {
        T temp = a;
        a      = b;
        b      = temp;
    }
}

// 振動もう少し強く


///// <summary>
///// 自作のリストクラス
///// </summary>
///// <typeparam name="T"></typeparam>
//public class MyList<T>
//{
//    // デフォルトの容量
//    private const int DefaultCapacity = 4;

//    // 要素を格納する配列
//    private T[] items = new T[DefaultCapacity];

//    // インデクサ(Indexer)
//    public T this[int index]
//    {
//        get => items[index];
//        set => items[index] = value;
//    }

//    // 配列の容量
//    public int Capacity { get; private set; } = DefaultCapacity;

//    // 配列の要素数
//    public int Count { get; private set; } = 0;

//    public void Add(T element)
//    {
//        // 配列の要素数が足りない
//        if(Count == Capacity)
//        {
//            // 2倍の容量で配列を確保し直す
//            EnsureCapacity(Capacity * 2);
//        }

//        items[Count] = element;
//        Count++;
//    }

//    private void EnsureCapacity(int newCapacity)
//    {
//        Capacity = newCapacity;

//        T[] prevItems = items;
//        items = new T[Capacity];

//        System.Array.Copy(prevItems, 0, items, 0, Count);
//    }

//    public void Remove(T element)
//    {
//        int index = System.Array.IndexOf(items, element);
//        RemoveAt(index);
//    }

//    public void RemoveAt(int index)
//    {
//        if (index < 0) { return; }

//        Count--;

//        // [1, 2, 3, 4, 5]で2を消すときは
//        // [3, 4, 5]を2の位置にコピーして
//        // [1, 3, 4, 5, 5]とする
//        // 最後の要素を削除するときはコピー不要
//        if(index < Count)
//        {
//            System.Array.Copy(items, index + 1, items, index, Count - index);
//        }

//        // 最後の要素が残るのでdefault(intなら0, boolならfalseなどを表す)で上書き
//        // ※ classならnullが入るというのがポイント
//        items[Count] = default;
//    }

//    public void Log()
//    {

//    }
//}