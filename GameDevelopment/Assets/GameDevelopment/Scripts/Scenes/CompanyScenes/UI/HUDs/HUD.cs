using UnityEngine;
using GameDevelopment.Scenes.CompanyScenes.UI.HUDs.GameSoftProductDevUIs;

namespace GameDevelopment.Scenes.CompanyScenes.UI.HUDs
{
    /// <summary>
    /// HUDクラス　常に画面上に表示されるUI
    /// </summary>
    public class HUD : BehaviourEnabled
    {
        /// <summary>
        /// 開発中のゲームソフトの情報
        /// </summary>
        [SerializeField]
        private GameSoftProductDevUI _gameSoftProductDevUI = default;

        /// <summary>
        /// ゲームソフト開発開始
        /// </summary>
        public void StartGameSoftProduct()
        {
            _gameSoftProductDevUI.DisplayParamUI();
        }
    }
}
