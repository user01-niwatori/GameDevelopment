using System;

namespace GameDevelopment.Common.Datas
{
    /// <summary>
    /// 開発日クラス
    /// </summary>
    [Serializable]
    public class DevelopmentDate
    {
        /// <summary>
        /// 開発開始日
        /// </summary>
        public Date DevStartDate = default;

        /// <summary>
        /// 開発終了予定日
        /// </summary>
        public Date DevEndScheduledDate = default;

        /// <summary>
        /// 開発終了日
        /// </summary>
        public Date DevEndDate = default;

        /// <summary>
        /// 発売日
        /// </summary>
        public Date ReleaseDate = default;
    }
}
