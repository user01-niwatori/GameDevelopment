using UniRx;
using UnityEngine.UI;
using UnityEngine;
using GameDevelopment.Common.Datas;
using GameDevelopment.Scenes.Employees.Generators;

namespace GameDevelopment.Scenes.OfficeScenes.UI
{
    /// <summary>
    /// デバッグ周りのUI
    /// </summary>
    public class DebugUI : MonoBehaviour
    {
        /// <summary>
        /// 社員生成器
        /// </summary>
        [SerializeField]
        private EmployeeGenerator _employeeGenerator = default;

        /// <summary>
        /// デバッグリストを表示/非表示にするボタン
        /// </summary>
        [SerializeField]
        private Button _debugButton = default;

        /// <summary>
        /// デバッグ項目が並べられているリスト
        /// </summary>
        [SerializeField]
        private GameObject _debugList = default;

        /// <summary>
        /// 社員生成ボタン
        /// </summary>
        [SerializeField]
        private Button _createEmployeeButton = default;

        /// <summary>
        /// セーブ削除ボタン
        /// </summary>
        [SerializeField]
        private Button _clearButton = default;

        /// <summary>
        /// Start
        /// </summary>
        private void Start()
        {
            // デバッグボタン押下時
            // デバッグリスト表示
            if(_debugButton)
            {
                _debugButton
                .OnClickAsObservable()
                .Subscribe(_ => _debugList.SetActive(!_debugList.activeSelf))
                .AddTo(this);
            }

            // 社員生成ボタン押下時
            // 社員生成
            if (_createEmployeeButton)
            {
                _createEmployeeButton
                    .OnClickAsObservable()
                    .Subscribe(_ => _employeeGenerator.Create())
                    .AddTo(this);
            }

            // セーブ削除ボタン押下時
            // セーブ削除
            if(_clearButton)
            {
                _clearButton
                    .OnClickAsObservable()
                    .Subscribe(_ => SaveData.Clear())
                    .AddTo(this);
            }
        }
    }
}