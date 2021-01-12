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
            _devInfoButtonList.SetEnabled(true);
            _developmentUI.SetEnabled(false);
        }

        /// <summary>
        /// 開発中のソフト/ハードに関するUIを表示
        /// </summary>
        public void DisplayDevelopmentUI()
        {
            //_devInfoButtonList.SetEnabled(false);
            _developmentUI.SetEnabled(true);
        }
    }
}
