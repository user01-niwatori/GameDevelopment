using System;
using UniRx;
using UnityEngine;
using GameDevelopment.Common.Datas;
using GameDevelopment.Scenes.Employees.Datas;

namespace GameDevelopment.Scenes.Employees.Entitys
{

    /// <summary>
    /// 社員コア部分
    /// </summary>
    /// <remarks>
    /// このスクリプトを経由して社員クラス同士のやり取りを行う
    /// </remarks>
    [RequireComponent(typeof(EmployeeMover))]
    public class EmployeeCore : BehaviourInitialized
    {
        #region field

        /// <summary>
        /// HPを引く値
        /// </summary>
        private const int SubtractHP = 1;

        /// <summary>
        /// 社員番号（何番目に生成された社員）
        /// </summary>
        /// <remarks>
        /// OfficeのEmployeesのデータ参照用の添え字として使用
        /// </remarks>
        private int _number = 0;

        /// <summary>
        /// 体力の最大値
        /// </summary>
        private int _maxHP = 0;

        /// <summary>
        /// データ
        /// </summary>
        private EmployeeData Data 
        {
            get
            {
                return GameInfo.User.Company.Offices[GameInfo.CurrentOffice].Employees[_number];
            }
            set
            {
                GameInfo.User.Company.Offices[GameInfo.CurrentOffice].Employees[_number] = value;
            }
        }

        #endregion

        #region getter/setter

        /// <summary>
        /// HP
        /// </summary>
        public IReadOnlyReactiveProperty<int> HP => Data.HP;

        /// <summary>
        /// プログラム
        /// </summary>
        public IReadOnlyReactiveProperty<int> Program => Data.Param.Program;

        /// <summary>
        /// グラフィック
        /// </summary>
        public IReadOnlyReactiveProperty<int> Graphic => Data.Param.Graphic;

        /// <summary>
        /// シナリオ
        /// </summary>
        public IReadOnlyReactiveProperty<int> Scenario => Data.Param.Scenario;

        /// <summary>
        /// サウンド
        /// </summary>
        public IReadOnlyReactiveProperty<int> Sound => Data.Param.Sound;

        /// <summary>
        /// 状態
        /// </summary>
        public IReadOnlyReactiveProperty<EEmployeeState> State => Data.State;

        /// <summary>
        /// 状態を設定
        /// </summary>
        /// <param name="state">状態/param>
        public void SetState(EEmployeeState state)
        {
            Data.State.Value = state;
        }

        #endregion

        /// <summary>
        /// Start
        /// </summary>
        private void Start()
        {
            // 移動用クラスで座標設定
            var mover = GetComponent<EmployeeMover>();
            mover?.SetLocation(EmployeeLocationInfo.Position[_number], EmployeeLocationInfo.Rotation[_number]);

            OnUpdate();
            CheckData();

            // 設定
            Data.HP.Value = 3;
            Data.Param.Program.Value = UnityEngine.Random.Range(10, 50);
            Data.Param.Graphic.Value = UnityEngine.Random.Range(10, 50);
            Data.Param.Scenario.Value = UnityEngine.Random.Range(10, 50);
            Data.Param.Sound.Value = UnityEngine.Random.Range(10, 50);

            // 初期化完了
            _isInitialized.Value = true;
        }

        /// <summary>
        /// 初期化
        /// </summary>
        public void Initialize(int number)
        {
            _number   = number;
        }

        /// <summary>
        /// 更新処理
        /// </summary>
        private void OnUpdate()
        {
            // 指定秒数経ったら...
            // 仕事中で体力があるなら...
            // HP -= 引く値
            Observable
                .Interval(TimeSpan.FromSeconds(Data.DevelopmentTime))
                .Where(_ => Data.State.Value == EEmployeeState.Work && Data.HP.Value > 0)
                .Subscribe(_ => Data.HP.Value -= SubtractHP)
                .AddTo(this);
        }

        /// <summary>
        /// データの変化を調べる
        /// </summary>
        private void CheckData()
        {
            // 現在のHPがHPの最大値を上回ったら...
            // 現在のHPをHPの最大値として設定する。
            Data.HP
                .Where(x => x > _maxHP)
                .Subscribe(x => _maxHP = x);

            // 仕事中にHPが0以下になったら...
            // 家に帰る。
            Data.HP
                .Where(x => Data.State.Value == EEmployeeState.Work && x <= 0)
                .Subscribe(_ => Data.State.Value = EEmployeeState.GoToHome)
                .AddTo(this);

            // 家で睡眠中にHPが満タンになったら...
            // 仕事に行く。
            Data.HP
                .Where(x => Data.State.Value == EEmployeeState.Sleep && x >= _maxHP)
                .Subscribe(_ => Data.State.Value = EEmployeeState.GoToWork)
                .AddTo(this);

            // 状態を監視
            Data.State
                .Subscribe(x => CheckState(x))
                .AddTo(this);

            // 仕事内容を監視
            Data.Task
                .Subscribe(x => CheckTask(x))
                .AddTo(this);
        }

        /// <summary>
        /// 状態を調べる
        /// </summary>
        /// <param name="state">状態</param>
        private void CheckState(EEmployeeState state)
        {
            switch(state)
            {
                case EEmployeeState.Work:
                    break;
                case EEmployeeState.Rest:
                    break;
                case EEmployeeState.Sleep:
                    Sleep();
                    break;
            }

            //Debug.Log($"state:{state}");
        }

        /// <summary>
        /// 仕事の内容を調べる
        /// </summary>
        /// <param name="task">仕事</param>
        private void CheckTask(EEmployeeTask task)
        {
            switch (task)
            {
                case EEmployeeTask.None:
                    break;
                case EEmployeeTask.GameHard:
                    Data.State.Value = EEmployeeState.Work;
                    break;
                case EEmployeeTask.GameSoft:
                    Data.State.Value = EEmployeeState.Work;
                    break;
            }
        }

        /// <summary>
        /// 仕事
        /// </summary>
        private void Work()
        {
            
        }

        /// <summary>
        /// 休む
        /// </summary>
        private void Rest()
        {

        }

        /// <summary>
        /// 家にいる時の処理
        /// </summary>
        private void Sleep()
        {
            // 指定秒数後、体力全回復
            // メッセージが発光されたらこのObservableは自動的に停止する
            Observable
                .Timer(TimeSpan.FromSeconds(10f))
                .Subscribe(_ =>
                {
                    Data.HP.Value = _maxHP;
                });
        }

    }
}
