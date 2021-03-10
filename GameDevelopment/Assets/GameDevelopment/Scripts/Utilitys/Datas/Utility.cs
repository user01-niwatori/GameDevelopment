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
    /// ワールド座標からUI座標に変換
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

    /// <summary>
    /// 数学タイプ
    /// </summary>
    public enum MathType
    {
        Ceil,       // 切り上げ
        Floor,      // 切り捨て
        Round       // 四捨五入
    };

    /// <summary>
    /// 小数点の変換処理
    /// </summary>
    /// <param name="decimalNumber">小数点第何位まで表示するか？</param>
    /// <param name="mathType">数学タイプ</param>
    /// <returns></returns>
    public static float ConvertDecimalPoint(float value, int decimalNumber, MathType mathType = MathType.Round)
    {
        var   magnification = Mathf.Pow(10, decimalNumber);
        float num           = value * magnification;

        switch (mathType)
        {
            case MathType.Ceil:
                num = Mathf.Ceil(num);
                break;
            case MathType.Floor:
                num = Mathf.Floor(num);
                break;
            case MathType.Round:
                num = Mathf.Round(num);
                break;
        }
        return num / magnification;
    }
}

