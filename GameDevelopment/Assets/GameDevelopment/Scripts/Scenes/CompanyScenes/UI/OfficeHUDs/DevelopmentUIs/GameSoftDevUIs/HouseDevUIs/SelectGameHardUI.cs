using UnityEngine;
using System.Collections.Generic;
using GameDevelopment.Common.Datas;

namespace GameDevelopment.Scenes.CompanyScenes.UI.OfficeHUDs.DevelopmentUIs.GameSoftDevUIs.HouseDevUIs
{
    /// <summary>
    /// ゲームハードを選択するUI
    /// </summary>
    public class SelectGameHardUI : NewBehaviour
    {
        /// <summary>
        /// Content
        /// </summary>
        [SerializeField]
        private GameObject _content = default;

        /// <summary>
        /// ゲームハードのリスト
        /// </summary>
        private List<GameObject> _gameHardList = new List<GameObject>();

        /// <summary>
        /// ゲームオブジェクト表示時
        /// </summary>
        private void OnEnable()
        {
            CreateHardList();
        }

        /// <summary>
        /// ゲームハードリストを作成
        /// </summary>
        private void CreateHardList()
        {
            // 業界で販売されているハードだけ選択肢に表示
            foreach (var hard in GameInfo.Industry.Hards)
            {
                var hardUI = Resources.Load($"{PathData.SelectGameHard}/{hard.Name}") as GameObject;
                _gameHardList.Add(hardUI);
            }
        }
    }
}