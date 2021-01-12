using UnityEngine;
using GameDevelopment.Scenes.CompanyScenes.UI.OfficeHUDs.DevelopmentUIs.GameSoftDevUIs;
using GameDevelopment.Scenes.CompanyScenes.UI.OfficeHUDs.DevelopmentUIs.GameSoftDevUIs.HouseDevUIs;

namespace GameDevelopment.Scenes.CompanyScenes.UI.OfficeHUDs.DevelopmentUIs
{
    /// <summary>
    /// 開発中のソフト/ハードに関するUI
    /// </summary>
    public class DevelopmentUI : NewBehaviour
    {
        /// <summary>
        /// 開発するものを選択するボタンリスト
        /// </summary>
        [SerializeField]
        private SelectDevButtonList _selectDevButtonList = default;

        /// <summary>
        /// 開発ソフトに関するUI
        /// </summary>
        [SerializeField]
        private GameSoftDevUI _gameSoftDevUI = default;

        /// <summary>
        /// ゲームオブジェクト表示時
        /// </summary>
        public void OnEnable()
        {
            DisplaySelectDevButtonList();
        }

        /// <summary>
        /// 開発するものを選択するボタンリストを表示
        /// </summary>
        public void DisplaySelectDevButtonList()
        {
            _selectDevButtonList.SetEnabled(true);
            _gameSoftDevUI.SetEnabled(false);
        }

        /// <summary>
        /// 開発ソフトに関するUIを表示
        /// </summary>
        public void DisplayGameSoftDevUI()
        {
            _selectDevButtonList.SetEnabled(false);
            _gameSoftDevUI.SetEnabled(true);
        }
    }
}
