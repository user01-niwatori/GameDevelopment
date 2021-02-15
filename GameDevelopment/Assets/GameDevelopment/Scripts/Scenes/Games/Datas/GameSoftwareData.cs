using UniRx;
using System;
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
        public BaseGameParamator Param = new BaseGameParamator();

        /// <summary>
        /// 準備
        /// </summary>
        public void Setup()
        {
            // 開発開始日
            // 開発終了予定日格納
            var start                         = GameInfo.Date.Get();
            var end                           = start.AddMonths(DevInfo.Scale.GetPeriod());
            DevInfo.Dates.DevStartDate        = new Date(start);
            DevInfo.Dates.DevEndScheduledDate = new Date(end);

            GameInfo.Date.Time
                .Subscribe(x => SetCompletionPer(x));

            UnityEngine.Debug.Log($"開発日:{start} 終了予定日:{end}");
        }

        /// <summary>
        /// 完成度のパーセントの設定
        /// </summary>
        private void SetCompletionPer(DateTime currentDate)
        {
            //uint day   = (uint)(DevInfo.Dates.DevEndScheduledDate.Time.Value.Day - currentDate.Day);
            //uint month = (uint)(DevInfo.Dates.DevEndScheduledDate.Time.Value.Month - currentDate.Month);
            //uint year  = (uint)(DevInfo.Dates.DevEndScheduledDate.Time.Value.Year - currentDate.Year);


        }

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
        }

    }
}
