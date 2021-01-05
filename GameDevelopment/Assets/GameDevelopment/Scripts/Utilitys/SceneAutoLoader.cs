using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneAutoLoader
{
    /// <summary>
    /// ゲーム開始時（シーン読み込み前）に実行される
    /// </summary>
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void LoadScene()
    {
        string sceneName = "00_" + SceneName.Start;

        // シーンが有効でない時（まだ読み込んでいない時）だけ追加ロードするように
        if (!SceneManager.GetSceneByName(sceneName).IsValid())
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        }
    }
}