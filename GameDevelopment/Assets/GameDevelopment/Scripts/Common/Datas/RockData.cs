using System;
using System.Collections.Generic;
using GameDevelopment.Scenes.Games.Datas.Genres;

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
        public List<GameSoftGenreData> GameSoftGenres = new List<GameSoftGenreData>();

        /// <summary>
        /// ゲームソフトの内容
        /// </summary>
        public List<GameSoftContentData> GameSoftContents = new List<GameSoftContentData>();

    }
}