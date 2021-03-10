using UnityEngine;
using GameDevelopment.Scenes.Employees.Datas;
using UniRx;
using UniRx.Triggers;
using UnityEngine.AI;

/*  NavMeshAgentの設定内容

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
    [RequireComponent(typeof(EmployeeCore))]
    [RequireComponent(typeof(NavMeshAgent))]
    public class EmployeeMover : BehaviourInitialized
    {
        /// <summary>
        /// デフォルトの位置
        /// </summary>
        protected Vector3 _defalutPosition = default;

        /// <summary>
        /// デフォルトの回転
        /// </summary>
        protected Quaternion _defalutRotation = default;

        /// <summary>
        /// 家の座標
        /// </summary>
        protected Vector3 _homePosition = new Vector3(10f, 0f, -8f);

        /// <summary>
        /// 移動タイプ
        /// </summary>
        protected ReactiveProperty<EMoveType> _moveType = new ReactiveProperty<EMoveType>();
        public    IReadOnlyReactiveProperty<EMoveType> MoveType => _moveType;

        /// <summary>
        /// 社員のコア部分
        /// </summary>
        protected EmployeeCore _employeeCore = default;

        /// <summary>
        /// NavMeshAgent
        /// </summary>
        protected NavMeshAgent _navMeshAgent = null;

        /// <summary>
        /// Start
        /// </summary>
        private async void Start()
        {
            _employeeCore = GetComponent<EmployeeCore>();
            _navMeshAgent = GetComponent<NavMeshAgent>();
            await _employeeCore?.OnInitialized;

            if (_employeeCore)
            {
                // 初期位置設定
                SetLocation(EmployeeLocationInfo.Position[_employeeCore.Number], EmployeeLocationInfo.Rotation[_employeeCore.Number]);

                // 社員の状態を監視し
                // 状態に変化があれば移動タイプを設定する
                _employeeCore.State
                             .Subscribe(x => SetMoveType(x))
                             .AddTo(this);

                // 移動タイプがMove状態なら
                // 移動中監視し、状態を変化させたりする。
                this.UpdateAsObservable()
                    .Where(_ => _moveType.Value == EMoveType.Move)
                    .Subscribe(_ => CheckMovement())
                    .AddTo(this);
            }

            // 初期化完了
            _isInitialized.Value = true;
        }

        /// <summary>
        /// 移動タイプを設定
        /// </summary>
        private void SetMoveType(EEmployeeState state)
        {
            switch(state)
            {
                case EEmployeeState.None:
                case EEmployeeState.Sleep:
                    _moveType.Value = EMoveType.Idle;
                    break;
                case EEmployeeState.GoToHome:
                    Movement(_homePosition);
                    _moveType.Value = EMoveType.Move;
                    break;
                case EEmployeeState.GoToWork:
                    Movement(_defalutPosition);
                    _moveType.Value = EMoveType.Move;
                    break;
                case EEmployeeState.Work:
                    _moveType.Value = EMoveType.Work;
                    break;
                case EEmployeeState.Rest:
                    _moveType.Value = EMoveType.Rest;
                    break;
            }

        }

        /// <summary>
        /// 移動処理
        /// </summary>
        /// <param name="targetPos">目的地</param>
        private void Movement(Vector3 targetPos)
        {
            _navMeshAgent.isStopped = false;
            _navMeshAgent.SetDestination(targetPos);
        }

        /// <summary>
        /// 移動停止
        /// </summary>
        private void Stop()
        {
            _navMeshAgent.isStopped = true;
        }

        /// <summary>
        /// 移動中調べる
        /// </summary>
        private void CheckMovement()
        {
            switch (_employeeCore.State.Value)
            {
                case EEmployeeState.GoToWork:
                    CheckGoToWork();
                    break;
                case EEmployeeState.GoToHome:
                    CheckGoToHome();
                    break;
            }
        }

        /// <summary>
        /// 仕事場へ移動中調べる
        /// 仕事場に着いたらWork状態にする
        /// </summary>
        protected virtual void CheckGoToWork()
        {
            // 仕事場にたどり着いたら仕事をする
            if (_navMeshAgent.remainingDistance < _navMeshAgent.stoppingDistance)
            {
                Stop();
                _employeeCore.SetState(EEmployeeState.Work);
            }
        }

        /// <summary>
        /// 家に帰る中移動中調べる
        /// 家に着いたらSleep状態にする
        /// </summary>
        protected virtual void CheckGoToHome()
        {
            // 家に着いたら寝る
            if (_navMeshAgent.remainingDistance < _navMeshAgent.stoppingDistance * 10)
            {
                Stop();
                _employeeCore.SetState(EEmployeeState.Sleep);
            }
        }

        /// <summary>
        /// 位置情報を設定
        /// </summary>
        /// <remarks>
        /// EmployeeCore.csで使用されている。
        /// </remarks>
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
