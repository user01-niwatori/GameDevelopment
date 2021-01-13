using System.Collections.Generic;
using UnityEngine;
using GameDevelopment.Common.Datas;

namespace GameDevelopment.Scenes.CompanyScenes.UI.OfficeHUDs.DevelopmentUIs.GameSoftDevUIs.HouseDevUIs
{
    /// <summary>
    /// 開発するゲームソフトのゲーム内容を選択するUI
    /// </summary>
    public class SelectGameContentsUI : NewBehaviour
    {
        /// <summary>
        /// Content
        /// </summary>
        [SerializeField]
        private GameObject _content = default;

        /// <summary>
        /// ゲーム内容のリスト
        /// </summary>
        private List<GameObject> _gameContentsList = new List<GameObject>();

        /// <summary>
        /// ゲームオブジェクト表示時
        /// </summary>
        private void OnEnable()
        {
            CreateContentsList();
        }

        /// <summary>
        /// ゲーム内容リストを作成
        /// </summary>
        private void CreateContentsList()
        {
            // 開放されているゲームソフトのゲーム内容だけ選択肢に表示
            foreach (var content in GameInfo.User.Rock.GameSoftContents)
            {
                var contentUI = Resources.Load($"{PathData.SelectGameHard}/{content.ToString()}") as GameObject;
                _gameContentsList.Add(contentUI);
            }
        }
    }
}
