using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using GameDevelopment.Common.Datas;
using GameDevelopment.Scenes.Companys.Entitys;

namespace GameDevelopment.Scenes.CompanyScenes.UI.HUDs.GameSoftProductDevUIs
{
    /// <summary>
    /// 開発中のゲームソフトのパラメーターを表示するUI
    /// </summary>
    public class GameSoftProductDevParamUI : BehaviourEnabled
    {
        /// <summary>
        /// オフィス
        /// </summary>
        [SerializeField]
        private Office _office = default;

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
        /// メモリ開放用Disposable
        /// </summary>
        private IDisposable[] _disposables = default;


        /// <summary>
        /// オブジェクト表示時
        /// </summary>
        private async void OnEnable()
        {
            await _office.OnInitialized;

            _disposables = new IDisposable[5];

            // プログラムデータ表示
            _disposables[0] = GameInfo.User.Company.CurrentOffice.GameSoftProduct?.Param.Program
                             .Subscribe(x => _programText.text = x.ToString());

            // グラフィックデータ表示
            _disposables[1] = GameInfo.User.Company.CurrentOffice.GameSoftProduct?.Param.Graphic
                             .Subscribe(x => _graphicText.text = x.ToString());

            // シナリオデータ表示
            _disposables[2] = GameInfo.User.Company.CurrentOffice.GameSoftProduct?.Param.Scenario
                             .Subscribe(x => _scenarioText.text = x.ToString());

            // サウンドデータ表示
            _disposables[3] = GameInfo.User.Company.CurrentOffice.GameSoftProduct?.Param.Sound
                             .Subscribe(x => _soundText.text = x.ToString());

            // バグデータ表示
            _disposables[4] = GameInfo.User.Company.CurrentOffice.GameSoftProduct?.Param.Bug
                             .Subscribe(x => _bugText.text = x.ToString());
        }

        /// <summary>
        /// オブジェクト非表示時
        /// </summary>
        private void OnDisable()
        {
            Release();
        }

        /// <summary>
        /// オブジェクト破棄時
        /// </summary>
        private void OnDestroy()
        {
            Release();
        }

        /// <summary>
        /// メモリ開放
        /// </summary>
        private void Release()
        {
            foreach (var dis in _disposables)
            {
                dis.Dispose();
            }
        }
    }

}