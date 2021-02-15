using UnityEngine;
using GameDevelopment.Scenes.CompanyScenes.UI.OfficeHUDs.DevelopmentUIs.GameSoftDevUIs;

namespace GameDevelopment.Scenes.CompanyScenes.UI.OfficeHUDs.DevelopmentUIs
{
    /// <summary>
    /// 開発中のソフト/ハードに関するUI
    /// </summary>
    public class DevelopmentUI : BehaviourEnabled
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
            Hide();
            _selectDevButtonList.SetEnabled(true);
        }

        /// <summary>
        /// 開発ソフトに関するUIを表示
        /// </summary>
        public void DisplayGameSoftDevUI()
        {
            Hide();
            _gameSoftDevUI.SetEnabled(true);
        }

        /// <summary>
        /// 子オブジェクトのUIを非表示にする
        /// </summary>
        private void Hide()
        {
            _selectDevButtonList.SetEnabled(false);
            _gameSoftDevUI.SetEnabled(false);
        }

        /// <summary>
        /// オブジェクトを非表示にする
        /// </summary>
        public void Close()
        {
            Hide();
            this.gameObject.SetActive(false);
        }
    }
}
