using UnityEngine;
using UnityEngine.EventSystems;

namespace GameDevelopment.Scenes.Employees.Entitys
{
    /// <summary>
    /// 社員の当たり判定
    /// </summary>
    [RequireComponent(typeof(EmployeeCore))]
    [RequireComponent(typeof(EventTrigger))]
    public class EmployeeCollision : MonoBehaviour
    {
        /// <summary>
        /// HUD
        /// </summary>
        [SerializeField]
        private EmployeeHUD _employeeHUD = default;

        /// <summary>
        /// コントローラーのRayがオブジェクトに乗ったときHUD表示
        /// </summary>
        public void PointerEnter_DisplayHUD()
        {
            var core = GetComponent<EmployeeCore>();

            core.Data.State.Value = Datas.EState.Home;
            _employeeHUD.gameObject.SetActive(true);
        }

        /// <summary>
        /// コントローラーのRayがオブジェクトから離れたときHUD非表示
        /// </summary>
        public void PointerExit_HideHUD()
        {
            _employeeHUD.gameObject.SetActive(false);
        }
    }
}
