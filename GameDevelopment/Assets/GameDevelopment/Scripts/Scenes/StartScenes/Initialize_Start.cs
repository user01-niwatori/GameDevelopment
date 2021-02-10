using GameDevelopment.Common.Datas;
using UnityEngine;

namespace GameDevelopment.Scenes.StartScenes
{
    /// <summary>
    /// 初期化　開始時に読み込まれるシーン
    /// </summary>
    public class Initialize_Start : BehaviourEnabled
    {
        /// <summary>
        /// Start
        /// </summary>
        private void Start()
        {
            Application.targetFrameRate = GameInfo.FrameRate;
        }
    }
}
