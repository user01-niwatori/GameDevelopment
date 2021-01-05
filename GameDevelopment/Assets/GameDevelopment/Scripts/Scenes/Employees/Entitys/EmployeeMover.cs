using UnityEngine;
using GameDevelopment.Scenes.Employees.Datas;
using UniRx;
using UniRx.Triggers;
using UnityEngine.AI;

/*  NavMeshAgentの概要

    Agent Type                  エージェントのタイプ
    Base Offset                 エージェントの位置のオフセット
    Speed                       エージェントの最高速度
    Angular Speed               最高回転速度
    Acceleration                最大加速度
    Stopping Distance           目的地とどれだけ近づいたら止めるかの距離
    Auto Braking                チェックを入れると目的地に近づいたら減速させます。
    Radius                      障害物を回避する半径
    Height                      障害物を回避する高さ
    Quality                     回避する品質の高さ
    Priority                    指定した数値より低いエージェントの回避を無視します。
    Auto Traverse Off MeshLink  チェックを入れるとオフメッシュリンクのポイントに来たら自動でオフメッシュリンクを移動します。
    Auto Repath                 チェックを入れると部分的な移動経路の目的地についたら自動で次の経路を探索します。
    Area Mask                   このエージェントがどのエリアを移動可能にするかを選択出来ます
*/

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
        /// デフォルトの位置
        /// </summary>
        private Vector3 _defalutPosition = default;

        /// <summary>
        /// デフォルトの回転
        /// </summary>
        private Quaternion _defalutRotation = default;

        /// <summary>
        /// 家の座標
        /// </summary>
        private Vector3 _homePosition = new Vector3(10f, 0f, -8f);

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
                // 社員の状態を監視し
                // 状態に変化があれば移動タイプを設定する
                _employeeCore.Data.State
                             .Subscribe(x => SetMoveType(x))
                             .AddTo(this);

                // 移動タイプがMove状態なら
                // 移動中監視し、状態を変化させたりする。
                this.UpdateAsObservable()
                    .Where(_ => _moveType.Value == EMoveType.Move)
                    .Subscribe(_ => CheckMovement())
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
                case EState.Sleep:
                    _moveType.Value = EMoveType.Idle;
                    break;
                case EState.GoToHome:
                    _navMeshAgent.SetDestination(_homePosition);
                    _moveType.Value = EMoveType.Move;
                    break;
                case EState.GoToWork:
                    _navMeshAgent.SetDestination(_defalutPosition);
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
        /// 移動中調べる
        /// </summary>
        private void CheckMovement()
        {
            switch (_employeeCore.Data.State.Value)
            {
                case EState.GoToWork:
                    CheckGoToWork();
                    break;
                case EState.GoToHome:
                    CheckGoToHome();
                    break;
            }
        }

        /// <summary>
        /// 仕事場へ移動中調べる
        /// 仕事場に着いたらWork状態にする
        /// </summary>
        private void CheckGoToWork()
        {
            if (_navMeshAgent.remainingDistance < _navMeshAgent.stoppingDistance)
            {
                transform.rotation = _defalutRotation;
                _employeeCore.Data.State.Value = EState.Work;
            }
        }

        /// <summary>
        /// 家に帰る中移動中調べる
        /// 家に着いたらSleep状態にする
        /// </summary>
        private void CheckGoToHome()
        {
            if (_navMeshAgent.remainingDistance < _navMeshAgent.stoppingDistance)
            {
                _employeeCore.Data.State.Value = EState.Sleep;
            }
        }

        /// <summary>
        /// 位置情報を設定
        /// </summary>
        /// <param name="pos">座標</param>
        /// <param name="qua">回転</param>
        public void SetLocation(Vector3 pos, Quaternion qua)
        {
            _defalutPosition = pos;
            _defalutRotation = qua;
            transform.position = _defalutPosition;
            transform.rotation = _defalutRotation;
        }
    }
}
