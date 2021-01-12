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
            _softDevButtonList.SetEnabled(true);
            _houseDevUI.SetEnabled(false);
        }

        /// <summary>
        /// 自社開発UI表示
        /// </summary>
        public void DisplayHouseDevUI()
        {
            _softDevButtonList.SetEnabled(false);
            _houseDevUI.SetEnabled(true);
        }
    }
}
