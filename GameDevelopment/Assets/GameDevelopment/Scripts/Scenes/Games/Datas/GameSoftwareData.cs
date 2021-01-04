using System;
using System.Collections.Generic;
using GameDevelopment.Common.Datas;

namespace GameDevelopment.Scenes.Games.Datas
{
    /// <summary>
    /// ゲームソフトデータ
    /// </summary>
    [Serializable]
    public class GameSoftwareData
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
        /// ランク
        /// </summary>
        public int Rank = 0;

        /// <summary>
        /// プログラム
        /// </summary>
        public int Program = 0;

        /// <summary>
        /// グラフィック
        /// </summary>
        public int Graphic = 0;

        /// <summary>
        /// シナリオ
        /// </summary>
        public int Scenario = 0;

        /// <summary>
        /// サウンド
        /// </summary>
        public int Sound = 0;

        /// <summary>
        /// 週間売上
        /// </summary>
        public List<int> WeekSales = new List<int>();

        /// <summary>
        /// レビュー
        /// </summary>
        public GameReviewData Review = new GameReviewData();

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
