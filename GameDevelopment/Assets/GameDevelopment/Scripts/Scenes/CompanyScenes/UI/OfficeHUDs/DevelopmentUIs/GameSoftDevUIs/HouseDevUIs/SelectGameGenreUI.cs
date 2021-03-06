﻿using UniRx;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using GameDevelopment.Common.Datas;
using GameDevelopment.Scenes.Games.Datas.Genres;

namespace GameDevelopment.Scenes.CompanyScenes.UI.OfficeHUDs.DevelopmentUIs.GameSoftDevUIs.HouseDevUIs
{
    /// <summary>
    /// 開発するゲームソフトのジャンルを決めるUI
    /// </summary>
    public class SelectGameGenreUI : BehaviourEnabled
    {
        /// <summary>
        /// 移動量
        /// </summary>
        private const int MoveDistance = 500;

        /// <summary>
        /// 移動に掛かる時間
        /// </summary>
        private const float MoveTime = 0.3f;

        /// <summary>
        /// 自社開発UI
        /// </summary>
        [SerializeField]
        private HouseDevUI _houseDevUI = default;

        /// <summary>
        /// Content
        /// </summary>
        [SerializeField]
        private GameObject _content = default;

        /// <summary>
        /// 戻るボタン
        /// </summary>
        [SerializeField]
        private Button _returnButton = default;

        /// <summary>
        /// ゲームジャンルのボタンリスト
        /// </summary>
        private List<GameGenreInfoUI> _gameGenreList = new List<GameGenreInfoUI>((int)EGameSoftGenreName.Max);

        /// <summary>
        /// ゲームオブジェクト表示時
        /// </summary>
        private void OnEnable()
        {
            CreateGenreList();
        }

        /// <summary>
        /// Start
        /// </summary>
        private void Start()
        {
            // 戻るボタン押下時
            // 前の画面に戻る
            _returnButton
                .OnClickAsObservable()
                .Subscribe(_ => _houseDevUI.DisplayCreateGameSoftUI())
                .AddTo(this);
        }

        /// <summary>
        /// ジャンルリストを作成
        /// </summary>
        private void CreateGenreList()
        {
            // 開放されているゲームソフトのジャンルだけ選択肢に表示
            foreach (var genre in GameInfo.User.Rock.GameSoftGenres)
            {
                // 選択肢として既に生成済みなら処理を返す
                if (IsSameGenreName(genre.Name)) { continue; }

                // 選択肢生成
                // リストに格納
                var prefab      = Instantiate(Resources.Load($"{PathData.SelectGameGenre}"), _content.transform) as GameObject;
                var genreInfoUI = prefab.GetComponent<GameGenreInfoUI>();
                _gameGenreList.Add(genreInfoUI);

                // ジャンルボタン初期化
                // OnClick_SelectGenre()をコールバックとして渡している
                genreInfoUI.Initialized(genre, () => OnClick_SelectGenre(genre));
            }
        }

        /// <summary>
        /// 同じ名前のゲームジャンルがあるか？
        /// </summary>
        /// <remarks>
        /// TRUE:  同じ名前のゲームジャンルがあった
        /// FALSE: 無かった
        /// </remarks>
        /// <param name="name">ゲームジャンル</param>
        /// <returns></returns>
        private bool IsSameGenreName(EGameSoftGenreName name)
        {
            for (int i = 0; i < _gameGenreList.Count; i++)
            {
                if (_gameGenreList[i].Name == name.ToString())
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// ボタン押下時、ジャンルを選択
        /// </summary>
        private void OnClick_SelectGenre(GameSoftGenreData genre)
        {
            _houseDevUI.GameSoft.DevInfo.Genre = genre;
            _houseDevUI.DisplayCreateGameSoftUI();
        }
    }
}

