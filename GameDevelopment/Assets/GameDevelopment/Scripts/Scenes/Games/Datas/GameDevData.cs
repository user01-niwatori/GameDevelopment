using UniRx;
using System;
using GameDevelopment.Common.Expansions;
using GameDevelopment.Common.Datas;
using GameDevelopment.Scenes.Employees.Datas;
using GameDevelopment.Scenes.Games.Datas.Genres;
using GameDevelopment.Scenes.Games.Datas.Contents;
using GameDevelopment.Scenes.Games.Datas.Scales;

namespace GameDevelopment.Scenes.Games.Datas
{
    /// <summary>
    /// 開発中のゲームデータの情報
    /// </summary>
    [Serializable]
    public class GameDevData
    {
        /// <summary>
        /// 開発フェーズ
        /// </summary>
        public PhaseTypeReactiveProperty Phase = new PhaseTypeReactiveProperty(EPhaseType.Proto);

        /// <summary>
        /// 開発日情報
        /// </summary>
        public DevelopmentDate Dates = new DevelopmentDate();
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
        /// ゲームソフトの開発規模
        /// </summary>
        public GameSoftScaleData Scale = default;

        /// <summary>
        /// リードディレクター
        /// </summary>
        public EmployeeData Director = default;

        /// <summary>
        /// リードプログラマー
        /// </summary>
        public EmployeeData Programmer= default;

        /// <summary>
        /// リードデザイナー
        /// </summary>
        public EmployeeData Designer = default;

        /// <summary>
        /// リードシナリオライター
        /// </summary>
        public EmployeeData ScenarioWirter = default;

        /// <summary>
        /// 作曲者
        /// </summary>
        public EmployeeData Composer = default;


    }
}