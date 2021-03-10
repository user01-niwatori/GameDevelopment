using System;
using UnityEngine;
using GameDevelopment.Scenes.CompanyScenes.UI.HUDs.GameSoftProjectDevUIs;


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
        private GameSoftProjectDevUI _gameSoftProjectDevUI = default;

        /// <summary>
        /// ゲームソフト開発開始
        /// </summary>
        public void StartGameSoftProject()
        {
            _gameSoftProjectDevUI.DisplayParamUI();
        }
    }
}
