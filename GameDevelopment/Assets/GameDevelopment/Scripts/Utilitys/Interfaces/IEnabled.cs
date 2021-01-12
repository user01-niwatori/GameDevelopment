
/// <summary>
/// ゲームオブジェクトの表示/非表示用インターフェース
/// </summary>
public interface IEnabled
{
    /// <summary>
    /// ゲームオブジェクトの表示/非表示
    /// </summary>
    /// <param name="flg">識別用flg</param>
    void SetEnabled(bool flg);
}