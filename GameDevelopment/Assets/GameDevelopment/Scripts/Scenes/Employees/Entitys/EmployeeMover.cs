using UnityEngine;
using GameDevelopment.Scenes.Employees.Datas;
using UniRx;
using UniRx.Triggers;
using UnityEngine.AI;

namespace GameDevelopment.Scenes.Employees.Entitys
{
    /// <summary>
    /// 移動タイプ
    /// </summary>
    public enum EMoveType
    {
        Idle,
        Move,
        Rest,
        Work,
    }

    /// <summary>
    /// 社員の移動処理
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(CapsuleCollider))]
    [RequireComponent(typeof(EmployeeCore))]
    [RequireComponent(typeof(NavMeshAgent))]
    public class EmployeeMover : MonoBehaviour
    {
        /// <summary>
        /// 移動タイプ
        /// </summary>
        private ReactiveProperty<EMoveType> _moveType = new ReactiveProperty<EMoveType>();
        public  IReadOnlyReactiveProperty<EMoveType> MoveType => _moveType;

        /// <summary>
        /// 社員のコア部分
        /// </summary>
        private EmployeeCore _employeeCore = default;

        /// <summary>
        /// NavMeshAgent
        /// </summary>
        private NavMeshAgent _navMeshAgent = null;

        /// <summary>
        /// Start
        /// </summary>
        private void Start()
        {
            _employeeCore = GetComponent<EmployeeCore>();
            _navMeshAgent = GetComponent<NavMeshAgent>();

            if(_employeeCore)
            {
                _employeeCore.Data.State
                             .Subscribe(x => SetMoveType(x))
                             .AddTo(this);

                this.UpdateAsObservable()
                    .Where(_ => _moveType.Value == EMoveType.Move)
                    .Subscribe(_ => Movement())
                    .AddTo(this);
            }
        }

        /// <summary>
        /// 移動タイプを設定
        /// </summary>
        private void SetMoveType(EState state)
        {
            switch(state)
            {
                case EState.None:
                    _moveType.Value = EMoveType.Idle;
                    break;
                case EState.Arrive:
                case EState.Home:
                    _moveType.Value = EMoveType.Move;
                    break;
                case EState.Work:
                    _moveType.Value = EMoveType.Work;
                    break;
                case EState.Rest:
                    _moveType.Value = EMoveType.Rest;
                    break;
            }
        }

        /// <summary>
        /// 移動処理
        /// </summary>
        private void Movement()
        {
            switch(_employeeCore.Data.State.Value)
            {
                case EState.Arrive:
                    _navMeshAgent.destination = _employeeCore.DefalutPos;
                    break;
                case EState.Home:
                    _navMeshAgent.destination = new Vector3(3.5f, 0f, -3.5f);
                    break;
            }
        }
    }
}
