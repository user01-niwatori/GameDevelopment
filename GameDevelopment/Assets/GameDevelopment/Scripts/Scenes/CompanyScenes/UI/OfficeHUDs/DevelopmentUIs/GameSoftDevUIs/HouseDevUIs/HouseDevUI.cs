using UnityEngine;
using UnityEditor;

namespace GameDevelopment.Scenes.CompanyScenes.UI.OfficeHUDs.DevelopmentUIs.GameSoftDevUIs.HouseDevUIs
{
    /// <summary>
    /// 自社開発UI
    /// </summary>
    public class HouseDevUI : NewBehaviour
    {
        /// <summary>
        /// ゲームソフト作成UI
        /// </summary>
        [SerializeField]
        private CreateGameSoftUI _createGameSoftUI = default;

        /// <summary>
        /// ゲームオブジェクト表示時
        /// </summary>
        private void OnEnable()
        {
            DisplayCreateGameSoftUI();
        }

        /// <summary>
        /// ゲームソフト作成UI表示
        /// </summary>
        public void DisplayCreateGameSoftUI()
        {
            _createGameSoftUI.SetEnabled(true);
        }
    }
}