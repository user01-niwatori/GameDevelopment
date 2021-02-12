using System;
using System.Collections.Generic;

namespace GameDevelopment.Scenes.Games.Datas
{
    /// <summary>
    /// 売り物クラス
    /// </summary>
    [Serializable]
    public class SaleData
    {
        /// <summary>
        /// 名前
        /// </summary>
        public string Name = string.Empty;

        /// <summary>
        /// 会社名
        /// </summary>
        public string CompanyName = string.Empty;

        /// <summary>
        /// 値段
        /// </summary>
        public int Price = 0;

        /// <summary>
        /// 週間売上
        /// </summary>
        public List<int> WeekSales = new List<int>();

        /// <summary>
        /// レビュー
        /// </summary>
        public GameReviewData Review = default;

        /// <summary>
        /// 売上
        /// </summary>
        /// <returns></returns>
        public int Sales()
        {
            int sales = 0;

            foreach (var s in WeekSales)
            {
                sales += s;
            }
            return sales;
        }
    }
}