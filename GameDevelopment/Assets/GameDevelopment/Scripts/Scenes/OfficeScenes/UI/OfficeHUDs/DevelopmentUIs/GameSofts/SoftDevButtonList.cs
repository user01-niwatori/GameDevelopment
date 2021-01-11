using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace GameDevelopment.Scenes.OfficeScenes.UI.OfficeHUDs.DevelopmentUIs.GameSofts
{
    /// <summary>
    /// ゲームソフトボタンリスト
    /// </summary>
    public class SoftDevButtonList : MonoBehaviour
    {
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

        void Start()
        {

        }
    }
}
