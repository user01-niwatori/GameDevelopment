using UnityEngine;
using GameDevelopment.Scenes.CompanyScenes.UI.OfficeHUDs.DevelopmentUIs;

namespace GameDevelopment.Scenes.CompanyScenes.UI.OfficeHUDs
{
    /// <summary>
    /// OfficeのHUD
    /// </summary>
    public class OfficeHUD : NewBehaviour
    {
        /// <summary>
        /// 開発情報のボタンリスト
        /// </summary>
        [SerializeField]
        private DevInfoButtonList _devInfoButtonList = default;

        /// <summary>
        /// 開発中のソフト/ハードに関するUI
        /// </summary>
        [SerializeField]
        private DevelopmentUI _developmentUI = default;


        /// <summary>
        /// ゲームオブジェクト表示時
        /// </summary>
        private void OnEnable()
        {
            DispalyDevInfoButtonList();
        }

        /// <summary>
        /// 開発情報のボタンリスト表示
        /// </summary>
        public void DispalyDevInfoButtonList()
        {
            Hide();
            _devInfoButtonList.SetEnabled(true);
        }

        /// <summary>
        /// 開発中のソフト/ハードに関するUIを表示
        /// </summary>
        public void DisplayDevelopmentUI()
        {
            Hide();
            _developmentUI.SetEnabled(true);
        }

        /// <summary>
        /// 非表示
        /// </summary>
        private void Hide()
        {
            _developmentUI.SetEnabled(false);
        }
    }
}
