using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using GameDevelopment.Common.Datas;


namespace GameDevelopment.Scenes.CompanyScenes.UI.HUDs.UserInfoUIs
{
    /// <summary>
    /// 日付のUI
    /// </summary>
    public class DateUI : BehaviourEnabled
    {
        /// <summary>
        /// 日付テキスト
        /// </summary>
        [SerializeField]
        private Text _dateText = default;

        /// <summary>
        /// Start
        /// </summary>
        private void Start()
        {
            GameInfo.Date = new Date(1980, 1, 1);

            // 指定秒数後
            // 日付を更新
            Observable
                .Interval(TimeSpan.FromSeconds(2f))
                .Subscribe(_ => UpdateDate());
        }

        /// <summary>
        /// 日付を更新する
        /// </summary>
        private void UpdateDate()
        {
            GameInfo.Date.AddDays(1);
            _dateText.text = GameInfo.Date.Display();
        }
    }
}
