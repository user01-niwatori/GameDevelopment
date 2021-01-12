using System;
using System.Collections.Generic;
using GameDevelopment.Scenes.Games.Datas;



namespace GameDevelopment.Common.Datas
{
    /// <summary>
    /// ゲーム業界のデータ
    /// </summary>
    /// <remarks>
    /// 業界の流れなどのデータが詰まっている
    /// </remarks>
    [Serializable]
    public class GameIndustryData
    {
        /// <summary>
        /// リリースされたゲームハード
        /// </summary>
        public List<GameHardwareData> Hards = new List<GameHardwareData>();

        /// <summary>
        /// リリースされたゲームソフト
        /// </summary>
        public List<GameSoftwareData> Softs = new List<GameSoftwareData>();
    }
}
