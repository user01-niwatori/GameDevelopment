

namespace GameDevelopment.Common.Datas
{
    /// <summary>
    /// ゲーム情報
    /// </summary>
    public class GameInfo
    {
        /// <summary>
        /// 日付
        /// </summary>
        public static Date Date = new Date();

        /// <summary>
        /// 現在のオフィス
        /// </summary>
        public static int CurrentOffice = 0;

        /// <summary>
        /// フレームレート
        /// </summary>
        public static int FrameRate = 30;

        /// <summary>
        /// ユーザーデータ
        /// </summary>
        public static UserData User = new UserData();
    }
}
