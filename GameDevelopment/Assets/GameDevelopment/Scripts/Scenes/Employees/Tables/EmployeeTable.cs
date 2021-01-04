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
        /// パラメーター
        /// </summary>
        public List<EmployeeData> Param = new List<EmployeeData>();
    }
}
