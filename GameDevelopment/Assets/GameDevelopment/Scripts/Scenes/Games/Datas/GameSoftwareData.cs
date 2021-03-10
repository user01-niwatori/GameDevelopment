using UniRx;
using System;
using UnityEngine;
using GameDevelopment.Common.Datas;

namespace GameDevelopment.Scenes.Games.Datas
{
    /*
        ハード選択時はGameHardTableから参照 
    */

    /// <summary>
    /// ゲームソフトデータ
    /// </summary>
    [Serializable]
    public class GameSoftwareData : SaleData
    {
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
        public BaseGameSoftParamator Param = new BaseGameSoftParamator();

        ///// <summary>
        ///// 準備
        ///// </summary>
        //public void Setup()
        //{
        //    // 開発開始日
        //    // 開発終了予定日格納
        //    var start                         = GameInfo.Date.Get();
        //    var end                           = start.AddMonths(DevInfo.Scale.GetPeriod());
        //    DevInfo.Dates.DevStartDate        = new Date(start);
        //    DevInfo.Dates.DevEndScheduledDate = new Date(end);
        //}

        ///// <summary>
        ///// 完成度のパーセントの設定
        ///// </summary>
        //public void SetProgressRate(DateTime currentDate)
        //{
        //    // TODO: 処理に時間がかかる、もっと効率の良い求め方があるかも。
        //    // 開発に掛かる日数を求める
        //    // 進行日数を求める
        //    // 進行率を求める
        //    var devDays      　　　　= DevInfo.Dates.DevEndScheduledDate.Time.Value - DevInfo.Dates.DevStartDate.Time.Value;
        //    var progress     　　　　= devDays - (DevInfo.Dates.DevEndScheduledDate.Time.Value - currentDate);
        //    var ratio        　　　　= (float)progress.Days / (float)devDays.Days;
        //    int progressRate 　　　　= (int)((Utility.ConvertDecimalPoint(ratio, 2, Utility.MathType.Floor)) * 100);
        //    Param.ProgressRate.Value = Mathf.Clamp(progressRate, 0, 101);

        //}

        ///// <summary>
        ///// 開発フェーズを設定
        ///// </summary>
        //public void SetPhase(int progress)
        //{
        //    // Alpha 30 ～ 59％
        //    if(DevInfo.Phase.Value != EPhaseType.Alpha && 
        //       progress >= 30 && progress < 60)
        //    {
        //        DevInfo.Phase.Value = EPhaseType.Alpha;
        //    }
        //    // Beta 60 ～ 79％
        //    else if (DevInfo.Phase.Value != EPhaseType.Beta && 
        //             progress >= 60 && progress < 80)
        //    {
        //        DevInfo.Phase.Value = EPhaseType.Beta;
        //    }
        //    // Master 80 ～ 99％
        //    else if (DevInfo.Phase.Value != EPhaseType.Master &&
        //             progress >= 80 && progress < 100)
        //    {
        //        DevInfo.Phase.Value = EPhaseType.Master;
        //    }
        //    // Debug 100% ～
        //    else if(DevInfo.Phase.Value != EPhaseType.Debug &&
        //             progress >= 100)
        //    {
        //        DevInfo.Phase.Value = EPhaseType.Debug;
        //    }
        //    //// Proto それ以外
        //    //else if(DevInfo.Phase.Value != EPhaseType.Proto)
        //    //{
        //    //    DevInfo.Phase.Value = EPhaseType.Proto;
        //    //}
        //}

        /// <summary>
        /// プログラム追加
        /// </summary>
        public void AddProgram(int value)
        {
            Param.Program.Value += value;
        }

        /// <summary>
        /// グラフィック追加
        /// </summary>
        public void AddGraphic(int value)
        {
            Param.Graphic.Value += value;
        }

        /// <summary>
        /// シナリオ追加
        /// </summary>
        public void AddScenario(int value)
        {
            Param.Scenario.Value += value;
        }

        /// <summary>
        /// サウンド追加
        /// </summary>
        public void AddSound(int value)
        {
            Param.Sound.Value += value;
        }

        /// <summary>
        /// バグ追加
        /// </summary>
        public void AddBug(int value)
        {
            Param.Bug.Value += value;

            if (Param.Bug.Value < 0)
            {
                Param.Bug.Value = 0;
            }
        }
    }
}
