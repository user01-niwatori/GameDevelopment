using UniRx;
using UnityEngine.UI;
using UnityEngine;

namespace GameDevelopment.Scenes.OfficeScenes.UI.OfficeHUDs
{
    /// <summary>
    /// 開発情報のボタンリスト
    /// </summary>
    public class DevInfoButtonList : MonoBehaviour
    {
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
        private void Start()
        {
            //_developmentButton
            //    .OnClickAsObservable()
            //    .Subscribe(_ => );
                               
        }
    }

}