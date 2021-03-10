using UniRx;
using System;

namespace GameDevelopment.Common.Datas
{
    /// <summary>
    /// ゲームのベースとなるパラメーター
    /// </summary>
    [Serializable]
    public class BaseGameParamator
    {
        /// <summary>
        /// プログラム
        /// </summary>
        public IntReactiveProperty Program = new IntReactiveProperty(0);

        /// <summary>
        /// グラフィック
        /// </summary>
        public IntReactiveProperty Graphic = new IntReactiveProperty(0);

        /// <summary>
        /// シナリオ
        /// </summary>
        public IntReactiveProperty Scenario = new IntReactiveProperty(0);

        /// <summary>
        /// サウンド
        /// </summary>
        public IntReactiveProperty Sound = new IntReactiveProperty(0);

    }

    /// <summary>
    /// ゲームソフトのベースとなるパラメータ
    /// </summary>
    [Serializable]
    public class BaseGameSoftParamator : BaseGameParamator
    {
        /// <summary>
        /// バグ
        /// </summary>
        public IntReactiveProperty Bug = new IntReactiveProperty(0);

        /// <summary>
        /// 進行率
        /// </summary>
        public IntReactiveProperty ProgressRate = new IntReactiveProperty(0);
    }
}
