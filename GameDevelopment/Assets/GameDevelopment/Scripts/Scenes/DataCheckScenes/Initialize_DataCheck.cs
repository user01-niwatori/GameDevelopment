using UnityEngine;
using UniRx;

namespace GameDevelopment.Scenes.DataCheckScenes
{
    /// <summary>
    /// 初期化　データチェック
    /// </summary>
    public class Initialize_DataCheck : NewBehaviour
    {
        private async void Start()
        {
            await SceneFadeManager.Instance.OnTransitionFinished;
            SceneFadeManager.Instance.Transition(SceneName.Title);
        }
    }
}