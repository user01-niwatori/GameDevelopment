using UniRx;
using System;
using UnityEngine;
using UniRx.Triggers;
using GameDevelopment.Common.Datas;
using GameDevelopment.Scenes.Employees.Datas;
using GameDevelopment.Scenes.Games.Datas;
using GameDevelopment.Scenes.CompanyScenes.UI.HUDs;
using GameDevelopment.Scenes.CompanyScenes.UI.HUDs.GameSoftProjectDevUIs;

namespace GameDevelopment.Scenes.Games.Entitys
{
    /// <summary>
    /// ゲームソフトプロジェクト
    /// </summary>
    public class GameSoftProject : MonoBehaviour
    {
        /// <summary>
        /// HUD
        /// </summary>
        [SerializeField]
        private HUD _HUD = default;

        /// <summary>
        /// 開発フェーズに関するUI
        /// </summary>
        /// <remarks>
        /// フェーズ変更時に表示されるUI達
        /// </remarks>
        [SerializeField]
        private BaseGamePhaseUI[] _phaseUI = default;

        /// <summary>
        /// メモリ開放用Disposable
        /// </summary>
        private IDisposable[] _disposables = default;

        /// <summary>
        /// 初期化
        /// </summary>
        public void Initialized(GameSoftwareData soft)
        {
            this.gameObject.SetActive(true);

            // 開発するゲームソフトの情報設定。
            // 開発準備
            GameInfo.User.Company.CurrentOffice.GameSoftProject = soft;
            Setup();
        }

        /// <summary>
        /// 準備
        /// </summary>
        private void Setup()
        {
            // 開発開始日
            // 開発終了予定日
            var project                               = GameInfo.User.Company.CurrentOffice.GameSoftProject;
            var start                                 = GameInfo.Date.Get();
            var end                                   = start.AddMonths(GameInfo.User.Company.CurrentOffice.GameSoftProject.DevInfo.Scale.GetPeriod());
            project.DevInfo.Dates.DevStartDate        = new Date(start);
            project.DevInfo.Dates.DevEndScheduledDate = new Date(end);

            // 社員の仕事をゲームソフト開発にする。
            for (int i = 0; i < GameInfo.User.Company.CurrentOffice.EmployeeCount; i++)
            {
                GameInfo.User.Company.CurrentOffice.Employees[i].Task.Value = EEmployeeTask.GameSoft;
            }

            // 日付が更新される度に進行率を更新する。
            // 開発フェーズ変更時に呼び出すメソッドを設定
            // 毎フレーム更新処理
            _disposables 　 = new IDisposable[3];
            _disposables[0] = GameInfo.Date.Time
                                      .Subscribe(x => SetProgressRate(x));
            _disposables[1] = GameInfo.User.Company.CurrentOffice.GameSoftProject?.DevInfo.Phase
                                      .Subscribe(x => OnChangedPhase(x));
            _disposables[2] = this.UpdateAsObservable()
                                  .Subscribe(_ => OnUpdate());

            // ゲームソフト開発中に表示するHUD表示
            _HUD.StartGameSoftProject();
        }

        /// <summary>
        /// 更新処理(UpdateAsObservable)
        /// </summary>
        private void OnUpdate()
        {
            int progress = GameInfo.User.Company.CurrentOffice.GameSoftProject.Param.ProgressRate.Value;

            switch (GameInfo.User.Company.CurrentOffice.GameSoftProject?.DevInfo.Phase.Value)
            {
                case EPhaseType.Proto:
                    if (progress >= 30) { GameInfo.User.Company.CurrentOffice.GameSoftProject.DevInfo.Phase.Value = EPhaseType.Alpha; }
                    break;
                case EPhaseType.Alpha:
                    if (progress >= 60) { GameInfo.User.Company.CurrentOffice.GameSoftProject.DevInfo.Phase.Value = EPhaseType.Beta; }
                    break;
                case EPhaseType.Beta:
                    if (progress >= 80) { GameInfo.User.Company.CurrentOffice.GameSoftProject.DevInfo.Phase.Value = EPhaseType.Master; }
                    break;
                case EPhaseType.Master:
                    if (progress == 100) { GameInfo.User.Company.CurrentOffice.GameSoftProject.DevInfo.Phase.Value = EPhaseType.Completed; }
                    break;
                case EPhaseType.Completed:
                    break;
                case EPhaseType.Debug:
                    if(GameInfo.User.Company.CurrentOffice.GameSoftProject.Param.Bug.Value == 0)
                    {
                        GameInfo.User.Company.CurrentOffice.GameSoftProject.DevInfo.Phase.Value = EPhaseType.Release;
                    }
                    break;
            }
        }

