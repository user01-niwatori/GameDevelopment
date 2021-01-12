using UniRx;
using UnityEngine.UI;
using UnityEngine;

namespace GameDevelopment.Scenes.CompanyScenes.UI.OfficeHUDs
{
    /// <summary>
    /// 開発情報のボタンリスト
    /// </summary>
    public class DevInfoButtonList : NewBehaviour
    {
        /// <summary>
        /// Office HUD
        /// </summary>
        [SerializeField]
        private OfficeHUD _officeHUD = default;

        /// <summary>
        /// 開発ボタン
        /// </summary>
        [SerializeField]
        private Button _developmentButton = default;

        /// <summary>
        /// 行動ボタン
        /// </summary>
        [SerializeField]
        private Button _actionButton = default;

        /// <summary>
        /// アイテムボタン
        /// </summary>
        [SerializeField]
        private Button _itemButton = default;

        /// <summary>
        /// 情報ボタン
        /// </summary>
        [SerializeField]
        private Button _infoButton = default;

        /// <summary>
        /// システムボタン
        /// </summary>
        [SerializeField]
        private Button _systemButton = default;

        /// <summary>
        /// Start
        /// </summary>
        private void Start()
        {
            // 開発ボタン押下時
            // 開発中のソフト/ハードに関するUIを表示
            _developmentButton
                .OnClickAsObservable()
                .Subscribe(_ => _officeHUD.DisplayDevelopmentUI());
        }
    }

}