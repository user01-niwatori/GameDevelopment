using UniRx;
using UnityEngine;
using UnityEngine.UI;
using GameDevelopment.Scenes.CompanyScenes.UI.OfficeHUDs;

namespace GameDevelopment.Scenes.CompanyScenes.UI.HUDs.ButtonListUIs
{
    /// <summary>
    /// ボタンリストUI
    /// </summary>
    public class ButtonListUI : BehaviourEnabled
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
        /// 社員ボタン
        /// </summary>
        [SerializeField]
        private Button _employeeButton = default;

        /// <summary>
        /// 戻るボタン
        /// </summary>
        [SerializeField]
        private Button _returnButton = default;

        /// <summary>
        /// Start
        /// </summary>
        private void Start()
        {
            // 開発ボタン押下時
            // 開発中のソフト/ハードに関するUIを表示
            _developmentButton
                .OnClickAsObservable()
                .Subscribe(_ => _officeHUD.DisplayDevelopmentUI())
                .AddTo(this);


            _actionButton
                .OnClickAsObservable()
                .Subscribe(_ => Debug.Log("アクション"));

            _itemButton
                .OnClickAsObservable()
                .Subscribe(_ => Debug.Log("アイテム"));

            _infoButton
                .OnClickAsObservable()
                .Subscribe(_ => Debug.Log("情報"));

            _systemButton
                .OnClickAsObservable()
                .Subscribe(_ => Debug.Log("システム"));

            // 社員ボタン押下時
            // 社員情報のUI表示
            _employeeButton
                .OnClickAsObservable()
                .Subscribe(_ => _officeHUD.DisplayEmployeeUI());

            _returnButton
                .OnClickAsObservable()
                .Subscribe(_ => Debug.Log("戻る"));


        }
    }

}