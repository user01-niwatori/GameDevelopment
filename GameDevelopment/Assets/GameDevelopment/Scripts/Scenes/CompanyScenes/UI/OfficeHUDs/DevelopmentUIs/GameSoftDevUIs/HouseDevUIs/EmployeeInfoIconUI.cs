using UniRx;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace GameDevelopment.Scenes.CompanyScenes.UI.OfficeHUDs.DevelopmentUIs.GameSoftDevUIs.HouseDevUIs
{
    /// <summary>
    /// 社員情報のアイコンUI
    /// </summary>
    public class EmployeeInfoIconUI : BehaviourEnabled
    {
        /// <summary>
        /// アイコンボタン
        /// </summary>
        [SerializeField]
        private Button _iconButton = default;

        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; } = default;

        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="callback">コールバック</param>
        public void Initialize(int id, UnityAction callback)
        {
            // idを設定
            ID = id;

            // ボタン押下時
            // コールバックを実行
            _iconButton
                .OnClickAsObservable()
                .Subscribe(_ => callback())
                .AddTo(this);
        }
        
    }
}
