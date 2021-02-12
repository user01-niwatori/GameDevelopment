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
