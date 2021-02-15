using UnityEngine;
using UnityEngine.UI;

namespace GameDevelopment.Scenes.CompanyScenes.UI.OfficeHUDs.EmployeeUIs
{
    /// <summary>
    /// 社員UIのボタンリスト
    /// </summary>
    public class EmployeesButtonList : BehaviourEnabled
    {
        /// <summary>
        /// 社員UI
        /// </summary>
        [SerializeField]
        private EmployeesUI _employeesUI = default;

        /// <summary>
        /// 戻るボタン
        /// </summary>
        [SerializeField]
        private Button _returnButton = default;

        /// <summary>
        /// Start
        /// </summary>
        private void Start()
        {
            //_returnButton
            //    .OnClickAsObservable()
            //    .Subscribe(_ => )
                
        }
    }
}
