using UniRx;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using GameDevelopment.Scenes.Games.Datas.Scales;


namespace GameDevelopment.Scenes.CompanyScenes.UI.OfficeHUDs.DevelopmentUIs.GameSoftDevUIs.HouseDevUIs
{
    /// <summary>
    /// 開発規模の情報に関するUI
    /// </summary>
    public class GameScaleInfoUI : MonoBehaviour
    {
        /// <summary>
        /// 開発規模ボタン
        /// </summary>
        [SerializeField]
        private Button _devScaleButton = default;

        /// <summary>
        /// 開発規模の名前
        /// </summary>
        [SerializeField]
        private Text _devScaleNameText = default;

        /// <summary>
        /// 開発年数
        /// </summary>
        [SerializeField]
        private Text _yearText = default;

        /// <summary>
        /// 経験
        /// </summary>
        [SerializeField]
        private Text _epText = default;

        /// <summary>
        /// 費用
        /// </summary>
        [SerializeField]
        private Text _costText = default;

        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="scale">開発規模</param>
        /// <param name="callback">コールバック</param>
        public void Initialized(GameSoftScaleData scale, UnityAction callback)
        {
            // 情報をテキストに表示
            _devScaleNameText.text = scale.Name.ToString();
            _epText.text           = $"Lv{scale.EP}";
            _yearText.text         = scale.ScaleType.ToString();
            _costText.text         = scale.Price.ToString();

            // ボタン押下時
            // コールバック実行
            _devScaleButton
                .OnClickAsObservable()
                .Subscribe(_ => callback())
                .AddTo(this);
        }
    }
}