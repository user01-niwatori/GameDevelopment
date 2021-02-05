using System;
using System.Collections.Generic;
using GameDevelopment.Common.Datas;
using UniRx;
using GameDevelopment.Scenes.Games.Datas.Genres;
using GameDevelopment.Scenes.Games.Datas.Contents;

namespace GameDevelopment.Scenes.Games.Datas
{
    /*
        ハード選択時はGameHardTableから参照 
    */

    /// <summary>
    /// ソフト開発期間
    /// </summary>
    public enum EDevSoftPeriodType
    { 
        Shot,           // 3カ月
        Usually,        // 6カ月
        Long,           // 1年
    };

    /// <summary>
    /// ゲームソフトデータ
    /// </summary>
    [Serializable]
    public class GameSoftwareData
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
        /// ランク
        /// </summary>
        public int Rank = 0;

        /// <summary>
        /// 開発情報
        /// </summary>
        public GameSoftDevData DevInfo = new GameSoftDevData();

        /// <summary>
        /// パラメーター
        /// </summary>
        public BaseGameParamator Param = new BaseGameParamator();

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
