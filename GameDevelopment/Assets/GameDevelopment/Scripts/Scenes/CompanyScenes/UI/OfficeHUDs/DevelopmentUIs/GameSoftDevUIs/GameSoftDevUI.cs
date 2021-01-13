using UnityEngine;
using GameDevelopment.Scenes.CompanyScenes.UI.OfficeHUDs.DevelopmentUIs.GameSoftDevUIs.HouseDevUIs;

namespace GameDevelopment.Scenes.CompanyScenes.UI.OfficeHUDs.DevelopmentUIs.GameSoftDevUIs
{
    /// <summary>
    /// 開発中のゲームソフトに関するUIクラス
    /// </summary>
    public class GameSoftDevUI : NewBehaviour
    {
        /// <summary>
        /// 開発中のソフト/ハードに関するUI
        /// </summary>
        [SerializeField]
        private DevelopmentUI _developmentUI = default;

        /// <summary>
        /// ゲームソフトボタンリスト
        /// </summary>
        [SerializeField]
        private SoftDevButtonList _softDevButtonList = default;

        /// <summary>
        /// 自社開発UI
        /// </summary>
        [SerializeField]
        private HouseDevUI _houseDevUI = default;

        /// <summary>
        /// ゲームオブジェクト表示時
        /// </summary>
        private void OnEnable()
        {
            DisplaySoftDevButtonList();
        }

        /// <summary>
        /// ゲームソフトボタンリスト表示
        /// </summary>
        public void DisplaySoftDevButtonList()
        {
            Hide();
            _softDevButtonList.SetEnabled(true);
        }

        /// <summary>
        /// 自社開発UI表示
        /// </summary>
        public void DisplayHouseDevUI()
        {
            Hide();
            _houseDevUI.SetEnabled(true);
        }

        /// <summary>
        /// 子オブジェクトのUIを非表示にする
        /// </summary>
        private void Hide()
        {
            _softDevButtonList.SetEnabled(false);
            _houseDevUI.SetEnabled(false);
        }

        /// <summary>
        /// オブジェクトを非表示にする
        /// </summary>
        public void Close()
        {
            Hide();
            this.gameObject.SetActive(false);
            _developmentUI.Close();
        }
    }
}
