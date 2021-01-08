using System;
using UniRx;
using System.Collections.Generic;
using UnityEngine;
using GameDevelopment.Common.Expansions;

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
    }

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
        /// 体力
        /// </summary>
        public IntReactiveProperty HP = new IntReactiveProperty(0);

        /// <summary>
        /// 年棒
        /// </summary>
        public int YearStick = 0;

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

    /// <summary>
    /// 社員の場所情報
    /// </summary>
    public class EmployeeLocationInfo
    {
        /// <summary>
        /// 位置
        /// </summary>
        public static Vector3[] Position = new Vector3[]
        {
            new Vector3(-1.5f, 1, 0),
            new Vector3(1.5f, 1, 0),
            new Vector3(-1.5f, 1, -2),
            new Vector3(1.5f, 1, -2),
            new Vector3(-1.5f, 1, -4),
            new Vector3(1.5f, 1, -4),
        };

        /// <summary>
        /// 回転
        /// </summary>
        public static Quaternion[] Rotation = new Quaternion[]
        {
            Quaternion.Euler(0, 90, 0),
            Quaternion.Euler(0, -90, 0),
            Quaternion.Euler(0, 90, 0),
            Quaternion.Euler(0, -90, 0),
            Quaternion.Euler(0, 90, 0),
            Quaternion.Euler(0, -90, 0),
        };
    }
}
