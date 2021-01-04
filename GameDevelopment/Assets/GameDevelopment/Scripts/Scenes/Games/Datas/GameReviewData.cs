using System;


namespace GameDevelopment.Scenes.Games.Datas
{
    /// <summary>
    /// レビュークラス
    /// </summary>
    [Serializable]
    public class GameReviewData
    {
        /// <summary>
        /// メッセージ
        /// </summary>
        public string Message = string.Empty;

        /// <summary>
        /// スコア
        /// </summary>
        public int Score = 0;
    }
}
