using System;

namespace GameDevelopment.Scenes.Games.Datas.Genres
{
    /// <summary>
    /// ゲームソフトジャンルの名前
    /// </summary>
    public enum EGameSoftGenreName
    {
        None,

        Action,
        BeltAction,
        HuntingAction,
        Fighting,
        Music,
        Racing,
        LD,

        Shooting,
        RPG,
        Strategy,
        Adventure,
        BeautifulGirl,
        Puzzle,

        Max,
    };

    /// <summary>
    /// ゲームソフトのジャンルクラス
    /// </summary>
    [Serializable]
    public class GameSoftGenreData
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
        public EGameSoftGenreName Name = EGameSoftGenreName.None;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public GameSoftGenreData()
        {

        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="name"></param>
        public GameSoftGenreData(EGameSoftGenreName name)
        {
            Name = name;
        }
    }
}