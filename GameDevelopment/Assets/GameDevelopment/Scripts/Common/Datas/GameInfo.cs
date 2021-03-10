
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
        public static Date Date = default;

        /// <summary>
        /// 現在のオフィス
        /// </summary>
        public static int CurrentOffice = 0;

        /// <summary>
        /// フレームレート
        /// </summary>
        public static int FrameRate = 30;

        /// <summary>
        /// 日付更新時間
        /// </summary>
        public static float DateUpdateTime = 0.1f;

        /// <summary>
        /// ユーザーデータ
        /// </summary>
        public static UserData User = default;

        /// <summary>
        /// ゲーム業界のデータ
        /// </summary>
        public static GameIndustryData Industry = default;

        /// <summary>
        /// ゲーム情報をセーブ
        /// </summary>
        public static void Save()
        {
            SaveData.SetClass(SaveKey.Industry, Industry);
            SaveData.SetClass(SaveKey.User, User);
            SaveData.Save();
        }

        /// <summary>
        /// ゲーム情報をロード
        /// </summary>
        public static void Load()
        {
            User     = SaveData.GetClass(SaveKey.User, new UserData());
            Industry = SaveData.GetClass(SaveKey.Industry, new GameIndustryData());
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
