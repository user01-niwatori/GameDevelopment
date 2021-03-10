using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using GameDevelopment.Common.Datas;
using GameDevelopment.Scenes.Employees.Datas;
using GameDevelopment.Scenes.Employees.Tables;
using GameDevelopment.Scenes.CompanyScenes.UI.OfficeHUDs.DevelopmentUIs.GameSoftDevUIs.HouseDevUIs;

namespace GameDevelopment.Scenes.CompanyScenes.UI.HUDs.GameSoftProjectDevUIs
{
    /// <summary>
    /// ゲーム開発フェーズUI
    /// </summary>
    public class BaseGamePhaseUI : MonoBehaviour
    {
        /// <summary>
        /// Content
        /// </summary>
        [SerializeField]
        private GameObject _content = default;

        /// <summary>
        /// 決定ボタン
        /// </summary>
        [SerializeField]
        protected Button _okButton  = default;

        /// <summary>
        /// 主題
        /// </summary>
        [SerializeField]
        protected Text _messageText = default;

        /// <summary>
        /// 一時保存された開発者情報
        /// </summary>
        /// <remarks>
        /// 子クラスでも共有のデータとして扱うためStaticにしている。
        /// </remarks>
        protected static EmployeeData _tempCreator = null;

        /// <summary>
        /// 社員アイコンのリスト
        /// </summary>
        /// <remarks>
        /// Staticで共有することによって、メモリの使用量を節約している。
        /// </remarks>
        private static List<EmployeeInfoIconUI> _employeeIconList = new List<EmployeeInfoIconUI>(EmployeeTable.MaxEmployee);

        /// <summary>
        /// ゲームオブジェクト表示時
        /// </summary>
        protected virtual void OnEnable()
        {
            Time.timeScale = 0;
            CreateEmployeeList();
        }

        /// <summary>
        /// ゲームオブジェクト非表示時
        /// </summary>
        protected virtual void OnDisable()
        {
            Time.timeScale = 1f;
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
                var prefab     = Instantiate(Resources.Load($"{PathData.EmployeeInfoIcon}{employee.ID}"), _content.transform) as GameObject;
                var iconInfoUI = prefab.GetComponent<EmployeeInfoIconUI>();
                _employeeIconList.Add(iconInfoUI);
                // 初期化
                iconInfoUI.Initialize(employee.ID, () => OnClick_SelectCreator(employee));
            }

            // 親オブジェクトを設定
            foreach(var icon in _employeeIconList)
            {
                icon.gameObject.transform.parent = _content.transform;
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
        /// ボタン押下時、開発者選択
        /// </summary>
        /// <param name="employeeData"></param>
        private void OnClick_SelectCreator(EmployeeData employeeData)
        {
            _tempCreator = employeeData;
        }
    }
}