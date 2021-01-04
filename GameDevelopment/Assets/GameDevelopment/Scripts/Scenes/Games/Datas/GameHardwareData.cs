using System;
using System.Collections.Generic;
using GameDevelopment.Common.Datas;

namespace GameDevelopment.Scenes.Games.Datas
{
    /// <summary>
    /// ゲームハードデータ
    /// </summary>
    [Serializable]
    public class GameHardwareData
    {
        /// <summary>
        /// 開発開始日
        /// </summary>
        public Date DevelopmentStartDate = new Date();

        /// <summary>
        /// 発売日
        /// </summary>
        public Date ReleaseDate = new Date();

        /// <summary>
        /// 値段
        /// </summary>
        public int Price = 0;

        /// <summary>
        /// 週間売上
        /// </summary>
        public List<int> WeekSales = new List<int>();

        /// <summary>
        /// 売上
        /// </summary>
        /// <returns></returns>
        public int Sales()
        {
            int sales = 0;

            foreach(var s in WeekSales)
            {
                sales += s;
            }
            return sales;
        }

    }
}
