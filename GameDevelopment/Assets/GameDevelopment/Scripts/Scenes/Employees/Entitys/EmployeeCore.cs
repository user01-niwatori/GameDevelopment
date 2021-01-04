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

        /// <summary>
        /// デフォルトの位置
        /// </summary>
        private Vector3 _defalutPosition = default;
        public  Vector3 DefalutPos { get { return _defalutPosition; } }

        /// <summary>
        /// デフォルトの回転
        /// </summary>
        private Quaternion _defalutRotation = default;
        public  Quaternion DefalutRot { get { return _defalutRotation; } }

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
            _number            = number;
            transform.position = EmployeeLocationInfo.Position[_number];
            transform.rotation = EmployeeLocationInfo.Rotation[_number];
            _defalutPosition   = transform.position;
            _defalutRotation   = transform.rotation;

            //this.UpdateAsObservable()
            //    .ThrottleFirst(TimeSpan.FromSeconds(Data.DevelopmentTime))
            //    .Subscribe(_ => Data.State.Value = (EState)((int)++Data.State.Value % 5));
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
        private void Home()
        {

        }

    }
}
