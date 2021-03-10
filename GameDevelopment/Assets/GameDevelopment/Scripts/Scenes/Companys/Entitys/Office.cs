using UniRx;
using System;
using UnityEngine;
using GameDevelopment.Common.Datas;
using GameDevelopment.Scenes.Games.Datas;
using GameDevelopment.Scenes.Games.Entitys;
using GameDevelopment.Scenes.Games.Datas.Genres;
using GameDevelopment.Scenes.Games.Datas.Contents;
using GameDevelopment.Scenes.Employees.Generators;

namespace GameDevelopment.Scenes.Companys.Entitys
{
    /// <summary>
    /// オフィス
    /// </summary>
    public class Office : BehaviourEnableAndInitialized
    {
        /// <summary>
        /// 社員生成器
        /// </summary>
        [SerializeField]
        private EmployeeGenerator _employeeGenerator = default;

        /// <summary>
        /// 
        /// </summary>
        [SerializeField]
        private GameSoftProject _gameSoftProject = default;

        /// <summary>
        /// Start
        /// </summary>
        private void Start()
        {
            GameInfo.Load();
            GameInfo.User.CreateCompany("nintendo");
            GameInfo.User.Company.CreateOffice("本社");

            // ハードウェアを開放
            for(int i = 0; i < 3; i++)
            {
                var hardware = new GameHardwareData();
                hardware.Name = "Hard_" + i;
                GameInfo.Industry.Hards.Add(hardware);
            }

            // ゲームジャンル開放
            for(int i = 1; i < (int)EGameSoftGenreName.Max; i++)
            {
                GameInfo.User.Rock.GameSoftGenres.Add(new GameSoftGenreData((EGameSoftGenreName)i));
            }

            // ゲーム内容開放
            for(int i = 1; i < (int)EGameSoftContentName.Max; i++)
            {
                GameInfo.User.Rock.GameSoftContents.Add(new GameSoftContentData((EGameSoftContentName)i));
            }

            // 社員生成
            for (int i = 0; i < 4; i++)
            {
                _employeeGenerator.Create(i);
               
            }

            // 指定秒数後
            // 日付を更新
            GameInfo.Date = new Date(1980, 1, 1);
            Observable
                .Interval(TimeSpan.FromSeconds(GameInfo.DateUpdateTime))
                .Subscribe(_ => GameInfo.Date.AddDays(1));

            // 初期化完了
            _isInitialized.Value = true;
        }

        /// <summary>
        /// ゲームソフト開発のプロジェクトを始める
        /// </summary>
        public void StartGameSoftProject(GameSoftwareData soft)
        {
            _gameSoftProject.Initialized(soft);
        }
    }
}
