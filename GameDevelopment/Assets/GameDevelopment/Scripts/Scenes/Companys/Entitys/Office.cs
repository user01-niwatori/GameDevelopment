using UnityEngine;
using GameDevelopment.Scenes.Employees.Generators;
using GameDevelopment.Scenes.Companys.Datas;

namespace GameDevelopment.Scenes.Companys.Entitys
{
    /// <summary>
    /// オフィス
    /// </summary>
    public class Office : MonoBehaviour
    {
        /// <summary>
        /// 社員生成器
        /// </summary>
        [SerializeField]
        private EmployeeGenerator _employeeGenerator = default;

        /// <summary>
        /// Start
        /// </summary>
        private void Start()
        {
            _employeeGenerator.Initialize();
        }
    }
}
