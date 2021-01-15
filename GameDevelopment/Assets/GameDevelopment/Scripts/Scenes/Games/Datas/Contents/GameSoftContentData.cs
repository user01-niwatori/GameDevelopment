using System;
namespace GameDevelopment.Scenes.Games.Datas.Genres
{
    /// <summary>
    /// ゲームソフトの内容の名前
    /// </summary>
    public enum EGameSoftContentName
    {
        None,
        Movie,
        Animation,
        Fantasy,
        Max,
    };

    /// <summary>
    /// ゲームソフトの内容クラス
    /// </summary>
    [Serializable]
    public class GameSoftContentData
    {
        /// <summary>
        /// 値段
        /// </summary>
        public int Price = 0;

        /// <summary>
        /// 経験
        /// </summary>
        public int EP = 0;

        /// <summary>
        /// 世間の評価値
        /// </summary>
        public EEvaluation Evaluation = EEvaluation.E;

        /// <summary>
        /// 名前
        /// </summary>
        public EGameSoftContentName Name = EGameSoftContentName.None;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public GameSoftContentData()
        {

        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="name"></param>
        public GameSoftContentData(EGameSoftContentName name)
        {
            Name = name;
        }
    }
}
