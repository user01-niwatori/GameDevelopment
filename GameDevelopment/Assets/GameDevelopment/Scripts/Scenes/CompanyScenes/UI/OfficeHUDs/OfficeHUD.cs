using UnityEngine;
using GameDevelopment.Scenes.CompanyScenes.UI.OfficeHUDs.DevelopmentUIs;
using GameDevelopment.Scenes.CompanyScenes.UI.HUDs.ButtonListUIs;
using GameDevelopment.Scenes.CompanyScenes.UI.OfficeHUDs.EmployeeUIs;

namespace GameDevelopment.Scenes.CompanyScenes.UI.OfficeHUDs
{
    /// <summary>
    /// OfficeのHUD
    /// </summary>
    public class OfficeHUD : NewBehaviour
    {
        /// <summary>
        /// ボタンリストUI
        /// </summary>
        [SerializeField]
        private ButtonListUI _buttonListUI = default;

        /// <summary>
        /// 開発中のソフト/ハードに関するUI
        /// </summary>
        [SerializeField]
        private DevelopmentUI _developmentUI = default;

        /// <summary>
        /// 社員UI
        /// </summary>
        [SerializeField]
        private EmployeesUI _employeesUI = default;

        /// <summary>
        /// ゲームオブジェクト表示時
        /// </summary>
        private void OnEnable()
        {
            //DispalyDevInfoButtonList();
        }

        /// <summary>
        /// 開発情報のボタンリスト表示
        /// </summary>
        public void DispalyDevInfoButtonList()
        {
            Hide();
            _buttonListUI.SetEnabled(true);
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
        /// 社員UI　表示/非表示
        /// </summary>
        public void DisplayEmployeeUI()
        {
            Hide();
            _employeesUI.SetEnabled(true);
        }

        /// <summary>
        /// 非表示
        /// </summary>
        private void Hide()
        {
            _developmentUI.SetEnabled(false);
            _employeesUI.SetEnabled(false);
        }
    }
}
