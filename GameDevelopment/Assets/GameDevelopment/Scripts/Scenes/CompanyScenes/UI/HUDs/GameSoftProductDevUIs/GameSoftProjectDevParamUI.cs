using UniRx;
using System;
using UnityEngine;
using UnityEngine.UI;
using GameDevelopment.Common.Datas;
using GameDevelopment.Scenes.Games.Datas;

namespace GameDevelopment.Scenes.CompanyScenes.UI.HUDs.GameSoftProjectDevUIs
{
    /// <summary>
    /// 開発中のゲームソフトのパラメーターを表示するUI
    /// </summary>
    public class GameSoftProjectDevParamUI : BehaviourEnabled
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
        /// ゲーム開発進行率
        /// </summary>
        [SerializeField]
        private Text _progressRateText = default;

        /// <summary>
        /// 開発フェーズテキスト
        /// </summary>
        [SerializeField]
        private Text _phaseText = default;

        /// <summary>
        /// メモリ開放用Disposable
        /// </summary>
        private IDisposable[] _disposables = default;

        /// <summary>
        /// オブジェクト表示時
        /// </summary>
        private void OnEnable()
        {

            _disposables = new IDisposable[7];

            // プログラムデータ表示
            _disposables[0] = GameInfo.User.Company.CurrentOffice.GameSoftProject?.Param.Program
                             .Subscribe(x => _programText.text = x.ToString());

            // グラフィックデータ表示
            _disposables[1] = GameInfo.User.Company.CurrentOffice.GameSoftProject?.Param.Graphic
                             .Subscribe(x => _graphicText.text = x.ToString());

            // シナリオデータ表示
            _disposables[2] = GameInfo.User.Company.CurrentOffice.GameSoftProject?.Param.Scenario
                             .Subscribe(x => _scenarioText.text = x.ToString());

            // サウンドデータ表示
            _disposables[3] = GameInfo.User.Company.CurrentOffice.GameSoftProject?.Param.Sound
                             .Subscribe(x => _soundText.text = x.ToString());

            // バグデータ表示
            _disposables[4] = GameInfo.User.Company.CurrentOffice.GameSoftProject?.Param.Bug
                             .Subscribe(x => _bugText.text = x.ToString());

            // ゲーム開発進行率表示
            _disposables[5] = GameInfo.User.Company.CurrentOffice.GameSoftProject?.Param.ProgressRate
                             .Subscribe(x => _progressRateText.text = $"{x}%");

            // 現在のフェーズを調べる
            _disposables[6] = GameInfo.User.Company.CurrentOffice.GameSoftProject?.DevInfo.Phase
                             .Subscribe(x => CheckPhaseAndCreateMessage(x));
        }

        /// <summary>
        /// 開発フェーズを調べ、メッセージを作成
        /// </summary>
        private void CheckPhaseAndCreateMessage(EPhaseType type)
        {
            switch (type)
            {
                case EPhaseType.Proto:
                    _phaseText.text = "プロトタイプ版作成中...";
                    break;
                case EPhaseType.Alpha:
                    _phaseText.text = "アルファ版作成中...";
                    break;
                case EPhaseType.Beta:
                    _phaseText.text = "ベータ版作成中...";
                    break;
                case EPhaseType.Master:
                    _phaseText.text = "マスター版作成中...";
                    break;
                case EPhaseType.Completed:
                    _phaseText.text = "完成...";
                    break;
                case EPhaseType.Debug:
                    _phaseText.text = "デバッグ中...";
                    break;
                case EPhaseType.Release:
                    _phaseText.text = "発売...";
                    break;
            }

            Debug.Log($"現在の状態:{type}");
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
            if (_disposables == default) { return; }

            foreach (var dis in _disposables)
            {
                if(dis != null)
                {
                    dis.Dispose();
                }
            }
            _disposables = default;
        }
    }

}