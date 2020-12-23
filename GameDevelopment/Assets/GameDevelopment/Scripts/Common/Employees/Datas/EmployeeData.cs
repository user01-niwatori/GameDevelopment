using System;
using System.Collections.Generic;

namespace GameDevelopment.Common.Employees.Datas
{
    /// <summary>
    /// 社員データ
    /// </summary>
    [Serializable]
    public class EmployeeData
    {
        /// <summary>
        /// 名前
        /// </summary>
        public string Name = string.Empty;

        /// <summary>
        /// 年棒
        /// </summary>
        public int YearStick = 0;

        /// <summary>
        /// 職業タイプ
        /// </summary>
        public List<OccupationData> OccupationDatas = new List<OccupationData>();

        /// <summary>
        /// 実績データ
        /// </summary>
        public List<AchievementData> AchievementDatas = new List<AchievementData>();

        /// <summary>
        /// 称号データ
        /// </summary>
        public List<TitleData> TitleDatas = new List<TitleData>();

        /// <summary>
        /// 会社に対しての評価
        /// </summary>
        public string CompanyEvaluation = string.Empty;
    }
}
