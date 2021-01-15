using UnityEngine;
using UnityEngine.UI;
using GameDevelopment.Scenes.Games.Datas.Genres;
using UnityEngine.Events;
using UniRx;

namespace GameDevelopment.Scenes.CompanyScenes.UI.OfficeHUDs.DevelopmentUIs.GameSoftDevUIs.HouseDevUIs
{
    /// <summary>
    /// ジャンルに関するボタン
    /// </summary>
    public class GenreButton : MonoBehaviour
    {
        /// <summary>
        /// ジャンルの名前
        /// </summary>
        [SerializeField]
        private Text _nameText = default;

        /// <summary>
        /// 外部に名前を公開する
        /// </summary>
        public string Name { get { return _nameText.text; } }

        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="name">名前</param>
        public void Initialized(GameSoftGenreData genre, UnityAction callback)
        {
            _nameText.text = genre.Name.ToString();

            // ボタン押下時
            // コールバック実行
            GetComponent<Button>().OnClickAsObservable()
                .Subscribe(_ => callback())
                .AddTo(this);
        }
    }
}
