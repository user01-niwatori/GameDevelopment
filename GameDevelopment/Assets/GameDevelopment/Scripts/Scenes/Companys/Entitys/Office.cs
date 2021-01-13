﻿using UnityEngine;
using GameDevelopment.Scenes.Games.Datas;
using GameDevelopment.Scenes.Employees.Datas;
using GameDevelopment.Scenes.Employees.Generators;
using GameDevelopment.Common.Datas;

namespace GameDevelopment.Scenes.Companys.Entitys
{
    /// <summary>
    /// オフィス
    /// </summary>
    public class Office : NewBehaviour
    {
        /// <summary>
        /// 社員生成器
        /// </summary>
        [SerializeField]
        private EmployeeGenerator _employeeGenerator = default;

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
                var hardware = new Games.Datas.GameHardwareData();
                hardware.Name = "Hard_" + i;
                GameInfo.Industry.Hards.Add(hardware);
            }

            // ゲームジャンル開放
            for(int i = 1; i < 10; i++)
            {
                GameInfo.User.Rock.GameSoftGenres.Add((EGameSoftGenre)i);
            }

            // 社員生成
            for (int i = 0; i < 4; i++)
            {
                _employeeGenerator.Create(0);
            }

            //_employeeGenerator.Initialize();
        }

        /// <summary>
        /// ゲームソフト開発を始める
        /// </summary>
        public void StartGameSoftProduct(GameSoftwareData soft)
        {
            GameInfo.User.Company.CurrentOffice.GameSoftProduct = soft;

            // 社員の仕事をゲームソフト開発にする。
            for(int i = 0; i < GameInfo.User.Company.CurrentOffice.EmployeeCount; i++)
            {
                GameInfo.User.Company.CurrentOffice.Employees[i].Task.Value = EEmployeeTask.GameSoft;
            }
        }
    }
}
