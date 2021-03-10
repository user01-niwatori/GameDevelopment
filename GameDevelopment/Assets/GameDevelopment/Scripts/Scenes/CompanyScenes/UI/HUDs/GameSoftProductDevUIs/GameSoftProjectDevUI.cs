using UnityEngine;

namespace GameDevelopment.Scenes.CompanyScenes.UI.HUDs.GameSoftProjectDevUIs
{
    /// <summary>
    /// 開発中のゲームソフトに関する情報のUI
    /// </summary>
    public class GameSoftProjectDevUI : BehaviourEnabled
    {
        /// <summary>
        /// ゲームソフトのパラメータUI
        /// </summary>
        [SerializeField]
        private GameSoftProjectDevParamUI _gameSoftProjectDevParamUI = default;

        /// <summary>
        /// ゲームソフトのパラメータUI表示
        /// </summary>
        public void DisplayParamUI()
        {
            _gameSoftProjectDevParamUI.SetEnabled(true);
        }
    }
}
