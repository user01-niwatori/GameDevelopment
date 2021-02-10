using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace GameDevelopment.Scenes.Employees.Entitys
{
    /// <summary>
    /// 社員の情報を視覚的に表示
    /// </summary>
    public class EmployeeView : BehaviourInitialized
    {
        /// <summary>
        /// 社員のコア部分
        /// </summary>
        [SerializeField]
        private EmployeeCore _employeeCore = default;

        /// <summary>
        /// HP表示用テキスト
        /// </summary>
        [SerializeField]
        private Text _hpText = default;

        /// <summary>
        /// プログラム表示用テキスト
        /// </summary>
        [SerializeField]
        private Text _programText = default;

        /// <summary>
        /// グラフィック表示用テキスト
        /// </summary>
        [SerializeField]
        private Text _graphicText = default;

        /// <summary>
        /// シナリオ表示用テキスト
        /// </summary>
        [SerializeField]
        private Text _scenarioText = default;

        /// <summary>
        /// サウンド表示用テキスト
        /// </summary>
        [SerializeField]
        private Text _soundText = default;

        /// <summary>
        /// Start
        /// </summary>
        private async void Start()
        {
            await _employeeCore.OnInitialized;
            CheckData();

            // 初期化完了
            _isInitialized.Value = true;
        }

        /// <summary>
        /// データの変化を調べる
        /// </summary>
        private void CheckData()
        {
            // HPを表示
            _employeeCore.HP
                .Subscribe(x => _hpText.text = x.ToString())
                .AddTo(this);

            // プログラムを表示
            _employeeCore.Program
                .Subscribe(x => _programText.text = x.ToString())
                .AddTo(this);

            // グラフィックを表示
            _employeeCore.Graphic
                .Subscribe(x => _graphicText.text = x.ToString())
                .AddTo(this);

            // シナリオを表示
            _employeeCore.Scenario
                .Subscribe(x => _scenarioText.text = x.ToString())
                .AddTo(this);

            // サウンドを表示
            _employeeCore.Sound
                .Subscribe(x => _soundText.text = x.ToString())
                .AddTo(this);
        }

    }
}