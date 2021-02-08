using System;

namespace GameDevelopment.Scenes.Games.Datas.Scales
{
    /// <summary>
    /// ソフト開発規模
    /// </summary>
    public enum EDevSoftScaleType
    {
        Shot,           // 3カ月
        Usually,        // 6カ月
        Long,           // 1年
        Max,
    };

    /// <summary>
    /// 開発規模の名前
    /// </summary>
    public enum EGameSoftScaleName
    {
        Small,
        Normal,
        Big,
        Max,
    }

    /// <summary>
    /// ゲームソフトの規模
    /// </summary>
    [Serializable]
    public class GameSoftScaleData
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
        /// ゲームソフトの開発期間の名前
        /// </summary>
        public EGameSoftScaleName Name = EGameSoftScaleName.Small;

        /// <summary>
        /// ゲームソフト開発期間のタイプ
        /// </summary>
        public EDevSoftScaleType ScaleType = EDevSoftScaleType.Shot;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public GameSoftScaleData()
        {

        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param number="number"></param>
        public GameSoftScaleData(int number)
        {
            Name      = (EGameSoftScaleName)number;
            ScaleType = (EDevSoftScaleType)number;
        }

    }
}