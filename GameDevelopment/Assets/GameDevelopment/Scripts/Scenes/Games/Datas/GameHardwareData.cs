using System;
using System.Collections.Generic;
using GameDevelopment.Common.Datas;

namespace GameDevelopment.Scenes.Games.Datas
{

    // TODO: ゲームハードのスペックデータも追加
    // ハードスペックによって限界値がある。
    /*
       作りやすさ
       CPUの性能
       グラフィックの性能
       サウンドの性能
       ハードのシェア率
    */

    /// <summary>
    /// ゲームハードデータ
    /// </summary>
    [Serializable]
    public class GameHardwareData
    {
        /// <summary>
        /// 名前
        /// </summary>
        public string Name = default;

        /// <summary>
        /// 会社名
        /// </summary>
        public string CompanyName = string.Empty;

        /// <summary>
        /// 開発開始日
        /// </summary>
        public Date DevelopmentStartDate = default;

        /// <summary>
        /// 発売日
        /// </summary>
        public Date ReleaseDate = default;

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
