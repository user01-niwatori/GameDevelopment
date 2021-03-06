﻿using System;
using UniRx;
using System.Collections.Generic;
using UnityEngine;
using GameDevelopment.Common.Expansions;
using GameDevelopment.Common.Datas;

namespace GameDevelopment.Scenes.Employees.Datas
{
    /// <summary>
    /// 状態
    /// </summary>
    public enum EEmployeeState
    {
        None,         // 何もしない
        Work,         // 仕事
        Rest,         // 休む
        GoToWork,     // 出社する
        GoToHome,     // 家に帰る
        Sleep,        // 寝る
    };

    /// <summary>
    /// 仕事
    /// </summary>
    public enum EEmployeeTask
    {
        None,           // 何も無し
        GameSoft,       // ゲームソフト開発 
        GameHard,       // ゲームハード開発
    };

    /// <summary>
    /// 社員データ
    /// </summary>
    [Serializable]
    public class EmployeeData
    {
        /// <summary>
        /// 状態
        /// </summary>
        public EmployeeStateReactiveProperty State = new EmployeeStateReactiveProperty(EEmployeeState.None);

        /// <summary>
        /// 仕事内容
        /// </summary>
        public EmployeeTaskReactiveProperty Task = new EmployeeTaskReactiveProperty(EEmployeeTask.None);

        /// <summary>
        /// 社員ID
        /// </summary>
        public int ID = 0;

        /// <summary>
        /// 名前
        /// </summary>
        public string Name = string.Empty;

        /// <summary>
        /// 制作時間
        /// </summary>
        /// <remarks>
        /// 制作中のゲームソフトに加算するステータス情報（プログラム、グラフィック、etc...）
        /// が加算にかかる時間
        /// </remarks>
        public int DevelopmentTime = 3;

        /// <summary>
        /// 年棒
        /// </summary>
        public int YearStick = 0;

        /// <summary>
        /// 体力
        /// </summary>
        public IntReactiveProperty HP = new IntReactiveProperty(0);

        /// <summary>
        /// パラメーター
        /// </summary>
        public BaseGameParamator Param = new BaseGameParamator();

        /// <summary>
        /// 職業データ
        /// </summary>
        public List<OccupationData> OccupationDatas = new List<OccupationData>();

        /// <summary>
        /// 実績データ
        /// </summary>
        public List<AchievementData> AchievementDatas = new List<AchievementData>();

        /// <summary>
        /// 称号データ
        /// </summary>
        public List<TitleData> TitleDatas = new List<TitleData>();

        /// <summary>
        /// 会社に対しての評価
        /// </summary>
        public CompanyEvaluationData CompanyEvaluationData = default;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="id"></param>
        public EmployeeData(int id)
        {
            ID = id;
            Name = $"社員:{id}";
            //Debug.Log($"{Name}社員が作成されました");
        }

        /// <summary>
        /// データ情報をString型にして返す
        /// </summary>
        public string Info()
        {
            return $"社員ID：{ID}\n" +
                   $"社員の名前：{Name}\n" +
                   $"年棒：{ID}\n";
        }

        /// <summary>
        /// ログを表示
        /// </summary>
        public void Log()
        {
            Debug.Log(Info());
        }
    }
}
