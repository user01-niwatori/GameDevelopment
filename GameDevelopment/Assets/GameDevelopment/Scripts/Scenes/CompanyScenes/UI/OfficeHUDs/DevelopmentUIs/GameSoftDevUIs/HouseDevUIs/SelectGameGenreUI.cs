using UnityEngine;
using System.Collections.Generic;
using GameDevelopment.Common.Datas;

namespace GameDevelopment.Scenes.CompanyScenes.UI.OfficeHUDs.DevelopmentUIs.GameSoftDevUIs.HouseDevUIs
{
    /// <summary>
    /// 開発するゲームソフトのジャンルを決めるUI
    /// </summary>
    public class SelectGameGenreUI : NewBehaviour
    {
        /// <summary>
        /// Content
        /// </summary>
        [SerializeField]
        private GameObject _content = default;

        /// <summary>
        /// ゲームジャンルのリスト
        /// </summary>
        private List<GameObject> _gameGenreList = new List<GameObject>();

        /// <summary>
        /// ゲームオブジェクト表示時
        /// </summary>
        private void OnEnable()
        {
            CreateGenreList();
        }

        /// <summary>
        /// ジャンルリストを作成
        /// </summary>
        private void CreateGenreList()
        {
            // 開放されているゲームソフトのジャンルだけ選択肢に表示
            foreach (var genre in GameInfo.User.Rock.GameSoftGenres)
            {
                var genreUI = Resources.Load($"{PathData.SelectGameGenre}/{genre.ToString()}") as GameObject;
                _gameGenreList.Add(genreUI);
            }
        }
    }
}

