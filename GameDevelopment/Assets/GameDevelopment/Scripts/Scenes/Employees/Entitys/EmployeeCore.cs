using System;
using UniRx;
using UniRx.Triggers;
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
    public class EmployeeCore : MonoBehaviour
    {

        /// <summary>
        /// 社員番号（何番目に生成された社員）
        /// </summary>
        /// <remarks>
        /// OfficeのEmployeesのデータ参照用の添え字として使用
        /// </remarks>
        private int _number = 0;


        ///// <summary>
        ///// 状態
        ///// </summary>
        //private ReactiveProperty<EState> _state =  new ReactiveProperty<EState>();
        //public  IReadOnlyReactiveProperty<EState> State => _state;

        /// <summary>
        /// データ
        /// </summary>
        public EmployeeData Data 
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
        
        /// <summary>
        /// 初期化
        /// </summary>
        public void Initialize(int number)
        {
            _number   = number;

            // 移動用クラスで座標設定
            // 無い場合はそのままこのクラスで座標設定
            var mover = GetComponent<EmployeeMover>();
            if(mover)
            {
                mover.SetLocation(EmployeeLocationInfo.Position[_number], EmployeeLocationInfo.Rotation[_number]);
            }
            else
            {
                transform.position = EmployeeLocationInfo.Position[_number];
                transform.rotation = EmployeeLocationInfo.Rotation[_number];
            }

            Data.State.Value = EState.Work;
            Data.HP.Value = UnityEngine.Random.Range(20, 100);

            // 指定秒数経ったら
            // 仕事中で体力があるなら
            // HP -= 10
            Observable
                .Interval(TimeSpan.FromSeconds(2f))
                .Where(_ => Data.State.Value == EState.Work && Data.HP.Value > 0)
                .Subscribe(_ => Data.HP.Value -= 10)
                .AddTo(this);

            // 仕事中にHPが0以下になったら
            // 家に帰る
            Data.HP
                .Where(x => Data.State.Value == EState.Work && x <= 0)
                .Subscribe(_ => Data.State.Value = EState.GoToHome)
                .AddTo(this);

            // 家で睡眠中にHPが満タンになったら
            // 仕事に行く
            Data.HP
                .Where(x => Data.State.Value == EState.Sleep && x >= 50)
                .Subscribe(_ => Data.State.Value = EState.GoToWork)
                .AddTo(this);

            // 状態を監視し、変化次第チェックする
            Data.State
                .Subscribe(x => CheckState(x));
        }

        /// <summary>
        /// 状態を調べる
        /// </summary>
        /// <param name="state"></param>
        private void CheckState(EState state)
        {
            switch(state)
            {
                case EState.Work:
                    break;
                case EState.Rest:
                    break;
                case EState.Sleep:
                    Sleep();
                    break;
            }

            Debug.Log($"state:{state}");
        }

        /// <summary>
        /// 仕事
        /// </summary>
        private void Work()
        {
            Debug.Log("仕事中");
            //GameInfo.User.Company.CurrentOffice.
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
                    Data.HP.Value = 50;
                });
        }

    }
}
