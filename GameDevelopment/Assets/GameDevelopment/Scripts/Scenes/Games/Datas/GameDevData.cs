using System;
using UniRx;
using GameDevelopment.Common.Datas;
using GameDevelopment.Scenes.Employees.Datas;
using GameDevelopment.Scenes.Games.Datas.Genres;
using GameDevelopment.Scenes.Games.Datas.Contents;

namespace GameDevelopment.Scenes.Games.Datas
{
    /// <summary>
    /// 開発中のゲームデータの情報
    /// </summary>
    [Serializable]
    public class GameDevData
    {
        /// <summary>
        /// 開発開始日
        /// </summary>
        public Date DevelopmentStartDate = default;

        /// <summary>
        /// 発売日
        /// </summary>
        public Date ReleaseDate = default;

        /// <summary>
        /// 完成度のパーセント
        /// </summary>
        public IntReactiveProperty CompletionPer = new IntReactiveProperty(0);

    }

    /// <summary>
    /// 開発中のゲームソフトの情報
    /// </summary>
    [Serializable]
    public class GameSoftDevData : GameDevData
    {
        /// <summary>
        /// ゲームハード
        /// </summary>
        public GameHardwareData Hard = default;

        /// <summary>
        /// ゲームソフトのジャンル
        /// </summary>
        public GameSoftGenreData Genre = default;

        /// <summary>
        /// ゲームソフトの内容
        /// </summary>
        public GameSoftContentData Content = default;

        /// <summary>
        /// ディレクター
        /// </summary>
        public EmployeeData Director = default;

        /// <summary>
        /// プログラマー
        /// </summary>
        public EmployeeData Programmer= default;

        /// <summary>
        /// デザイナー
        /// </summary>
        public EmployeeData Designer = default;

        /// <summary>
        /// シナリオライター
        /// </summary>
        public EmployeeData ScenarioWirter = default;

        /// <summary>
        /// 作曲者
        /// </summary>
        public EmployeeData Composer = default;

        /// <summary>
        /// ゲームソフト開発期間のタイプ
        /// </summary>
        public EDevSoftPeriodType DevPeriod = EDevSoftPeriodType.Shot;
    }
}