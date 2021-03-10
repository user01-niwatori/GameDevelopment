using UnityEngine;

/// <summary>
/// アプリケーション 監視/管理クラス
/// </summary>
public class ApplicationManager : SingletonMonoBehaviour<ApplicationManager>
{
    /// <summary>
    /// サスペンド中か？
    /// </summary>
    private bool m_isSpended = false;

    /// <summary>
    /// アプリケーションが終了された際に呼び出されるメソッド
    /// </summary>
    /// <param name="pause">一時停止有無</param>
    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            Suspend();
        }
        else
        {
            Resume();
        }
    }

    /// <summary>
    /// サスペンド処理
    /// </summary>
    /// <remarks>
    /// アプリ一時終了時に呼ばれるメソッド
    /// </remarks>
    private void Suspend()
    {
        if (m_isSpended) { return; }
        //Time.timeScale = 0;
        Debug.LogError("Suspend");
        m_isSpended = true;
    }

    /// <summary>
    /// レジューム処理
    /// </summary>
    /// <remarks>
    /// アプリ復帰時に呼ばれるメソッド
    /// </remarks>
    private void Resume()
    {
        if (!m_isSpended) { return; }
        //Time.timeScale = 1;
        Debug.LogError("Resume");
        m_isSpended = false;
    }

    /// <summary>
    /// アプリケーションが終了された際に呼び出されるメソッド
    /// </summary>
    private void OnApplicationQuit()
    {
    }
}