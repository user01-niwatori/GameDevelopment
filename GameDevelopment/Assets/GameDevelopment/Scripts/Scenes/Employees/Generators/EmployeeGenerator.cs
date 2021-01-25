using UnityEngine;
using System.Collections.Generic;
using GameDevelopment.Common.Datas;
using GameDevelopment.Scenes.Employees.Entitys;

namespace GameDevelopment.Scenes.Employees.Generators
{
    /// <summary>
    /// 社員を生成するクラス
    /// </summary>
    public class EmployeeGenerator : NewBehaviour
    {
        /// <summary>
        /// 生成先の親オブジェクト
        /// </summary>
        [SerializeField, Header("生成した社員の親オブジェクト（Employees）")]
        private GameObject _parent = default;

        /// <summary>
        /// 社員達
        /// </summary>
        private List<EmployeeCore> _employees = new List<EmployeeCore>();

        /// <summary>
        /// 初期化処理
        /// </summary>
        public void Initialize()
        {
            // セーブ済みの社員を生成
            int employeeCount = GameInfo.User.Company.CurrentOffice.EmployeeCount;
            for (int i = 0; i < employeeCount; i++)
            {
                Load(i);
            }
        }

        /// <summary>
        /// 社員読み込み/表示
        /// </summary>
        /// <param name="number">何番目に生成された社員か？</param>
        private void Load(int number)
        {
            int id                    = GameInfo.User.Company.CurrentOffice.Employees[number].ID;
            var path                  = PathData.Employee + (number + 1).ToString("D2");
            var employee              = Instantiate(Resources.Load(path)) as GameObject;
            var employeeCore          = employee.GetComponent<EmployeeCore>();
            employee.transform.parent = _parent.transform;
            employeeCore.Initialize(number);
            _employees.Add(employeeCore);
        }


        /// <summary>
        /// 社員を生成
        /// </summary>
        /// <param name="id">生成する社員のID</param>
        public void Create(int id = 0)
        {
            GameInfo.User.Company.CurrentOffice.CreateEmployees(id);
            Load(GameInfo.User.Company.CurrentOffice.EmployeeCount - 1);
        }
    }
}