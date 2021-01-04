using GameDevelopment.Common.Datas;
using UnityEngine;

namespace GameDevelopment.Scenes.StartScenes
{
    /// <summary>
    /// 初期化　スタートシーン
    /// </summary>
    public class Initialize_Start : MonoBehaviour
    {
        private void Start()
        {
            Application.targetFrameRate = GameInfo.FrameRate;
        }
    }
}
