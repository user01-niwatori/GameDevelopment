using UnityEngine;
using UniRx;

namespace GameDevelopment.Scenes.LogoScenes
{
    /// <summary>
    /// 初期化　ロゴ表示
    /// </summary>
    public class Initialize_Logo : MonoBehaviour
    {
        /// <summary>
        /// Start
        /// </summary>
        private async void Start()
        {
            await SceneFadeManager.Instance.OnTransitionFinished;
            SceneFadeManager.Instance.Transition(SceneName.DataCheck);
        }
    }
}
