using UnityEngine;
using UniRx;

namespace GameDevelopment.Scenes.LogoScenes
{
    /// <summary>
    /// 初期化　ロゴ表示
    /// </summary>
    public class Initialize_Logo : BehaviourEnabled
    {
        /// <summary>
        /// Start
        /// </summary>
        private async void Start()
        {
            await SceneFadeManager.I.OnTransitionFinished;
            SceneFadeManager.I.Transition(SceneName.DataCheck);
        }
    }
}
