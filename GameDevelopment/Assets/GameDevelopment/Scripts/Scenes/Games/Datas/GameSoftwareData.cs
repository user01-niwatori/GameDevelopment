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
    }
}
