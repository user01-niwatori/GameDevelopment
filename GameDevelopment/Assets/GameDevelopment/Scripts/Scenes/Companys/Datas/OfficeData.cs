using System;
using System.Collections.Generic;
using UnityEngine;
using GameDevelopment.Scenes.Employees.Datas;
using GameDevelopment.Scenes.Games.Datas;
using GameDevelopment.Common.Datas;

namespace GameDevelopment.Scenes.Companys.Datas
{
    /*
     * 名前
     * お金
     * オフィスレベル
     * 社員
     * 過去製品（ハード、ソフト）
     * ファン層（評価、人気度）
     * 売上（年ごと）
    */

    /// <summary>
    /// オフィス
    /// </summary>
    public enum EOfficeLevel
    {
        Max,
    }

    /// <summary>
    /// オフィスデータ
    /// </summary>
    [Serializable]
    public class OfficeData
    {
        ///// <summary>
        ///// 最大の社員数
        ///// </summary>
        //public int MaxEmployee = 0;

        /// <summary>
        /// 名前
        /// </summary>
        public string Name = string.Empty;

        /// <summary>
        /// お金
        /// </summary>
        public int Money = 0;

        /// <summary>
        /// レベル
        /// </summary>
        public EOfficeLevel EOfficeLevel = default;

        /// <summary>
        /// 社員
        /// </summary>
        public List<EmployeeData> Employees = new List<EmployeeData>();

        /// <summary>
        /// ゲームハード
        /// </summary>
        public List<GameHardwareData> GameHards = new List<GameHardwareData>();

        /// <summary>
        /// ゲームソフト
        /// </summary>
        public List<GameSoftwareData> GameSofts = new List<GameSoftwareData>();

        /// <summary>
        /// 制作中のゲームハード
        /// </summary>
        public GameHardwareData GameHardProduct = default;

        /// <summary>
        /// 制作中のゲームソフト
        /// </summary>
        public GameSoftwareData GameSoftProduct = default;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="name">オフィスの名前</param>
        public OfficeData(string name)
        {
            Name   = name;
            Debug.Log($"{Name}オフィスが作成されました");
        }

        #region 社員

        /// <summary>
        /// 社員を生成
        /// </summary>
        /// <param name="id"></param>
        public void CreateEmployees(int id)
        {
            Employees.Add(new EmployeeData(id));
        }

        /// <summary>
        /// 社員人数
        /// </summary>
        public int EmployeeCount
        {
            get { return Employees.Count; }
        }

        #endregion

        #region ゲームハード

        /// <summary>
        /// ゲームハードの数
        /// </summary>
        public int GameHardCount
        {
            get { return GameHards.Count; }
        }

        /// <summary>
        /// ゲームハード売上
        /// </summary>
        public int HardSales()
        {
            int sales = 0;

            foreach(var hard in GameHards)
            {
                sales += hard.Sales();
            }
            return sales;
        }

        /// <summary>
        /// ゲームハード年間売上
        /// </summary>
        /// <returns></returns>
        public int HardAnnualSales()
        {
            int sales = 0;

            foreach(var hard in GameHards)
            {
                if((GameInfo.Date.Year - hard.ReleaseDate.Year) == 0)
                {
                    sales += hard.Sales();
                }
            }
            return sales;
        }

        #endregion

        #region ゲームソフト

        public void GameSoftDevelopment()
        {
            
        }

        /// <summary>
        /// ゲームソフトの数
        /// </summary>
        public int GameSoftCount
        {
            get { return GameSofts.Count; }
        }

        /// <summary>
        /// ゲームソフト売上
        /// </summary>
        public int SoftSales()
        {
            int sales = 0;

            foreach (var soft in GameSofts)
            {
                sales += soft.Sales();
            }
            return sales;
        }

        /// <summary>
        /// ゲームソフト年間売上
        /// </summary>
        public int SoftAnnualSales()
        {
            int sales = 0;

            foreach (var soft in GameSofts)
            {
                if ((GameInfo.Date.Year - soft.ReleaseDate.Year) == 0)
                {
                    sales += soft.Sales();
                }
            }
            return sales;
        }

        #endregion
    }
}