        /// <summary>
        /// 開発フェーズ変更時に呼びされる処理
        /// </summary>
        private void OnChangedPhase(EPhaseType type)
        {
            switch (type)
            {
                case EPhaseType.Proto:
                    break;
                case EPhaseType.Alpha:
                    _phaseUI[0].gameObject.SetActive(true);
                    break;
                case EPhaseType.Beta:
                    _phaseUI[1].gameObject.SetActive(true);
                    break;
                case EPhaseType.Master:
                    _phaseUI[2].gameObject.SetActive(true);
                    break;
                case EPhaseType.Completed:
                    var completedMsgBox = Instantiate(Resources.Load(PathData.MessageBox)) as GameObject;
                    completedMsgBox.GetComponent<MessageBox>().Initialize_Ok
                        ("ゲームソフトが完成しました！\nこれからバグ修正を行います。",
                        () => GameInfo.User.Company.CurrentOffice.GameSoftProject.DevInfo.Phase.Value = EPhaseType.Debug);
                    break;
                case EPhaseType.Debug:
                    break;
                case EPhaseType.Release:
                    var releaseMsgBox = Instantiate(Resources.Load(PathData.MessageBox)) as GameObject;
                    releaseMsgBox.GetComponent<MessageBox>().Initialize_Ok
                        ("バグ修正が終了しました。\nゲームソフトの名前を入力してください。",
                        null);
                    break;
            }
        }

        /// <summary>
        /// 進行率を設定
        /// </summary>
        /// <param name="currentDate"></param>
        private void SetProgressRate(DateTime currentDate)
        {
            // TODO: 処理に時間がかかる、もっと効率の良い求め方があるかも。
            // 開発に掛かる日数を求める
            // 進行日数を求める
            // 進行率を求める
            var project                      = GameInfo.User.Company.CurrentOffice.GameSoftProject;
            var devDays                      = project.DevInfo.Dates.DevEndScheduledDate.Time.Value - project.DevInfo.Dates.DevStartDate.Time.Value;
            var progress                     = devDays - (project.DevInfo.Dates.DevEndScheduledDate.Time.Value - currentDate);
            var ratio                        = (float)progress.Days / (float)devDays.Days;
            int progressRate                 = (int)((Utility.ConvertDecimalPoint(ratio, 2, Utility.MathType.Floor)) * 100);
            project.Param.ProgressRate.Value = Mathf.Clamp(progressRate, 0, 100);
        }

        ///// <summary>
        ///// 開発フェーズを設定
        ///// </summary>
        //public void SetPhase(int progress)
        //{
        //    // Alpha 30 ～ 59％
        //    if (GameInfo.User.Company.CurrentOffice.GameSoftProject.DevInfo.Phase.Value != EPhaseType.Alpha &&
        //        progress >= 30 && progress < 60)
        //    {
        //        GameInfo.User.Company.CurrentOffice.GameSoftProject.DevInfo.Phase.Value = EPhaseType.Alpha;
        //    }
        //    // Beta 60 ～ 79％
        //    else if (GameInfo.User.Company.CurrentOffice.GameSoftProject.DevInfo.Phase.Value != EPhaseType.Beta && 
        //        progress >= 60 && progress < 80)
        //    {
        //        GameInfo.User.Company.CurrentOffice.GameSoftProject.DevInfo.Phase.Value = EPhaseType.Beta;
        //    }
        //    // Master 80 ～ 99％
        //    else if (GameInfo.User.Company.CurrentOffice.GameSoftProject.DevInfo.Phase.Value != EPhaseType.Master && 
        //        progress >= 80 && progress < 100)
        //    {
        //        GameInfo.User.Company.CurrentOffice.GameSoftProject.DevInfo.Phase.Value = EPhaseType.Master;
        //    }
        //    // Completed 100% 
        //    else if (GameInfo.User.Company.CurrentOffice.GameSoftProject.DevInfo.Phase.Value != EPhaseType.Completed &&
        //        progress == 100)
        //    {
        //        GameInfo.User.Company.CurrentOffice.GameSoftProject.DevInfo.Phase.Value = EPhaseType.Completed;
        //    }
        //}

        /// <summary>
        /// ゲームオブジェクト非表示時
        /// </summary>
        private void OnDisable()
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
                if (dis != null)
                {
                    dis.Dispose();
                }
            }

            _disposables = default;
        }
    }
}