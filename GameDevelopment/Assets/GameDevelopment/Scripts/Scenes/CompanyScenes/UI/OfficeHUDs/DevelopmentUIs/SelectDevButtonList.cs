using UnityEngine.UI;
using UnityEngine;
using UniRx;

namespace GameDevelopment.Scenes.CompanyScenes.UI.OfficeHUDs.DevelopmentUIs
{
    /// <summary>
    /// 開発するものを選択するボタンリスト
    /// </summary>
    public class SelectDevButtonList : BehaviourEnabled
    {
        /// <summary>
        /// 開発中のソフト/ハードに関するUI
        /// </summary>
        [SerializeField]
        private DevelopmentUI _developmentUI = default;

        /// <summary>
        /// ゲームソフト開発ボタン
        /// </summary>
        [SerializeField]
        private Button _gameSoftDevButton = default;

        /// <summary>
        /// ゲームハード開発ボタン
        /// </summary>
        [SerializeField]
        private Button _gameHardDevButton = default;

        /// <summary>
        /// ゲームソフト開発ボタン
        /// </summary>
        [SerializeField]
        private Button _closeButton = default;

        /// <summary>
        /// ゲームソフト開発ボタン
        /// </summary>
        [SerializeField]
        private Button _returnButton = default;

        /// <summary>
        /// Start
        /// </summary>
        private void Start()
        {
            // ソフト開発ボタン押下時
            // ソフト開発UIを表示
            _gameSoftDevButton
                .OnClickAsObservable()
                .Subscribe(_ => _developmentUI.DisplayGameSoftDevUI())
                .AddTo(this);

            // 閉じるボタン押下時
            // UIを非表示にする。
            _closeButton
                .OnClickAsObservable()
                .Subscribe(_ => _developmentUI.Close())
                .AddTo(this);
        }
    }
}