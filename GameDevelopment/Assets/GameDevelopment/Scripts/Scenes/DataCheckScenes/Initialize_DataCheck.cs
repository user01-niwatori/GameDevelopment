using UnityEngine;
using UniRx;

namespace GameDevelopment.Scenes.DataCheckScenes
{
    /// <summary>
    /// 初期化　データチェック
    /// </summary>
    public class Initialize_DataCheck : BehaviourEnabled
    {
        private async void Start()
        {
            await SceneFadeManager.I.OnTransitionFinished;
            SceneFadeManager.I.Transition(SceneName.Title);
        }
    }
}