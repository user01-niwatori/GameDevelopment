using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoSceneLoader
{
    private const string InitializeSceneName = "00_Start";

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void RuntimeInitializeApplication()
    {
        Debug.Log("RuntimeInitializeApplication");

        if (!SceneManager.GetSceneByName(InitializeSceneName).IsValid())
        {
            SceneManager.LoadScene(InitializeSceneName, LoadSceneMode.Additive);
        }
    }
}