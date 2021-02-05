using UnityEngine;
using UnityEngine.UI;
using GameDevelopment.Scenes.Games.Datas.Contents;
using UnityEngine.Events;
using UniRx;

namespace GameDevelopment.Scenes.CompanyScenes.UI.OfficeHUDs.DevelopmentUIs.GameSoftDevUIs.HouseDevUIs
{
    /// <summary>
    /// 内容の情報に関するUI
    /// </summary>
    public class GameContentInfoUI : MonoBehaviour
    {
        /// <summary>
        /// 内容のボタン
        /// </summary>
        [SerializeField]
        private Button _contentButton = default;

        /// <summary>
        /// 内容の名前
        /// </summary>
        [SerializeField]
        private Text _contentNameText = default;

        /// <summary>
        /// 経験
        /// </summary>
        [SerializeField]
        private Text _epText = default;

        /// <summary>
        /// ユーザーからの評価
        /// </summary>
        [SerializeField]
        private Text _evaluationText = default;

        /// <summary>
        /// 費用
        /// </summary>
        [SerializeField]
        private Text _costText = default;

        /// <summary>
        /// 外部に名前を公開する
        /// </summary>
        public string Name { get { return _contentNameText.text; } }

        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="content">内容</param>
        /// <param name="callback">コールバック</param>
        public void Initialized(GameSoftContentData content, UnityAction callback)
        {
            // 情報をテキストに表示
            _contentNameText.text = content.Name.ToString();
            _epText.text          = $"Lv{content.EP}";
            _evaluationText.text  = content.Evaluation.ToString();
            _costText.text        = content.Price.ToString();

            // ボタン押下時
            // コールバック実行
            _contentButton
                .OnClickAsObservable()
                .Subscribe(_ => callback())
                .AddTo(this);
        }
    }
}