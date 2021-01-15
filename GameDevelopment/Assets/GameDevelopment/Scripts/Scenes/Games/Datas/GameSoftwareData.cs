using System;
using System.Collections.Generic;
using GameDevelopment.Common.Datas;
using UniRx;
using GameDevelopment.Scenes.Games.Datas.Genres;

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
        /// 完成度のパーセント
        /// </summary>
        public IntReactiveProperty CompletionPer = new IntReactiveProperty(0);

        /// <summary>
        /// プログラム
        /// </summary>
        public IntReactiveProperty Program = new IntReactiveProperty(0);

        /// <summary>
        /// グラフィック
        /// </summary>
        public IntReactiveProperty Graphic = new IntReactiveProperty(0);

        /// <summary>
        /// シナリオ
        /// </summary>
        public IntReactiveProperty Scenario = new IntReactiveProperty(0);

        /// <summary>
        /// サウンド
        /// </summary>
        public IntReactiveProperty Sound = new IntReactiveProperty(0);

        /// <summary>
        /// ゲームソフトのジャンル
        /// </summary>
        public GameSoftGenreData Genre = new GameSoftGenreData();

        /// <summary>
        /// ゲームソフトの内容
        /// </summary>
        public GameSoftContentData Content = new GameSoftContentData();

        /// <summary>
        /// ゲームソフト開発期間のタイプ
        /// </summary>
        public EDevSoftPeriodType DevPeriod = EDevSoftPeriodType.Shot;

        /// <summary>
        /// 開発開始日
        /// </summary>
        public Date DevelopmentStartDate = default;

        /// <summary>
        /// 発売日
        /// </summary>
        public Date ReleaseDate = default;

        /// <summary>
        /// 週間売上
        /// </summary>
        public List<int> WeekSales = new List<int>();

        /// <summary>
        /// レビュー
        /// </summary>
        public GameReviewData Review = default;

        /// <summary>
        /// ゲームハード
        /// </summary>
        public GameHardwareData Hard = default;

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
