using GameDevelopment.Common.Datas;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace GameDevelopment.Scenes.CompanyScenes.UI.OfficeHUDs.DevelopmentUIs.GameSoftDevUIs.HouseDevUIs
{
    /// <summary>
    /// ゲームディレクターを選択するUI
    /// </summary>
    public class SelectGameDirectorUI : NewBehaviour
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

        //private List<>

        ///// <summary>
        ///// ゲームオブジェクト表示時
        ///// </summary>
        //private void OnEnable()
        //{
            
        //}

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
        /// 社員リスト作成
        /// </summary>
        private void CreateEmployeeList()
        {
            //foreach(var employee in GameInfo.User.Company.CurrentOffice.Employees)
            //{
            //    if(employee.Name == )
            //}
        }

        ///// <summary>
        ///// 同じ社員の名前か？
        ///// </summary>
        ///// <remarks>
        ///// TRUE:  同じ名前だった
        ///// FALSE: 違う名前だった
        ///// </remarks>
        ///// <param name="name">ゲーム内容</param>
        ///// <returns></returns>
        //private bool IsSameContentName(string name)
        //{
        //    for (int i = 0; i < _gameContentsList.Count; i++)
        //    {
        //        if (_gameContentsList[i].Name == name.ToString())
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}
    }
}
