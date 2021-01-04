using System;

namespace GameDevelopment.Scenes.Employees.Datas
{
    /// <summary>
    /// 状態データ
    /// </summary>
    [Serializable]
    public class StatusData
    {
        /// <summary>
        /// 体力
        /// </summary>
        public int HP = 0;

        /// <summary>
        /// プログラム
        /// </summary>
        public int Program = 0;

        /// <summary>
        /// グラフィック
        /// </summary>
        public int Graphic = 0;

        /// <summary>
        /// シナリオ
        /// </summary>
        public int Scenario = 0;

        /// <summary>
        /// サウンド
        /// </summary>
        public int Sound = 0;
    }
}
