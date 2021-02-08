using System;

namespace GameDevelopment.Common.Datas
{
    /// <summary>
    /// 日付
    /// </summary>
    [Serializable]
    public class Date
    {
        /// <summary>
        /// Sysytem 日付の構造体
        /// </summary>
        public DateTime D = default;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="day">日</param>
        public Date(int year = 0, int month = 0, int day = 0)
        {
            D = new DateTime(year, month, day);
        }

        /// <summary>
        /// 日数を追加
        /// </summary>
        /// <param name="num"></param>
        public void AddDays(int num)
        {
            D = D.AddDays(num);
        }

        /// <summary>
        /// 月を追加
        /// </summary>
        /// <param name="num"></param>
        public void AddMonths(int num)
        {
            D = D.AddMonths(num);
        }

        /// <summary>
        /// 年を追加
        /// </summary>
        /// <param name="num"></param>
        public void AddYears(int num)
        {
            D = D.AddYears(num);
        }

        /// <summary>
        /// 日付を返す
        /// </summary>
        /// <returns></returns>
        public DateTime Get()
        {
            return D;
        }

        /// <summary>
        /// 表示
        /// </summary>
        /// <returns></returns>
        public string Display()
        {
            return $"{D.Year}/{D.Month.ToString("D2")}/{D.Day.ToString("D2")}";
        }
        
    }
}
