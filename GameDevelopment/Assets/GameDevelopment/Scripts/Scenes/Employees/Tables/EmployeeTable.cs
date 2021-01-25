using System;
using System.Collections.Generic;
using GameDevelopment.Scenes.Employees.Datas;

namespace GameDevelopment.Scenes.Employees.Tables
{
    /// <summary>
    /// 社員のテーブルデータ
    /// </summary>
    [Serializable]
    public class EmployeeTable
    {
        /// <summary>
        /// 社員の細田人数
        /// </summary>
        public const int MaxEmployee = 10;

        /// <summary>
        /// パラメーター
        /// </summary>
        public List<EmployeeData> Param = new List<EmployeeData>();
    }
}
