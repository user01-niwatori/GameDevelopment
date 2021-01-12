using System;
using System.Collections.Generic;
using GameDevelopment.Scenes.Games.Datas;

namespace GameDevelopment.Common.Datas
{
    /// <summary>
    /// ロックされているデータ
    /// </summary>
    [Serializable]
    public class RockData
    {
        /// <summary>
        /// ゲームソフトのジャンル
        /// </summary>
        public List<EGameSoftGenre> GameSoftGenres = new List<EGameSoftGenre>();

        /// <summary>
        /// ゲームソフトの内容
        /// </summary>
        public List<EGameSoftContents> GameSoftContents = new List<EGameSoftContents>();

    }
}