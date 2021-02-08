using GameDevelopment.Common.Datas;
using GameDevelopment.Scenes.Employees.Datas;
using GameDevelopment.Scenes.Employees.Tables;
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

        /// <summary>
        /// 決定ボタン
        /// </summary>
        [SerializeField]
        private Button _okButton = default;

        /// <summary>
        /// 一時保存されたディレクター情報
        /// </summary>
        private EmployeeData _tempDirector = default;

        /// <summary>
        /// 社員アイコンのリスト
        /// </summary>
        private List<EmployeeInfoIconUI> _employeeIconList = new List<EmployeeInfoIconUI>(EmployeeTable.MaxEmployee);

        /// <summary>
        /// ゲームオブジェクト表示時
        /// </summary>
        private void OnEnable()
        {
            CreateEmployeeList();
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

            // 決定ボタン押下時
            // 選択されたディレクターを設定し、前の画面に戻る。
            _okButton
                .OnClickAsObservable()
                .Subscribe(_ =>
                {
                    _houseDevUI.GameSoft.DevInfo.Director = _tempDirector;
                    _tempDirector = null;
                    _houseDevUI.DisplayCreateGameSoftUI();
                })
                .AddTo(this);

        }

        /// <summary>
        /// 社員リスト作成
        /// </summary>
        private void CreateEmployeeList()
        {
            // 自社の社員を選択肢として表示
            foreach (var employee in GameInfo.User.Company.CurrentOffice.Employees)
            {
                // 選択肢としてすでに生成済みなら処理を返す
                if (IsSameContentID(employee.ID)) { continue; }

                // 選択肢生成
                // リストに格納
                var prefab = Instantiate(Resources.Load($"{PathData.EmployeeInfoIcon}{employee.ID}"), _content.transform) as GameObject;
                var iconInfoUI = prefab.GetComponent<EmployeeInfoIconUI>();
                _employeeIconList.Add(iconInfoUI);

                // 初期化
                iconInfoUI.Initialize(employee.ID, () => OnClick_SelectGameDirector(employee));
            }
        }

        /// <summary>
        /// 同じ社員のIDか？
        /// </summary>
        /// <remarks>
        /// TRUE:  同じIDだった
        /// FALSE: 違うIDだった
        /// </remarks>
        /// <param name="id">社員ID</param>
        /// <returns></returns>
        private bool IsSameContentID(int id)
        {
            for (int i = 0; i < _employeeIconList.Count; i++)
            {
                if (_employeeIconList[i].ID == id)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// ボタン押下時、ディレクター選択
        /// </summary>
        /// <param name="employeeData"></param>
        private void OnClick_SelectGameDirector(EmployeeData employeeData)
        {
            _tempDirector = employeeData;
        }
    }
}
