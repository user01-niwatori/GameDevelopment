using UnityEngine;
using System.Collections.Generic;
using GameDevelopment.Common.Datas;
using GameDevelopment.Scenes.Employees.Entitys;

namespace GameDevelopment.Scenes.Employees.Generators
{
    /// <summary>
    /// 社員を生成するクラス
    /// </summary>
    public class EmployeeGenerator : MonoBehaviour
    {
        /// <summary>
        /// 生成先の親オブジェクト
        /// </summary>
        [SerializeField, Header("生成した社員の親オブジェクト（Employees）")]
        private GameObject _parent = default;

        /// <summary>
        /// 社員のPrefabデータ
        /// </summary>
        [SerializeField]
        private EmployeeCore[] _employeePrefabs = default;

        /// <summary>
        /// 社員達
        /// </summary>
        private List<EmployeeCore> _employees = new List<EmployeeCore>();

        /// <summary>
        /// 初期化処理
        /// </summary>
        public void Initialize()
        {
            // 社員を生成
            int employeeCount = GameInfo.User.Company.CurrentOffice.EmployeeCount();
            for (int i = 0; i < employeeCount; i++)
            {
                Create(i, GameInfo.User.Company.CurrentOffice.Employees[i].ID);
            }
        }

        /// <summary>
        /// 社員を生成
        /// </summary>
        /// <param name="number">何番目に生成されたか</param>
        /// <param name="id">生成する社員のID</param>
        public void Create(int number, int id)
        {
            var employee = Instantiate(_employeePrefabs[id].gameObject);
            employee.transform.parent = _parent.transform;
            employee.GetComponent<EmployeeCore>().Initialize(number);
            _employees.Add(_employeePrefabs[id]);

        }
    }
}