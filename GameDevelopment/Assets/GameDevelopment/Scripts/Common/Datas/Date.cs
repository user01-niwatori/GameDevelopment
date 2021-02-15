using System;
using UniRx;
using GameDevelopment.Common.Expansions;

namespace GameDevelopment.Common.Datas
{
    /// <summary>
    /// 日付
    /// </summary>
    [Serializable]
    public class Date
    {
        /// <summary>
        /// 日付の構造体
        /// </summary>
        private DateTimeReactiveProperty _time = default;
        public  IReadOnlyReactiveProperty<DateTime>Time => _time;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="d"></param>
        public Date(DateTime d)
        {
            _time.Value = d;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="day">日</param>
        public Date(int year = 0, int month = 0, int day = 0)
        {
            _time.Value = new DateTime(year, month, day);
        }

        /// <summary>
        /// 日数を追加
        /// </summary>
        /// <param name="num"></param>
        public void AddDays(int num)
        {
            _time.Value = _time.Value.AddDays(num);
        }

        /// <summary>
        /// 月を追加
        /// </summary>
        /// <param name="num"></param>
        public void AddMonths(int num)
        {
            _time.Value = _time.Value.AddDays(num);
        }

        /// <summary>
        /// 年を追加
        /// </summary>
        /// <param name="num"></param>
        public void AddYears(int num)
        {
            _time.Value = _time.Value.AddDays(num);
        }

        /// <summary>
        /// 日付を返す
        /// </summary>
        /// <returns></returns>
        public DateTime Get()
        {
            return _time.Value;
        }


        /// <summary>
        /// 表示
        /// </summary>
        /// <returns></returns>
        public string Display()
        {
            return $"{_time.Value.Year}/{_time.Value.Month.ToString("D2")}/{_time.Value.Day.ToString("D2")}";
        }
        
    }
}
