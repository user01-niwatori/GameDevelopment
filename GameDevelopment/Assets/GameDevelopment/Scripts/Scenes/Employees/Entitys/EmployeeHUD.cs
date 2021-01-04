using UnityEngine;
using UnityEngine.UI;

namespace GameDevelopment.Scenes.Employees.Entitys
{
    /// <summary>
    /// 社員の情報を視覚的に表示
    /// </summary>
    public class EmployeeHUD : MonoBehaviour
    {
        /// <summary>
        /// 社員のコア部分
        /// </summary>
        [SerializeField]
        private EmployeeCore _employeeCore = default;

        /// <summary>
        /// 社員情報を表示するテキスト
        /// </summary>
        [SerializeField]
        private Text _employeeInfoText = default;

        /// <summary>
        /// ゲームオブジェクト表示した瞬間に呼ばれる処理
        /// </summary>
        private void OnEnable()
        {
            _employeeInfoText.text = _employeeCore.Data.Info();
        }

    }
}