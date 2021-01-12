using UnityEngine;
using UnityEngine.EventSystems;

namespace GameDevelopment.Scenes.Employees.Entitys
{
    /// <summary>
    /// 社員の当たり判定
    /// </summary>
    [RequireComponent(typeof(EmployeeCore))]
    [RequireComponent(typeof(EventTrigger))]
    public class EmployeeCollision : NewBehaviour
    {
        /// <summary>
        /// 社員情報表示用クラス
        /// </summary>
        [SerializeField]
        private EmployeeView _employeeView = default;

        /// <summary>
        /// コントローラーのRayがオブジェクトに乗ったときHUD表示
        /// </summary>
        public void PointerEnter_DisplayHUD()
        {
            if(_employeeView)
            {
                _employeeView.gameObject.SetActive(true);
            }
        }

        /// <summary>
        /// コントローラーのRayがオブジェクトから離れたときHUD非表示
        /// </summary>
        public void PointerExit_HideHUD()
        {
            if(_employeeView)
            {
                _employeeView.gameObject.SetActive(false);
            }
        }
    }
}
