using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace GameDevelopment.Scenes.CompanyScenes.UI.OfficeHUDs.DevelopmentUIs.GameSoftDevUIs
{
    /// <summary>
    /// ゲームソフトボタンリスト
    /// </summary>
    public class SoftDevButtonList : BehaviourEnabled
    {
        /// <summary>
        /// ゲームソフト開発UI
        /// </summary>
        [SerializeField]
        private GameSoftDevUI _gameSoftDevUI = default;

        /// <summary>
        /// 自社開発ボタン
        /// </summary>
        [SerializeField]
        private Button _houseDevButton = default;

        /// <summary>
        /// 受託開発ボタン
        /// </summary>
        [SerializeField]
        private Button _contractDevButton = default;

        /// <summary>
        /// 依頼ボタン
        /// </summary>
        [SerializeField]
        private Button _requestButton = default;

        /// <summary>
        /// 閉じるボタン
        /// </summary>
        [SerializeField]
        private Button _closeButton = default;

        /// <summary>
        /// 戻るボタン
        /// </summary>
        [SerializeField]
        private Button _returnButton = default;

        /// <summary>
        /// Start
        /// </summary>
        void Start()
        {
            // 自社開発ボタン押下時
            // 自社開発UIを表示
            _houseDevButton
                .OnClickAsObservable()
                .Subscribe(_ => _gameSoftDevUI.DisplayHouseDevUI())
                .AddTo(this);

            // 閉じるボタン押下時
            // UIを非表示にする。
            _closeButton
                .OnClickAsObservable()
                .Subscribe(_ => _gameSoftDevUI.Close())
                .AddTo(this);
        }
    }
}
