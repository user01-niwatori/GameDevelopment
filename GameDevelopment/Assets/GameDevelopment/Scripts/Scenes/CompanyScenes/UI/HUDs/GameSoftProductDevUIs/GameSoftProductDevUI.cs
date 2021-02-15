using UnityEngine;

namespace GameDevelopment.Scenes.CompanyScenes.UI.HUDs.GameSoftProductDevUIs
{
    /// <summary>
    /// 開発中のゲームソフトに関する情報のUI
    /// </summary>
    public class GameSoftProductDevUI : BehaviourEnabled
    {
        /// <summary>
        /// ゲームソフトのパラメータUI
        /// </summary>
        [SerializeField]
        private GameSoftProductDevParamUI _gamesoftProductDevParamUI = default;

        /// <summary>
        /// ゲームソフトのパラメータUI表示
        /// </summary>
        public void DisplayParamUI()
        {
            _gamesoftProductDevParamUI.SetEnabled(true);
        }
    }
}
