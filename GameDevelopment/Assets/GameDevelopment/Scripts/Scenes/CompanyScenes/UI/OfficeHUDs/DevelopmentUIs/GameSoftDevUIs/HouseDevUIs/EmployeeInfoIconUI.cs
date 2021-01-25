using UnityEngine;
using UnityEngine.UI;
using GameDevelopment.Common.Datas;
using GameDevelopment.Scenes.Employees.Datas;

namespace GameDevelopment.Scenes.CompanyScenes.UI.OfficeHUDs.DevelopmentUIs.GameSoftDevUIs.HouseDevUIs
{
    /// <summary>
    /// 社員情報のアイコンUI
    /// </summary>
    public class EmployeeInfoIconUI : NewBehaviour
    {
        //private EmployeeInfoUI

        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; } = default;

        private EmployeeData Data
        {
            get
            {
                return GameInfo.User.Company.CurrentOffice.Employees[ID];
            }
        }

        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="id">社員ID</param>
        public void Initialize(int id)
        {
            ID = id;
        }

        
    }
}
