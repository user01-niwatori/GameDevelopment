using UniRx;
using System;
using UnityEngine;
using UnityEngine.UI;
using GameDevelopment.Common.Datas;

namespace GameDevelopment.Scenes.CompanyScenes.UI.HUDs.GameSoftProductDevUIs
{
    /// <summary>
    /// 開発中のゲームソフトのパラメーターを表示するUI
    /// </summary>
    public class GameSoftProductDevParamUI : BehaviourEnabled
    {
        /// <summary>
        /// プログラムテキスト
        /// </summary>
        [SerializeField]
        private Text _programText = default;

        /// <summary>
        /// グラフィックテキスト
        /// </summary>
        [SerializeField]
        private Text _graphicText = default;

        /// <summary>
        /// シナリオテキスト
        /// </summary>
        [SerializeField]
        private Text _scenarioText = default;

        /// <summary>
        /// サウンドテキスト
        /// </summary>
        [SerializeField]
        private Text _soundText = default;

        /// <summary>
        /// バグテキスト
        /// </summary>
        [SerializeField]
        private Text _bugText = default;

        /// <summary>
        /// Start
        /// </summary>
        private async void Start()
        {
            await System.Threading.Tasks.Task.Delay(1000);

            Display();
        }

        public void Display()
        {
            // プログラムデータ表示
            GameInfo.User.Company.CurrentOffice.GameSoftProduct.Param.Program
                .Subscribe(x => _programText.text = x.ToString())
                .AddTo(this);

            // グラフィックデータ表示
            GameInfo.User.Company.CurrentOffice.GameSoftProduct.Param.Graphic
                .Subscribe(x => _graphicText.text = x.ToString())
                .AddTo(this);

            // シナリオデータ表示
            GameInfo.User.Company.CurrentOffice.GameSoftProduct.Param.Scenario
                .Subscribe(x => _scenarioText.text = x.ToString())
                .AddTo(this);

            // サウンドデータ表示
            GameInfo.User.Company.CurrentOffice.GameSoftProduct.Param.Sound
                .Subscribe(x => _soundText.text = x.ToString())
                .AddTo(this);

            // バグデータ表示
            GameInfo.User.Company.CurrentOffice.GameSoftProduct.Param.Bug
                .Subscribe(x => _bugText.text = x.ToString())
                .AddTo(this);
        }
    }

}