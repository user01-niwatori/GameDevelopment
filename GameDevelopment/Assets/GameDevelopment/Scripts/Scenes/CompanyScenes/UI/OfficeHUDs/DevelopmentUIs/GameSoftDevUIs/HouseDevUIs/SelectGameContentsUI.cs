using System.Collections.Generic;
using UnityEngine;
using GameDevelopment.Common.Datas;
using UnityEngine.UI;
using GameDevelopment.Scenes.Games.Datas.Contents;
using UniRx;

namespace GameDevelopment.Scenes.CompanyScenes.UI.OfficeHUDs.DevelopmentUIs.GameSoftDevUIs.HouseDevUIs
{
    /// <summary>
    /// 開発するゲームソフトのゲーム内容を選択するUI
    /// </summary>
    public class SelectGameContentsUI : BehaviourEnabled
    {
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
        /// ゲーム内容のリスト
        /// </summary>
        private List<GameContentInfoUI> _gameContentsList = new List<GameContentInfoUI>((int)EGameSoftContentName.Max);

        /// <summary>
        /// ゲームオブジェクト表示時
        /// </summary>
        private void OnEnable()
        {
            CreateContentsList();
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
        /// ゲーム内容リストを作成
        /// </summary>
        private void CreateContentsList()
        {
            // 開放されているゲームソフトのゲーム内容だけ選択肢に表示
            foreach (var content in GameInfo.User.Rock.GameSoftContents)
            {
                // 選択肢として既に生成済みなら処理を返す
                if (IsSameContentName(content.Name)) { continue; }
                var prefab 　 = Instantiate(Resources.Load($"{PathData.SelectGameContent}"), _content.transform) as GameObject;
                var contentUI = prefab.GetComponent<GameContentInfoUI>();
                _gameContentsList.Add(contentUI);

                // 内容ボタン初期化
                contentUI.Initialized(content,() => OnClick_SelectContent(content));
            }
        }

        /// <summary>
        /// 同じ名前のゲーム内容があるか？
        /// </summary>
        /// <remarks>
        /// TRUE:  同じ名前のゲーム内容があった
        /// FALSE: 無かった
        /// </remarks>
        /// <param name="name">ゲーム内容</param>
        /// <returns></returns>
        private bool IsSameContentName(EGameSoftContentName name)
        {
            for (int i = 0; i < _gameContentsList.Count; i++)
            {
                if (_gameContentsList[i].Name == name.ToString())
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// ボタン押下時、内容を選択
        /// </summary>
        /// <param name="content">内容</param>
        private void OnClick_SelectContent(GameSoftContentData content)
        {
            _houseDevUI.GameSoft.DevInfo.Content = content;
            _houseDevUI.DisplayCreateGameSoftUI();
        }
    }
}
