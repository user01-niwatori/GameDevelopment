using UnityEngine;
using UnityEngine.UI;
using GameDevelopment.Scenes.Games.Datas.Genres;
using UnityEngine.Events;
using UniRx;

namespace GameDevelopment.Scenes.CompanyScenes.UI.OfficeHUDs.DevelopmentUIs.GameSoftDevUIs.HouseDevUIs
{
    /// <summary>
    /// ジャンルの情報に関するUI
    /// </summary>
    public class GameGenreInfoUI : MonoBehaviour
    {
        /// <summary>
        /// ジャンルのボタン
        /// </summary>
        [SerializeField]
        private Button _genreButton = default;

        /// <summary>
        /// ジャンルの名前
        /// </summary>
        [SerializeField]
        private Text _genreNameText = default;

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
        public string Name { get { return _genreNameText.text; } }

        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="genre"></param>
        /// <param name="callback"></param>
        public void Initialized(GameSoftGenreData genre, UnityAction callback)
        {
            // 情報をテキストに表示
            _genreNameText.text  = genre.Name.ToString();
            _epText.text         = $"Lv{genre.EP}";
            _evaluationText.text = genre.Evaluation.ToString();
            _costText.text       = genre.Price.ToString();

            // ボタン押下時
            // コールバック実行
            _genreButton.GetComponent<Button>().OnClickAsObservable()
                .Subscribe(_ => callback())
                .AddTo(this);
        }
    }
}
