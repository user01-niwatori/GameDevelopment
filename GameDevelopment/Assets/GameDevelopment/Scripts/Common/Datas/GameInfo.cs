

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
        public static UserData User = default;

        /// <summary>
        /// ゲーム情報をセーブ
        /// </summary>
        public static void Save()
        {
            SaveData.SetClass(SaveKey.User, User);
            SaveData.Save();
        }

        /// <summary>
        /// ゲーム情報をロード
        /// </summary>
        public static void Load()
        {
            User = SaveData.GetClass(SaveKey.User, new UserData());
        }

        /// <summary>
        /// ゲーム情報を削除
        /// </summary>
        public static void Clear()
        {
            SaveData.Clear();
        }
    }
}
